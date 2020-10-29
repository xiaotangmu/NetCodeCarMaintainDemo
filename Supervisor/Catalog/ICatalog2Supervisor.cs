using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Common;

namespace Supervisor.Catalog
{
    public interface ICatalog2Supervisor
    {
        Task<IEnumerable<Catalog2Model>> GetListByCatalog1Id(string catalog1Id);
        Task<bool> Delete(string id);
        Task<bool> Update(Catalog2Model model);
        Task<string> Add(Catalog2AddModel model);
        Task<bool> AddBatch(IEnumerable<Catalog2AddModel> models);
        Task<bool> DeleteBatch(IEnumerable<Catalog2Model> models);
        Task<bool> DeleteListByCatalog1Id(string catalog1Id);
        Task<PageModel<Catalog2Model>> GetCatalog2ListPageBySearch(BaseSearchModel model);
    }
}
