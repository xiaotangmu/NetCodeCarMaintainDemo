using DataModel.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supervisor.System
{
    public interface IPermissionSupervisor
    {
        Task<string> Add(PermissionAddModel model, CurrentUserInfo userInfo);
        Task<bool> BindResources(AllocateResourceModel model);
        Task<bool> Delete(string code);
        Task<bool> Edit(PermissionUpdateModel model, CurrentUserInfo userInfo);
        Task<IEnumerable<PermissionTreeModel>> GetAuthorityModelGroup(ResourceSearchConditionModel resourceSearchModel, string roleCode = null);
        Task<PermissionPageViewModel> GetPageList(PermissionPageSearchModel searchModel);
    }
}
