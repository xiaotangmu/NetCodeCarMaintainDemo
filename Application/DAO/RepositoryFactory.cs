using DataAccess;
using ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public class RepositoryFactory
    {
        private readonly DatabaseType _default_dbType = DatabaseType.SqlServer;
        private const string _default_connection = "SqlServerConnection";

        public static RepositoryFactory Singleton
        {
            get
            {
                return new RepositoryFactory();
            }
        }

        public IDataRepository Create(DbContext context)
        {
            if (context == null)
            {
                return CreateDefault();
            }
            IDBSession session = new DBSessionBase(context.DbType, context.ConnectKey);
            return new RepositoryBase(session);
        }

        public IDataRepository Create(IDBSession session)
        {
            if (session == null)
            {
                return CreateDefault();
            }
            return new RepositoryBase(session);
        }

        public IDataRepository CreateDefault()
        {
            return DefaultRepository();
        }

        private IDataRepository DefaultRepository()
        {
            IDBSession session = new DBSessionBase(_default_dbType, _default_connection);
            return new RepositoryBase(session);
        }
    }
}
