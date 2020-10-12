using System;
using System.Configuration;
using System.Data;
using System.Reflection;

namespace DataAccess
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DatabaseType
    {
        SqlServer,
        MySql,
        Oracle,
        DB2,
        Sqlite,
        Postgresql
    }

    public class SqlConnectionFactory
    {
        /// <summary>
        /// 根据数据库类型和配置文件字符串获取连接；主要针对Dapper使用
        /// </summary>
        public static IDbConnection CreateSqlConnection(DatabaseType dbType, string strKey)
        {
            //App.config配置文件要么使用xml，要么将配置写入调用此类库的config文件中
            Configuration config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            string strConn = config.ConnectionStrings.ConnectionStrings[strKey].ConnectionString;
            return BuildConnection(dbType, strConn);
        }

        /// <summary>
        /// 创建数据库连接对象
        /// </summary>
        /// <param name="type">数据库类型枚举</param>
        /// <param name="connectionString">完整的数据连接字符串</param>
        /// <returns></returns>
        public static IDbConnection CreateConnection(DatabaseType type, string connectionString)
        {
            return BuildConnection(type, connectionString);
        }

        private static IDbConnection BuildConnection(DatabaseType type, string strConn)
        {
            IDbConnection connection = null;
            switch (type)
            {
                case DatabaseType.SqlServer:
                    connection = new System.Data.SqlClient.SqlConnection(strConn);
                    break;
                case DatabaseType.MySql:
                    //connection = new MySql.Data.MySqlClient.MySqlConnection(strConn);
                    break;
                case DatabaseType.Oracle:
                    //connection = new Oracle.ManagedDataAccess.Client.OracleConnection(strConn);
                    //connection = new System.Data.OracleClient.OracleConnection(strConn);
                    break;
                case DatabaseType.DB2:
                    //connection = new System.Data.OleDb.OleDbConnection(strConn);
                    break;
                case DatabaseType.Sqlite:
                    //connection = new System.Data.SQLite.SQLiteConnection( strConn );
                    break;
                case DatabaseType.Postgresql:
                    connection = new Npgsql.NpgsqlConnection(strConn);
                    break;
            }

            if (connection == null)
            {
                throw new System.Exception("数据库链接为空！");
            }

            return connection;
        }
    }
}
