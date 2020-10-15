using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Catalog;

namespace Supervisor.Catalog
{
    public interface IAttrSupervisor
    {
        Task<string> Add(AttrAddModel model);
        Task<IEnumerable<AttrModel>> GetListByCatalogId(string catalogId);
        Task<bool> Update(AttrModel model);
        Task<bool> Delete(string id);
        Task<bool> DeleteBatch(IEnumerable<AttrModel> models);
        Task<bool> AddBatch(IEnumerable<AttrAddModel> models);
        Task<bool> DeleteAttrListByCatalog(string CatalogId);
    }
}
