using System;
using System.Text;
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
    /// 权限管理
    /// </summary>
    [SwaggerControllerGroup("System", "PermissionManagement")]
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PermissionManagementController : BaseController
    {
        private readonly IPermissionSupervisor _permissionSupervisor;
        private readonly IResourceSupervisor _resourceSupervisor;
        public PermissionManagementController(IPermissionSupervisor permissionSupervisor,IResourceSupervisor resourceSupervisor) : base()
        {
            _permissionSupervisor = permissionSupervisor;
            _resourceSupervisor = resourceSupervisor;
        }

        [HttpGet]
        public async Task<IActionResult> GetPermissionGroupWithPaging([FromQuery]PermissionPageSearchModel Model)
        {
            return await ResponseResult(async () =>
            {
                return await _permissionSupervisor.GetPageList(Model);
            });
        }

        /// <summary>
        /// 新增
        /// Create by Xavier
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddPermission(PermissionAddModel Model)
        {
            return await ResponseCreateResult(async () =>
            {
                return await _permissionSupervisor.Add(Model, GetCurrentUser());
            }, await Localizer.GetValueAsync("AddPermission") + Model.PermissionCode);
        }

        /// <summary>
        /// 编辑
        /// Create by Xavier
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdatePermission(PermissionUpdateModel Model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _permissionSupervisor.Edit(Model, GetCurrentUser());
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("UpdatePermission") + Model.PermissionCode);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 删除
        /// Create by Xavier
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> DeletePermission(PermissionDeleteModel Model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _permissionSupervisor.Delete(Model.PermissionCode);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("DeletePermission") + Model.PermissionCode);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 获取资源树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetResourceTree(string PermissionCode)
        {
            return await ResponseResult(async () =>
            {
                return await _resourceSupervisor.GetResourceTree(PermissionCode);
            });
        }

        [HttpPost]
        public async Task<IActionResult> AllocateResourcesToPermission(AllocateResourceModel Model)
        {
            return await ResponseResult(async () =>
            {

                bool result = await _permissionSupervisor.BindResources(Model);
                if (result)
                {
                    StringBuilder log = new StringBuilder();
                    log.Append(await Localizer.GetValueAsync("BindResources"));
                    log.Append(",");
                    log.Append(Model.PermissionCode);
                    await LogOperation(log.ToString());
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