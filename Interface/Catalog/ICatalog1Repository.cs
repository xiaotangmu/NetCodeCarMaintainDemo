using DateModel.Catalog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Catalog;

namespace Interface.Catalog
{
    public interface ICatalog1Repository : IBaseRepository
    {
        Task<string> InsertAsync(BMMS_CATALOG1 entity, IDbTransaction transaction = null);
        Task<bool> UpdateAsync(BMMS_CATALOG1 entity, IDbTransaction transaction = null);
        Task<bool> DeleteAsync(string id, IDbTransaction transaction = null);
        Task<IEnumerable<Catalog1Model>> SelectAllAsync();
        Task<bool> InsertBatchAsync(IEnumerable<BMMS_CATALOG1> entities, IDbTransaction transaction = null);
        Task<bool> DeleteBatch(IEnumerable<string> ids, IDbTransaction transaction);
    }
}
