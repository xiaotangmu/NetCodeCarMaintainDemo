using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.System;
using DataModel.System;
using Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.Swagger.Annotations;
using WebApi.Models.Auth;
using WebApi.Models.Results;
using WebApi.SysFrame.CustomAttribute;

namespace WebApi.Controllers.System
{
    /// <summary>
    /// 资源管理
    /// </summary>
    [SwaggerControllerGroup("System", "ResourceManagement")]
    [Route("[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class ResourceManagementController : BaseController
    {
        public ResourceManagementController() : base()
        {
        }

        [HttpGet]
        [ImmuneApi]
        public async Task<IActionResult> GetSystemMenuTree()
        {
            return await ResponseResult(async () =>
            {
                return await new ResourceManagement().GetMenuTree(GetCurrentUser());
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenuTree()
        {
            return await ResponseResult(async () =>
            {
                return await new ResourceManagement().GetMenuTree();
            });
        }

        /// <summary>
        /// 增加菜单
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddMenu(AddMenuModel model)
        {
            return await ResponseResult(async () =>
            {
                string result = await new ResourceManagement().AddMenu(model, GetCurrentUser());
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(await Localizer.GetValueAsync("新增菜單") + model.MenuCode);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 更新菜单
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateMenu(AddMenuModel model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await new ResourceManagement().UpdateMenu(model, GetCurrentUser());
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("UpdateResource") + model.MenuCode);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> DeleteMenu(DeleteMenuModel model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await new ResourceManagement().DeleteResource(model.MenuCode);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("DeleteResource") + model.MenuCode);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 新增
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddResource(AddResourceModel model)
        {
            return await ResponseResult(async () =>
            {
                string result = await new ResourceManagement().AddResource(model, GetCurrentUser());
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(await Localizer.GetValueAsync("AddResource") + model.ResourceCode);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 更新资源
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> UpdateResource(UpdateResourceModel model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await new ResourceManagement().UpdateResource(model, GetCurrentUser());
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("UpdateResource") + model.ResourceCode);
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
        public async Task<IActionResult> DeleteResource(DeleteResourceModel model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await new ResourceManagement().DeleteResource(model.ResourceCode);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("DeleteResource") + model.ResourceCode);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetResourceGroupWithPaging([FromQuery]ResourceSearchConditionModel model)
        {
            return await ResponseResult(async () =>
            {
                return await new ResourceManagement().GetResourcePageList(model);
            });
        }
    }
}