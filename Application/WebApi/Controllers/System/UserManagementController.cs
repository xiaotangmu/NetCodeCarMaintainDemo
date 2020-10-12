using System;
using System.Threading.Tasks;
using BLL.System;
using DataModel.System;
using Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supervisor.System;
using Swashbuckle.Swagger.Annotations;

namespace WebApi.Controllers.System
{
    /// <summary>
    /// 用户管理
    /// </summary>
    [SwaggerControllerGroup("System", "UserManagement")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserManagementController : BaseController
    {
        private readonly IUserSupervisor _userSupervisor;

        public UserManagementController(IUserSupervisor userSupervisor) : base()
        {
            _userSupervisor = userSupervisor;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUser(UserModel Data)
        {
            return await ResponseResult(async () =>
            {
                string result = await _userSupervisor.AddUser(Data, GetCurrentUser());
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(await Localizer.GetValueAsync("CreateUser") + Data.Account);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 根据用户编码，用户名称获取用户信息
        /// </summary>
        /// <param name="SearchModel">搜索模型</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserGroupWithPaging([FromQuery]UserSearchModel SearchModel)
        {
            return await ResponseResult(async () =>
            {
                return await _userSupervisor.QueryPageAsync(SearchModel);
            });
        }

        /// <summary>
        /// 启用用户
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EnableUser(DeleteUserModel User)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _userSupervisor.EnableUser(User);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("EnableUser") + User.Account);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 停用用户
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DisableUser(DeleteUserModel User)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _userSupervisor.DisableUser(User);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("DisableUser") + User.Account);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteUserModel model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _userSupervisor.DeleteUser(model.Account);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("刪除用戶：") + model.Account);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("刪除失敗"));
                }
                return result;
            });
        }

        /// <summary>
        /// 根据用户Code获取所属角色
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserRoles(string Account)
        {
            return await ResponseResult(async () =>
            {
                return await _userSupervisor.GetRoles(Account);
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetValidUserGroup()
        {
            return await ResponseResult(async () =>
            {
                return await _userSupervisor.GetValidUserGroup();
            });
        }

        /// <summary>
        /// 设置用户角色信息，批量操作
        /// </summary>
        /// <param name="Model">参数模型</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AllocateRolesToUser(ModifyUserRoleModel Model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _userSupervisor.ModifyUserRoles(Model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("AllocateRoleToUser") + Model.Account);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }
    }
}