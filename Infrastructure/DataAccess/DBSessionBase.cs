using System;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// 数据连接事务的Session接口，针对DapperExtension
    /// </summary>
    public interface IDBSession
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        DatabaseType DatabaseType { get; }
        /// <summary>
        /// 数据库链接
        /// </summary>
        IDbConnection Connection { get; }
        /// <summary>
        /// 数据库适配器
        /// </summary>
        IDBAdaptor DBAdaptor { get; }

        /// <summary>
        /// 事务开始
        /// </summary>
        /// <param name="isolation">事务级别</param>
        /// <returns></returns>
        IDbTransaction Begin(IsolationLevel isolation = IsolationLevel.ReadCommitted);

        bool TransactionHandle(Func<IDbTransaction, bool> execution);
        Task<bool> TransactionHandle(Func<IDbTransaction, Task<bool>> execution);
        Task<string> TransactionHandle(Func<IDbTransaction, Task<string>> execution);
    }

    /// <summary>
    /// 数据库连接事务的Session对象
    /// </summary>
    public class DBSessionBase : IDBSession
    {
        public DatabaseType DatabaseType
        {
            get;
            private set;
        }

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public IDbConnection Connection
        {
            get;
            private set;
        }

        public IDBAdaptor DBAdaptor
        {
            get;
            private set;
        }

        public DBSessionBase(DatabaseType dbType, string connKey)
        {
            DatabaseType = dbType;
            Connection = SqlConnectionFactory.CreateSqlConnection(dbType, connKey);
            DBAdaptor = DBAdaptorFactory.GetDbAdaptor(this);
        }

        public DBSessionBase(DatabaseType dbType, IDbConnection connection)
        {
            DatabaseType = dbType;
            Connection = connection;
            DBAdaptor = DBAdaptorFactory.GetDbAdaptor(this);
        }

        /// <summary>
        /// 开启会话
        /// </summary>
        /// <param name="isolation"></param>
        /// <returns></returns>
        public IDbTransaction Begin(IsolationLevel isolation = IsolationLevel.ReadCommitted)
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            return new TransactionImplement(Connection, isolation);
        }

        public async Task<bool> TransactionHandle(Func<IDbTransaction, Task<bool>> execution)
        {
            bool result = false;
            using (IDbTransaction transaction = Begin())
            {
                try
                {
                    result = await execution(transaction);
                    if (result)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    transaction.Dispose();
                }
            }
            return result;
        }

        public async Task<string> TransactionHandle(Func<IDbTransaction, Task<string>> execution)
        {
            string result = string.Empty;
            using (IDbTransaction transaction = Begin())
            {
                try
                {
                    result = await execution(transaction);
                    if (!string.IsNullOrEmpty(result))
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    transaction.Dispose();
                }
            }
            return result;
        }

        public bool TransactionHandle(Func<IDbTransaction, bool> execution)
        {
            bool result = false;
            using (IDbTransaction transaction = Begin())
            {
                try
                {
                    result = execution(transaction);
                    if (result)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    transaction.Dispose();
                }
            }
            return result;
        }
    }
}
