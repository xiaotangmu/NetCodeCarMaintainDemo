using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.Maintain;

namespace Supervisor.Maintain
{
    /// <summary>
    /// </summary>
    public interface IAppointmentSupervisor
    {
        Task<PageModel<AppointmentModel>> GetListPageBySearch(AppointmentPageSearchModel model);
        Task<IEnumerable<AppointmentModel>> GetAll();
        Task<bool> DeleteBatch(IEnumerable<AppointmentDeleteModel> modelList);
        Task<bool> Delete(string id);
        Task<bool> Update(AppointmentModel model);
        Task<string> Add(AppointmentAddModel model);
    }
}
