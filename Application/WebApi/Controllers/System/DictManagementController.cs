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

namespace WebApi.Controllers.System
{
    /// <summary>
    /// 字典管理
    /// </summary>
    [SwaggerControllerGroup("System", "DictManagement")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class DataDictController : BaseController
    {
        public DataDictController() : base()
        {
        }

        /// <summary>
        /// 字典查詢
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetPageList([FromQuery]DictSearchPageModel SearchModel)
        {
            return await ResponseResult(async () =>
            {
                return await new DictManagement().GetPageList(SearchModel);
            });
        }

        /// <summary>
        /// 獲取字典項子集
        /// Create by Xavier
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDicts([FromQuery]DictSearchPageModel SearchModel)
        {
            return await ResponseResult(async () =>
            {
                return await new DictManagement().GetChildren(SearchModel);
            });
        }

        /// <summary>
        /// 新增字典
        /// Create by Xavier
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Add(AddDictModel Model)
        {
            return await ResponseResult(async () =>
            {
                string result = await new DictManagement().Add(Model);
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(await Localizer.GetValueAsync("Dict_Create") + Model.DictCode);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 编辑
        /// Create by Xavier
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(AddDictModel Model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await new DictManagement().Edit(Model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("UpdateDict") + Model.DictCode);
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
        public async Task<IActionResult> Delete(DeleteDictModel Model)
        {

            return await ResponseResult(async () =>
            {
                bool result = await new DictManagement().Delete(Model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("Dict_Delete") + Model.DictCode);
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