using Interface.Maintain;
using ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Maintain
{
    public class MaintainDao : BaseDAO, IMaintainRepository
    {
        public MaintainDao() { }
        public MaintainDao(IDataRepository repository) : base(repository) { }

        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }
    }
}
