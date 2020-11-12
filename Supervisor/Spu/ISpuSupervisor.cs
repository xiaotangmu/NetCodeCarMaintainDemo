using DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Spu;

namespace Supervisor.Spu
{
    public interface ISpuSupervisor
    {
        Task<string> Add(SpuAddModel model);
        Task<bool> Delete(string id);
        Task<bool> Update(SpuModel model);
        Task<SpuListWithPagingModel> GetSpuListWithPaging(SpuPageSearchModel model);
        Task<SpuListWithPagingModel> GetAllWithPaging(BaseSearchModel model);
        Task<IEnumerable<SpuModel>> GetAll();
        Task<IEnumerable<SpuModel>> GetListByCatalog2Id(string Catalog2Id);
        Task<IEnumerable<SpuAttrModel>> GetSpuAttrListBySpuId(string spuId);
        Task<SpuModel> GetSpuById(string id);
    }
}
