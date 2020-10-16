using DataModel;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Sku;

namespace Supervisor.Sku
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISkuSupervisor
    {
        Task<string> Add(SkuAddModel model);
        Task<bool> Delete(string id);
        Task<bool> Update(SkuModel model);
        Task<IEnumerable<SkuModel>> GetListBySearch(string searchStr);
        Task<IEnumerable<SkuModel>> GetListPageBySearch(SkuListSearchModel model);
        Task<IEnumerable<SkuModel>> GetListPage(BaseSearchModel model);
        Task<IEnumerable<SkuModel>> GetAll();
    }
}
