using DateModel.Catalog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Catalog;

namespace Interface.Catalog
{
    public interface IAttrRepository : IBaseRepository   // IBaseRepository 用于初始化InitDAO
    {
        Task<string> Add(BMMS_CATALOG_ATTR entity, IDbTransaction tran = null);
        Task<bool> Delete(string id, IDbTransaction tran = null);
        Task<IEnumerable<AttrModel>> SelectListByCatalogId(string catalogId);
        Task<bool> Update(BMMS_CATALOG_ATTR entity, IDbTransaction tran = null);
        Task<bool> DeleteBatch(IEnumerable<string> ids, IDbTransaction tran = null);
        Task<bool> InsertBatch(IEnumerable<BMMS_CATALOG_ATTR> enumerable, IDbTransaction tran = null);
        Task<bool> DeleteAttrListByCatalog(string catalogId, IDbTransaction tran = null);
    }
}
