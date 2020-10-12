using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
    public class TransactionImplement : IDbTransaction, IDisposable
    {
        public IDbTransaction Transaction { get; private set; }

        public IDbConnection Connection { get; private set; }

        public IsolationLevel IsolationLevel { get; private set; }

        public IDBAdaptor DbAdaptor { get; private set; }

        public TransactionImplement(IDbConnection connection, IsolationLevel isolationLevel)
        {
            Connection = connection;
            IsolationLevel = isolationLevel;
            Transaction = Connection.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            Transaction.Commit();
            Transaction = null;
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
            {
                if (Transaction != null)
                {
                    Transaction.Rollback();
                    Transaction = null;
                }
                Connection.Close();
                Connection = null;
            }
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            Transaction.Rollback();
            Transaction = null;
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}
