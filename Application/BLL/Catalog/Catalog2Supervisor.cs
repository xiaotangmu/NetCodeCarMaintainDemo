using DAO.Catalog;
using Interface.Catalog;
using Supervisor.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Catalog
{
    /// <summary>
    /// 二级分类
    /// </summary>
    public class Catalog2Supervisor: BaseBLL, ICatalog2Supervisor
    {
        private ICatalog2Repository _catalog2Dao;
        public Catalog2Supervisor(ICatalog2Repository catalog2Repository = null)
        {
            _catalog2Dao = InitDAO<Catalog2Dao>(catalog2Repository) as ICatalog2Repository;
        }
    }
}
