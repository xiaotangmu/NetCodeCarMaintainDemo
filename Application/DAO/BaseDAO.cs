using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Entity;
using Interface;
using ORM;

namespace DAO
{
    /// <summary>
    /// 数据访问对象层基类
    /// </summary>
    public class BaseDAO : IBaseRepository
    {
        public IDataRepository Repository { get; set; }

        public BaseDAO() : this(null)
        {

        }

        public BaseDAO(IDataRepository repository)
        {
            if (repository == null)
            {
                repository = RepositoryFactory.Singleton.CreateDefault();
            }
            Repository = repository;
        }
    }
}
