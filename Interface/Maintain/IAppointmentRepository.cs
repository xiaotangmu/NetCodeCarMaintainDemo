using DateModel.Maintain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.Maintain;

namespace Interface.Maintain
{
    public interface IAppointmentRepository : IBaseRepository
    {
        Task<int> GetCountByCompanyAndDate(string companyId, DateTime appointmentDate);
        Task<string> Insert(MMS_APPOINTMENT mMS_APPOINTMENT);
        Task<bool> Delete(string id, IDbTransaction transaction = null);
        Task<IEnumerable<AppointmentModel>> SelectAll();
        Task<PageModel<AppointmentModel>> SelectListPageBySearch(AppointmentPageSearchModel model);
        Task<bool> Update(AppointmentModel model, IDbTransaction transaction = null);
    }
}
