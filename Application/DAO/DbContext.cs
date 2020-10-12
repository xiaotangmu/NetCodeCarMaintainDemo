using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public abstract class DbContext
    {
        public DatabaseType DbType { get; private set; }

        public string ConnectKey { get; private set; }

        public DbContext(DatabaseType type, string connection)
        {
            DbType = type;
            ConnectKey = connection;
        }
    }

    public class PostgresqlContext : DbContext
    {
        public PostgresqlContext() : base(DatabaseType.Postgresql, "SqlServerConnection")
        {
        }
    }
}
