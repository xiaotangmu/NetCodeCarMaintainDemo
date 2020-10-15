using DateModel.Catalog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Catalog;

namespace Interface.Catalog
{
    public interface ICatalog2Repository : IBaseRepository
    {
        Task<string> Insert(BMMS_CATALOG2 entity, IDbTransaction tran = null);
        Task<bool> Delete(string id, IDbTransaction tran = null);
        Task<IEnumerable<Catalog2Model>> SelectListByCatalog1Id(string catalog1Id);
        Task<bool> Update(BMMS_CATALOG2 entity, IDbTransaction tran = null);
        Task<bool> DeleteListByCatalog1Id(string catalog1Id, IDbTransaction transaction = null);
        Task<bool> DeleteBatch(IEnumerable<string> ids, IDbTransaction transaction = null);
        Task<bool> InsertBatch(IEnumerable<BMMS_CATALOG2> enumerable, IDbTransaction transaction = null);
    }
}
