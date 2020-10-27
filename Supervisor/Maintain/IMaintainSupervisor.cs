using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.Maintain;

namespace Supervisor.Maintain
{

    public interface IMaintainSupervisor
    {
        Task<string> Add(MaintainAddModel model);
        Task<bool> Update(MaintainModel model);
        Task<bool> Delete(string id);
        Task<bool> DeleteBatch(IEnumerable<AppointmentDeleteModel> modelList);
        Task<IEnumerable<MaintainModel>> GetAll();
        Task<PageModel<MaintainModel>> GetListPageBySearch(MaintainPageSearchModel model);
    }
}
