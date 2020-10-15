using DAO.Catalog;
using Interface.Catalog;
using Supervisor.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Catalog
{
    /// <summary>
    /// 属性管理
    /// </summary>
    public class AttrSupervisor: BaseBLL, IAttrSupervisor
    {
        private IAttrRepository _attrRepository;
        public AttrSupervisor(IAttrRepository attrRepository = null)
        {
            _attrRepository = InitDAO<AttrDao>(attrRepository) as IAttrRepository;
        }
    }
}
