using Interface;
using Interface.Catalog;
using ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Catalog
{
    public class Catalog2Dao: BaseDAO, ICatalog2Repository
    {
        public Catalog2Dao() { }
        public Catalog2Dao(IDataRepository repository) : base(repository) { }
        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }
    }
}
