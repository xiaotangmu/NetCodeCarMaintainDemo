using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supervisor.Sku;
using Swashbuckle.Swagger.Annotations;
using ViewModel.Sku;

namespace WebApi.Controllers.Sku
{
    /// <summary>
    /// 入库管理
    /// </summary>
    [SwaggerControllerGroup("EntryStock", "入库管理")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class EntryController : BaseController
    {
        private IEntrySupervisor _entrySupervisor;
        public EntryController(IEntrySupervisor entrySupervisor)
        {
            _entrySupervisor = entrySupervisor;
        }

        /// <summary>
        /// 添加入库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(EntryAddModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Operator) || string.IsNullOrWhiteSpace(model.SupplierId)
                    || model.EntryDate == null || model.EntryDate > new DateTime() || model.Batch < 1
                    || model.entrySkuList == null || model.entrySkuList.Count() < 1)
                {
                    throw new Exception(("数据异常"));
                }
                string result = await _entrySupervisor.Add(model);
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(await Localizer.GetValueAsync("添加入库单：供应商：") + model.SupplierId);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("添加入库单失败"));
                }
                return result;
            });
        }
        /// <summary>
        /// 备注入库单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RemarkEntry(string EntryId, string Description)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(EntryId))
                {
                    throw new Exception(("数据异常"));
                }
                bool result = await _entrySupervisor.UpdateDescription(EntryId);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("备注入库单：") + EntryId);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("备注入库单"));
                }
                return result;
            });
        }
        /// <summary>
        /// 获取所有 -- 不分页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await ResponseResult(async () =>
            {
                return await _entrySupervisor.GetAll();
            });
        }

        /// <summary>
        /// 条件查询/模糊查询 -- 分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListPageBySearch([FromQuery] EntryPageSearchModel model)
        {
            return await ResponseResult(async () =>
            {
                if (model.PageIndex < 1 || model.PageIndex < 1)
                {
                    throw new Exception(("提交的数据有误"));
                }
                return await _entrySupervisor.GetListPageBySearch(model);
            });
        }

    }
}
