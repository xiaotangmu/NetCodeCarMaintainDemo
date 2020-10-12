using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccess;
using DapperExtensions;
using System.Threading.Tasks;
using System.Text;
using System.Reflection;

/// <summary>
/// （支持sql）IDataRepository的实现类，数据层继承ORM中的 RepositoryBase类
/// </summary>
namespace ORM
{
    public class RepositoryBase : IDataRepository
    {
        protected int? TimeOut = 30;

        public IDBSession DbSession
        {
            get; private set;
        }

        public RepositoryBase(IDBSession dbSession)
        {
            DbSession = dbSession;
        }

        /// <summary>
        /// 根据条件筛选出数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public T GetFirst<T>(string sql, dynamic param = null, bool buffered = true) where T : class, new()
        {
            IEnumerable<T> result = DbSession.Connection.Query<T>(sql, param as object, null, buffered, TimeOut);
            if (result == null)
            {
                return default;
            }
            return result.SingleOrDefault();
        }

        /// <summary>
        /// 根据条件筛选出数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public async Task<T> GetFirstAsync<T>(string sql, dynamic param = null, bool buffered = true) where T : class, new()
        {
            IEnumerable<T> result = await DbSession.Connection.QueryAsync<T>(sql, param as object, null, buffered, TimeOut);
            if (result == null)
            {
                return default;
            }
            return result.SingleOrDefault<T>();
        }

        /// <summary>
        /// 根据条件筛选出数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<T> GetGroup<T>(string sql, dynamic param = null, bool buffered = true) where T : class, new()
        {
            IEnumerable<T> result = DbSession.Connection.Query<T>(sql, param as object, null, buffered, TimeOut);
            if (result == null)
            {
                return Enumerable.Empty<T>();
            }
            return result;
        }

        /// <summary>
        /// 根据条件筛选出数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetGroupAsync<T>(string sql, dynamic param = null, bool buffered = true) where T : class, new()
        {
            IEnumerable<T> result = await DbSession.Connection.QueryAsync<T>(sql, param as object, null, buffered, TimeOut);
            if (result == null)
            {
                return Enumerable.Empty<T>();
            }
            return result;
        }

        /// <summary>
        /// 根据条件筛选数据集合
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<dynamic> GetCustomReturnTypeGroup(string sql, dynamic param = null, bool buffered = true)
        {
            IEnumerable<dynamic> result = DbSession.Connection.Query(sql, param as object, null, buffered, TimeOut);
            if (result == null)
            {
                return Enumerable.Empty<dynamic>();
            }
            return result;
        }

        /// <summary>
        /// 根据条件筛选数据集合
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public async Task<IEnumerable<dynamic>> GetCustomReturnTypeGroupAsync(string sql, dynamic param = null, bool buffered = true)
        {
            IEnumerable<dynamic> result = await DbSession.Connection.QueryAsync(sql, param as object, null, buffered, TimeOut);
            if (result == null)
            {
                return Enumerable.Empty<dynamic>();
            }
            return result;
        }

        /// <summary>
        /// 根据表达式筛选
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public IEnumerable<TReturn> GetGroup<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map,
            dynamic param = null, bool buffered = true, string splitOn = "Id",
            int? commandTimeout = null)
        {
            IEnumerable<TReturn> result = DbSession.Connection.Query(sql, map, param as object, null, buffered, splitOn, TimeOut);
            if (result == null)
            {
                return Enumerable.Empty<TReturn>();
            }
            return result;
        }

        /// <summary>
        /// 根据表达式筛选
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TReturn>> GetGroupAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map,
            dynamic param = null, bool buffered = true, string splitOn = "Id",
            int? commandTimeout = null)
        {
            IEnumerable<TReturn> result = await DbSession.Connection.QueryAsync(sql, map, param as object, null, buffered, splitOn, TimeOut);
            if (result == null)
            {
                return Enumerable.Empty<TReturn>();
            }
            return result;
        }

        /// <summary>
        /// 根据表达式筛选
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public IEnumerable<TReturn> GetGroup<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map,
            dynamic param = null, bool buffered = true, string splitOn = "Id",
            int? commandTimeout = null)
        {
            IEnumerable<TReturn> result = DbSession.Connection.Query(sql, map, param as object, null, buffered, splitOn, TimeOut);
            if (result == null)
            {
                return Enumerable.Empty<TReturn>();
            }
            return result;
        }

        /// <summary>
        /// 根据表达式筛选
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TReturn>> GetGroupAsync<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map,
            dynamic param = null, bool buffered = true, string splitOn = "Id",
            int? commandTimeout = null)
        {
            IEnumerable<TReturn> result = await DbSession.Connection.QueryAsync(sql, map, param as object, null, buffered, splitOn, TimeOut);
            if (result == null)
            {
                return Enumerable.Empty<TReturn>();
            }
            return result;
        }

        /// <summary>
        /// 获取多实体集合
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public SqlMapper.GridReader GetMultiple(string sql, dynamic param = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            return DbSession.Connection.QueryMultiple(sql, param as object, null, commandTimeout ?? TimeOut, commandType);
        }

        /// <summary>
        /// 获取多实体集合
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<SqlMapper.GridReader> GetMultipleAsync(string sql, dynamic param = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            return await DbSession.Connection.QueryMultipleAsync(sql, param as object, null, commandTimeout ?? TimeOut, commandType);
        }

        public SqlMapper.GridReader GetMultipleOnPaging(string sql, int pageIndex, int pageSize, dynamic param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            string sqlPaging = DbSession.DBAdaptor.GetPagingSql(pageIndex, pageSize, sql, null);
            return DbSession.Connection.QueryMultiple(sqlPaging, param as object, null, commandTimeout ?? TimeOut, commandType);
        }

        public async Task<SqlMapper.GridReader> GetMultipleOnPagingAsync(string sql, int pageIndex, int pageSize, dynamic param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            string sqlPaging = DbSession.DBAdaptor.GetPagingSql(pageIndex, pageSize, sql, null);
            return await DbSession.Connection.QueryMultipleAsync(sqlPaging, param as object, null, commandTimeout ?? TimeOut, commandType);
        }

        /// <summary>
        /// 执行sql操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Execute(string sql, dynamic param = null, IDbTransaction transaction = null)
        {
            return DbSession.Connection.Execute(sql, param as object, transaction, TimeOut);
        }

        /// <summary>
        /// 执行sql操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string sql, dynamic param = null, IDbTransaction transaction = null)
        {
            return await DbSession.Connection.ExecuteAsync(sql, param as object, transaction, TimeOut);

        }

        public IEnumerable<T> GetPage<T>(int pageIndex, int pageSize, out long allRowsCount, string sql, string orderby, dynamic param = null, string allRowsCountSql = null, dynamic allRowsCountParam = null, bool buffered = true) where T : class, new()
        {
            string sqlPage = DbSession.DBAdaptor.GetPagingSql(pageIndex, pageSize, sql, orderby);
            allRowsCount = Count(sql);
            IEnumerable<T> result = DbSession.Connection.Query<T>(sqlPage);
            if (result == null)
            {
                return Enumerable.Empty<T>();
            }
            return result;
        }

        public async Task<IEnumerable<T>> GetPageAsync<T>(int pageIndex, int pageSize, string sql, string orderby,dynamic param = null, string allRowsCountSql = null, dynamic allRowsCountParam = null, bool buffered = true) where T : class, new()
        {
            string sqlPage = DbSession.DBAdaptor.GetPagingSql(pageIndex, pageSize, sql, orderby);
            IEnumerable<T> result = await DbSession.Connection.QueryAsync<T>(sqlPage);
            if (result == null)
            {
                return Enumerable.Empty<T>();
            }
            return result;
        }

        public int Count(string sql, dynamic param = null)
        {
            return DbSession.Connection.QuerySingle<int>(sql);
        }

        public async Task<int> CountAsync(string sql, dynamic param = null)
        {
            return await DbSession.Connection.QuerySingleAsync<int>(sql);
        }

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryId"></param>
        /// <returns></returns>
        public T GetById<T>(dynamic primaryId) where T : class, new()
        {
            T result = DbSession.Connection.Get<T>(primaryId as object, DbSession.DatabaseType, transaction: null, commandTimeout: TimeOut);
            if (result == null)
            {
                return default;
            }
            return result;
        }

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryId"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync<T>(dynamic primaryId) where T : class, new()
        {
            T result = await DbSession.Connection.GetAsync<T>(primaryId as object, DbSession.DatabaseType, transaction: null, commandTimeout: TimeOut);
            if (result == null)
            {
                return default;
            }
            return result;
        }

        /// <summary>
        /// 获取全部数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAll<T>() where T : class, new()
        {
            IEnumerable<T> result = DbSession.Connection.GetList<T>(DbSession.DatabaseType, transaction: null, commandTimeout: TimeOut);
            if (result == null)
            {
                return Enumerable.Empty<T>();
            }
            return result;
        }

        /// <summary>
        /// 获取全部数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllAsync<T>(int pageNumber = 1, int pageMaxResult = 10) where T : class, new()
        {
            IEnumerable<T> result = await DbSession.Connection.GetListAsync<T>(DbSession.DatabaseType, transaction: null, commandTimeout: TimeOut);
            if (result == null)
            {
                return Enumerable.Empty<T>();
            }
            return result;
        }

        /// <summary>
        /// 获取全部数据(排序),供业务层调用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SortDic">Key="字段名称",Value="bool类型,True为正序,False为降序"</param>
        /// <returns></returns>
        public IEnumerable<T> GetAllSort<T>(Dictionary<string, bool> SortDic) where T : class, new()
        {
            IList<ISort> sort = new List<ISort>();
            if (SortDic != null && SortDic.Count > 0)
            {
                foreach (var Dic in SortDic)
                {
                    ISort S = new Sort();
                    S.PropertyName = Dic.Key.ToString();
                    S.Ascending = Dic.Value;
                    sort.Add(S);
                }
            }
            IEnumerable<T> result = DbSession.Connection.GetList<T>(DbSession.DatabaseType, null, sort, null, TimeOut, false);
            if (result == null)
            {
                return Enumerable.Empty<T>();
            }
            return result;
        }

        /// <summary>
        /// 获取全部数据(排序),供业务层调用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SortDic">Key="字段名称",Value="bool类型,True为正序,False为降序"</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllSortAsync<T>(Dictionary<string, bool> SortDic) where T : class, new()
        {
            IList<ISort> sort = new List<ISort>();
            if (SortDic != null && SortDic.Count > 0)
            {
                foreach (var Dic in SortDic)
                {
                    ISort S = new Sort();
                    S.PropertyName = Dic.Key.ToString();
                    S.Ascending = Dic.Value;
                    sort.Add(S);
                }
            }
            IEnumerable<T> result = await DbSession.Connection.GetListAsync<T>(DbSession.DatabaseType, null, sort, null, TimeOut, false);
            if (result == null)
            {
                return Enumerable.Empty<T>();
            }
            return result;
        }

        /// <summary>
        /// 统计记录总数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public int Count<T>(IPredicate predicate, bool buffered = true) where T : class, new()
        {
            return DbSession.Connection.Count<T>(predicate, DbSession.DatabaseType, commandTimeout: TimeOut, transaction: null);
        }

        /// <summary>
        /// 统计记录总数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public async Task<int> CountAsync<T>(IPredicate predicate, bool buffered = true) where T : class, new()
        {
            return await DbSession.Connection.CountAsync<T>(predicate, DbSession.DatabaseType, commandTimeout: TimeOut, transaction: null);
        }

        /// <summary>
        /// 查询列表数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<T> GetList<T>(IPredicate predicate = null, IList<ISort> sort = null, bool buffered = true) where T : class, new()
        {
            IEnumerable<T> result = DbSession.Connection.GetList<T>(DbSession.DatabaseType, predicate, sort, null, TimeOut, buffered);
            if (result == null)
            {
                return Enumerable.Empty<T>();
            }
            return result;
        }

        /// <summary>
        /// 查询列表数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetListAsync<T>(IPredicate predicate = null, IList<ISort> sort = null, bool buffered = true) where T : class, new()
        {
            IEnumerable<T> result = await DbSession.Connection.GetListAsync<T>(DbSession.DatabaseType, predicate, sort, null, TimeOut, buffered);
            if (result == null)
            {
                return Enumerable.Empty<T>();
            }
            return result;
        }

        public T GetFirst<T>(IPredicate predicate = null, IList<ISort> sort = null, bool buffered = true) where T : class, new()
        {
            IEnumerable<T> result = DbSession.Connection.GetList<T>(DbSession.DatabaseType, predicate, sort, null, TimeOut, buffered);
            if (result.Count() > 0)
            {
                return result.FirstOrDefault();
            }
            return default;
        }

        public async Task<T> GetFirstAsync<T>(IPredicate predicate = null, IList<ISort> sort = null, bool buffered = true,IDbTransaction transaction = null) where T : class, new()
        {
            IEnumerable<T> result = await DbSession.Connection.GetListAsync<T>(DbSession.DatabaseType, predicate, sort, transaction, TimeOut, buffered);
            if (result.Count() > 0)
            {
                return result.FirstOrDefault();
            }
            return default;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="allRowsCount"></param>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<T> GetPageList<T>(int pageIndex, int pageSize, out long allRowsCount,
            IPredicate predicate = null, IList<ISort> sort = null, bool buffered = true) where T : class, new()
        {
            if (sort == null)
            {
                sort = new List<ISort>();
            }
            IEnumerable<T> entityList = DbSession.Connection.GetPage<T>(predicate, sort, pageIndex, pageSize, DbSession.DatabaseType, null, TimeOut, buffered);
            allRowsCount = DbSession.Connection.Count<T>(predicate, DbSession.DatabaseType, transaction: null, commandTimeout: TimeOut);
            if (entityList == null)
            {
                return Enumerable.Empty<T>();
            }
            return entityList;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="allRowsCount"></param>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetPageListAsync<T>(int pageIndex, int pageSize,
            IPredicate predicate = null, IList<ISort> sort = null, bool buffered = true) where T : class, new()
        {
            if (sort == null)
            {
                sort = new List<ISort>();
            }
            IEnumerable<T> result = await DbSession.Connection.GetPageAsync<T>(predicate, sort, pageIndex, pageSize, DbSession.DatabaseType, null, TimeOut, buffered);
            if (result == null)
            {
                return Enumerable.Empty<T>();
            }
            return result;
        }

        /// <summary>
        /// 插入单条记录
        /// 注意：此处为动态类型，如果是单一主键，返回主键的字符串，如果为联合主键返回联合主键的IDictionary<string, object>对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public dynamic Insert<T>(T entity, IDbTransaction transaction = null) where T : class, new()
        {
            return DbSession.Connection.Insert<T>(entity, DbSession.DatabaseType, transaction, commandTimeout: TimeOut);
        }

        /// <summary>
        /// 插入单条记录
        /// 注意：此处为动态类型，如果是单一主键，返回主键的字符串，如果为联合主键返回联合主键的IDictionary<string, object>对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<dynamic> InsertAsync<T>(T entity, IDbTransaction transaction = null) where T : class, new()
        {
            return await DbSession.Connection.InsertAsync(entity, DbSession.DatabaseType, transaction, commandTimeout: TimeOut);
        }

        /// <summary>
        /// 更新单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Update<T>(T entity, IDbTransaction transaction = null) where T : class, new()
        {
            return DbSession.Connection.Update(entity, DbSession.DatabaseType, transaction, commandTimeout: TimeOut);
        }

        /// <summary>
        /// 更新单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync<T>(T entity, IDbTransaction transaction = null) where T : class, new()
        {
            return await DbSession.Connection.UpdateAsync<T>(entity, DbSession.DatabaseType, transaction, commandTimeout: TimeOut);
        }

        public async Task<bool> UpdateAsync<T>(Dictionary<string, object> setCollection, Dictionary<string, object> whereCollection, IDbTransaction transaction = null) where T : class, new()
        {
            string sqlUpdate = UpdateSqlGenerate<T>(setCollection, whereCollection);
            return await DbSession.Connection.ExecuteAsync(sqlUpdate, null, transaction) > 0 ? true : false;
        }

        private string UpdateSqlGenerate<T>(Dictionary<string, object> setCollection, Dictionary<string, object> whereCollection) where T : class, new()
        {
            string sql = "UPDATE {0} SET {1} WHERE {2};";
            string tableName = typeof(T).Name;
            StringBuilder set = new StringBuilder();
            StringBuilder where = new StringBuilder();
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (var collection in setCollection)
            {
                if (properties.Any(pro => Equals(pro.Name.ToLower(), collection.Key)))
                {
                    if (collection.Value == null)
                    {
                        set.Append(string.Format("{0}=null", collection.Key) + ",");
                    }
                    else
                    {
                        set.Append(string.Format("{0}='{1}'", collection.Key, collection.Value) + ",");
                    }
                }
            }
            string splitString = " AND ";
            foreach (var collection in whereCollection)
            {
                if (properties.Any(pro => Equals(pro.Name.ToLower(), collection.Key)))
                {
                    where.Append(string.Format("{0}='{1}'", collection.Key, collection.Value) + splitString);
                }
            }
            if (where.ToString().EndsWith(splitString))
            {
                int indexEnd = where.ToString().LastIndexOf(splitString);
                where = where.Remove(indexEnd, splitString.Length);
            }
            return string.Format(sql, tableName, set.ToString().TrimEnd(','), where);
        }

        /// <summary>
        /// 删除单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryId"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int Delete<T>(dynamic primaryId, IDbTransaction transaction = null) where T : class, new()
        {
            var entity = GetById<T>(primaryId);
            var obj = entity as T;
            return DbSession.Connection.Delete(obj, DbSession.DatabaseType, transaction, commandTimeout: TimeOut) == true ? 1 : 0;
        }

        /// <summary>
        /// 删除单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryId"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync<T>(dynamic primaryId, IDbTransaction transaction = null) where T : class, new()
        {
            var entity = await GetByIdAsync<T>(primaryId);
            var obj = entity as T;
            return await DbSession.Connection.DeleteAsync(obj, DbSession.DatabaseType, transaction, commandTimeout: TimeOut) == true ? 1 : 0;
        }

        /// <summary>
        /// 删除单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="transaction"></param>
        /// <returns></returns> 
        public int Delete<T>(IPredicate predicate = null, IDbTransaction transaction = null) where T : class, new()
        {
            return DbSession.Connection.Delete<T>(predicate, DbSession.DatabaseType, transaction, commandTimeout: TimeOut) == true ? 1 : 0;
        }

        /// <summary>
        /// 删除单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="transaction"></param>
        /// <returns></returns> 
        public async Task<int> DeleteAsync<T>(IPredicate predicate = null, IDbTransaction transaction = null) where T : class, new()
        {
            return await DbSession.Connection.DeleteAsync<T>(predicate, DbSession.DatabaseType, transaction, commandTimeout: TimeOut) == true ? 1 : 0;
        }

        /// <summary>
        /// 批量插入功能
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityList"></param>
        /// <param name="transaction"></param>
        public bool InsertBatch<T>(IEnumerable<T> entityList, IDbTransaction transaction = null) where T : class, new()
        {
            return InsertBatchOuterTransaction(entityList, transaction);
        }

        /// <summary>
        /// 批量插入功能
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityList"></param>
        /// <param name="transaction"></param>
        public async Task<bool> InsertBatchAsync<T>(IEnumerable<T> entityList, IDbTransaction transaction = null) where T : class, new()
        {
            return await InsertBatchOuterTransactionAsync(entityList, transaction);
        }

        private bool InsertBatchInnerTransaction<T>(IEnumerable<T> entityList) where T : class, new()
        {
            return DbSession.TransactionHandle(transaction =>
           {
               return InsertBatchTransaction(entityList, transaction);
           });
        }

        private bool InsertBatchTransaction<T>(IEnumerable<T> entityList, IDbTransaction transaction) where T : class, new()
        {
            bool isSuccessful = true;
            foreach (T item in entityList)
            {
                string result = Insert(item, transaction);
                if (string.IsNullOrEmpty(result))
                {
                    isSuccessful = false;
                    break;
                }
            }
            return isSuccessful;
        }

        private async Task<bool> InsertBatchInnerTransactionAsync<T>(IEnumerable<T> entityList) where T : class, new()
        {
            return await DbSession.TransactionHandle(async transaction =>
            {
                return await InsertBatchAsyncTransaction(entityList, transaction);
            });
        }

        private async Task<bool> InsertBatchAsyncTransaction<T>(IEnumerable<T> entityList, IDbTransaction transaction) where T : class, new()
        {
            bool isSuccessful = true;
            foreach (T item in entityList)
            {
                string result = await InsertAsync(item, transaction);
                if (string.IsNullOrEmpty(result))
                {
                    isSuccessful = false;
                    break;
                }
            }
            return isSuccessful;
        }

        private bool InsertBatchOuterTransaction<T>(IEnumerable<T> entityList, IDbTransaction transaction) where T : class, new()
        {
            bool result = false;
            try
            {
                foreach (var item in entityList)
                {
                    Insert(item, transaction);
                }
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        private async Task<bool> InsertBatchOuterTransactionAsync<T>(IEnumerable<T> entityList, IDbTransaction transaction) where T : class, new()
        {
            bool result = false;
            try
            {
                foreach (var item in entityList)
                {
                    await InsertAsync(item, transaction);
                }
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 批量更新（）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityList"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool UpdateBatch<T>(IEnumerable<T> entityList, IDbTransaction transaction = null) where T : class, new()
        {
            bool isSuccessful = true;
            foreach (T entity in entityList)
            {
                isSuccessful = Update(entity, transaction);
                if (!isSuccessful)
                {
                    break;
                }
            }
            return isSuccessful;
        }

        /// <summary>
        /// 批量更新（）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityList"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<bool> UpdateBatchAsync<T>(IEnumerable<T> entityList, IDbTransaction transaction = null) where T : class, new()
        {
            bool isSuccessful = true;
            foreach (T entity in entityList)
            {
                isSuccessful = await UpdateAsync(entity, transaction);
                if (!isSuccessful)
                {
                    break;
                }
            }
            return isSuccessful;
        }

        private bool UpdateBatchInnerTransaction<T>(IEnumerable<T> entityList) where T : class, new()
        {
            return  DbSession.TransactionHandle( transaction =>
            {
                return  UpdateBatch(entityList, transaction);
            });
        }

        private async Task<bool> UpdateBatchInnerTransactionAsync<T>(IEnumerable<T> entityList) where T : class, new()
        {
            return await DbSession.TransactionHandle(async transaction =>
            {
                return await UpdateBatchAsync(entityList, transaction);
            });
        }

        private bool UpdateBatchOuterTransaction<T>(IEnumerable<T> entityList, IDbTransaction transaction) where T : class, new()
        {
            bool result = false;
            try
            {
                foreach (var item in entityList)
                {
                    Update(item, transaction);
                }
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        private async Task<bool> UpdateBatchOuterTransactionAsync<T>(IEnumerable<T> entityList, IDbTransaction transaction) where T : class, new()
        {
            bool result = false;
            try
            {
                foreach (var item in entityList)
                {
                    await UpdateAsync(item, transaction);
                }
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool DeleteBatch<T>(IEnumerable<dynamic> ids, IDbTransaction transaction = null) where T : class, new()
        {
            return DeleteBatchOuterTransaction<T>(ids, transaction);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ids"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBatchAsync<T>(IEnumerable<dynamic> ids, IDbTransaction transaction = null) where T : class, new()
        {
            return await DeleteBatchOuterTransactionAsync<T>(ids, transaction);
        }

        private bool DeleteBatchInnerTransaction<T>(IEnumerable<dynamic> ids) where T : class, new()
        {
            return  DbSession.TransactionHandle( transaction =>
            {
                return DeleteBatchOuterTransaction<T>(ids, transaction);
            });
        }

        private async Task<bool> DeleteBatchInnerTransactionAsync<T>(IEnumerable<dynamic> ids) where T : class, new()
        {
            return await DbSession.TransactionHandle(async transaction =>
            {
                return await DeleteBatchOuterTransactionAsync<T>(ids, transaction);
            });
        }

        private bool DeleteBatchOuterTransaction<T>(IEnumerable<dynamic> ids, IDbTransaction transaction) where T : class, new()
        {
            bool result = false;
            try
            {
                foreach (var id in ids)
                {
                    Delete<T>(id, transaction);
                }
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        private async Task<bool> DeleteBatchOuterTransactionAsync<T>(IEnumerable<dynamic> ids, IDbTransaction transaction) where T : class, new()
        {
            bool result = false;
            try
            {
                foreach (var id in ids)
                {
                    await DeleteAsync<T>(id, transaction);
                }
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        private DbType ConvertTypeToDbType(Type type)
        {
            if (type.Equals(typeof(string)))
                return DbType.String;
            else if (type.Equals(typeof(DateTime)))
                return DbType.DateTime;
            else if (type.Equals(typeof(decimal)))
                return DbType.Decimal;
            else if (type.Equals(typeof(bool)))
                return DbType.Boolean;
            else if (type.Equals(typeof(double)))
                return DbType.Double;
            else if (type.Equals(typeof(Int16)))
                return DbType.Int16;
            else if (type.Equals(typeof(Int32)))
                return DbType.Int32;
            else if (type.Equals(typeof(Int64)))
                return DbType.Int64;
            else if (type.Equals(typeof(Guid)))
                return DbType.Guid;
            else
                return DbType.Object;
        }
    }
}
