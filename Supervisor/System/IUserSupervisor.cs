using DataModel.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supervisor.System
{
    public interface IUserSupervisor
    {
        Task<string> AddUser(UserModel data, CurrentUserInfo userInfo);
        Task<bool> DeleteUser(string account);
        Task<bool> DisableUser(DeleteUserModel model);
        Task<bool> EnableUser(DeleteUserModel model);
        Task<List<RoleModel>> GetRoles(string loginName);
        Task<List<UserModel>> GetValidUserGroup();
        Task<bool> IsExitsUser(UserModel user);
        Task<bool> ModifyUserRoles(ModifyUserRoleModel model);
        Task<UserPageViewModel> QueryPageAsync(UserSearchModel model);
    }
}
