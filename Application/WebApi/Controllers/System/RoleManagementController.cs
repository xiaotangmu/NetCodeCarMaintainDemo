using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.System;
using DataModel;
using DataModel.System;
using Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Supervisor.System;
using Swashbuckle.Swagger.Annotations;
using WebApi.Models.Auth;
using WebApi.Models.Results;

namespace WebApi.Controllers.System
{
    /// <summary>
    /// 角色管理
    /// </summary>
    [SwaggerControllerGroup("System", "RoleManagement")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class RoleManagementController : BaseController
    {
        private readonly IRoleSupervisor _roleSupervisor;
        private readonly IPermissionSupervisor _permissionSupervisor;

        public RoleManagementController(IRoleSupervisor roleSupervisor, IPermissionSupervisor permissionSupervisor) : base()
        {
            _roleSupervisor = roleSupervisor;
            _permissionSupervisor = permissionSupervisor;
        }

        /// <summary>
        /// 角色查询
        /// Create by Xavier
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetRoleGroupWithPaging([FromQuery]BaseSearchModel model)
        {
            return await ResponseResult(async () =>
            {
                return await new RoleManagement().GetPageList(model);
            });
        }

        /// <summary>
        /// 获取所有有效角色
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetValidRoleGroup()
        {
            return await ResponseResult(async () =>
            {
                return await new RoleManagement().GetValidRoles();
            });
        }

        /// <summary>
        /// 新增角色
        /// Create by Xavier
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleModel Role)
        {
            return await ResponseResult(async () =>
            {
                string roleId = await new RoleManagement().Add(Role);
                if (!string.IsNullOrEmpty(roleId))
                {
                    await LogOperation(await Localizer.GetValueAsync("CreateRole") + Role.RoleCode);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return roleId;
            });
        }

        /// <summary>
        /// 角色编辑
        /// Create by Xavier
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleModel Role)
        {
            return await ResponseResult(async () =>
            {
                bool result = await new RoleManagement().Edit(Role);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("UpdateRole") + Role.RoleCode);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 角色删除
        /// Create by Xavier
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteRoleViewModel Model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await new RoleManagement().Delete(Model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("DeleteRole") + Model.RoleCode);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 角色管理—角色授权—菜单权限查询
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetPermissionTree(string RoleCode)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrEmpty(RoleCode))
                {
                    throw new Exception("請選擇角色");
                }
                return await _permissionSupervisor.GetAuthorityModelGroup(new ResourceSearchConditionModel
                {
                    ResourceType = ResourceType.MENU
                }, RoleCode);
            });
        }

        /// <summary>
        /// 角色管理—角色授权—保存
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SavePermissionTree(SelectedRolePermissionModel Model)
        {
            return await ResponseResult(async () =>
            {
                var result = await new RoleManagement().SaveAuthority(Model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("AuthorizeRole") + Model.RoleCode);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 角色启用/禁用
        /// Create by Xavier
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> EnableRole(RoleStatus Model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await new RoleManagement().ChangeState(Model.IsUse, Model.RoleCode);
                if (result)
                {
                    if (Model.IsUse)
                    {
                        await LogOperation(await Localizer.GetValueAsync("EnableRole") + Model.RoleCode);
                    }
                    else
                    {
                        await LogOperation(await Localizer.GetValueAsync("DisableRole") + Model.RoleCode);
                    }
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