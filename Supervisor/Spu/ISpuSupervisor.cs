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
        Task<IEnumerable<SpuModel>> GetSpuListWithPaging(SpuPageSearchModel model);
        Task<IEnumerable<SpuModel>> GetAllWithPaging(BaseSearchModel model);
    }
}
