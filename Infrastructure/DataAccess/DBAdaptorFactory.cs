using System;
using System.Data;
using DataAccess.SqlDBHelper;

namespace DataAccess
{
    public class DBAdaptorFactory
    {
        /// <summary>
        /// 根据IDatabase接口，获取IDBAdaptor
        /// </summary>
        public static IDBAdaptor GetDbAdaptor(DBSessionBase dbSession)
        {
            IDBAdaptor adaptor = null;
            switch (dbSession.DatabaseType)
            {
                case DatabaseType.SqlServer:
                    adaptor = new SqlAdaptor(dbSession.Connection);
                    break;
                case DatabaseType.MySql:
                    //adaptor = new MySqlDBHelper.MySqlAdaptor( database.Connection );
                    break;
                case DatabaseType.Oracle:
                    //adaptor = new OracleDBHelper.OracleAdaptor( database.Connection );
                    break;
                case DatabaseType.DB2:
                    //adaptor = new MySqlDBHelper.MySqlAdaptor( database.Connection );
                    break;
                case DatabaseType.Sqlite:
                    //adaptor = new SqliteDBHelper.SqliteAdaptor( database.Connection );
                    break;
                //case DatabaseType.Postgresql:
                //    adaptor = new PostgreAdaptor(dbSession.Connection);
                //    break;
            }
            return adaptor;
        }
    }
}
