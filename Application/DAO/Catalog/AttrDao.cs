using Interface;
using Interface.Catalog;
using ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Catalog
{
    public class AttrDao: BaseDAO, IAttrRepository
    {
        public AttrDao() { }
        public AttrDao(IDataRepository repository) : base(repository) { }
        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }
    }
}
