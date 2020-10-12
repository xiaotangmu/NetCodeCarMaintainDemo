using DataModel;
using DataModel.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supervisor.System
{
    public interface IRoleSupervisor
    {
        Task<string> Add(RoleModel role);
        Task<bool> ChangeState(bool isUsing, string roleCode);
        Task<bool> Delete(DeleteRoleViewModel role);
        Task<bool> Edit(RoleModel role);
        Task<RoleModel> Get(string roleId);
        Task<RolePageViewModel> GetPageList(BaseSearchModel searchCondition);
        Task<string> GetRoleId(string roleCode);
        Task<IEnumerable<RoleViewModel>> GetValidRoles();
        Task<bool> SaveAuthority(SelectedRolePermissionModel roleMenu);
    }
}
