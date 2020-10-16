using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel;
using Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.Util;
using Supervisor.Sku;
using Swashbuckle.Swagger.Annotations;
using ViewModel.Sku;

namespace WebApi.Controllers.Sku
{
    /// <summary>
    /// 库存管理
    /// </summary>
    [SwaggerControllerGroup("Sku", "库存管理")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class SkuController : BaseController
    {
        private ISkuSupervisor _skuSupervisor;
        public SkuController(ISkuSupervisor skuSupervisor) : base()
        {
            _skuSupervisor = skuSupervisor;
        }

        /// <summary>
        /// 添加库存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(SkuAddModel model)
        {
            return await ResponseResult(async () =>
            {
                string result = await _skuSupervisor.Add(model);
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(await Localizer.GetValueAsync("添加库存：") + model.SkuName);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("添加库存失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(SkuModel model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _skuSupervisor.Delete(model.Id);
                if (!result)
                {
                    await LogOperation(await Localizer.GetValueAsync("删除库存：") + model.SkuName);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("删除库存失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 更新库存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(SkuModel model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _skuSupervisor.Update(model);
                if (!result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新库存：") + model.SkuName);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("更新库存失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 条件查询/模糊查询 -- 不分页
        /// </summary>
        /// <param name="SearchStr"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListBySearch(string SearchStr)
        {
            return await ResponseResult(async () =>
            {
                return await _skuSupervisor.GetListBySearch(SearchStr);
            });
        }

        /// <summary>
        /// 条件查询/模糊查询 -- 分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListPageBySearch([FromQuery] SkuListSearchModel model)
        {
            return await ResponseResult(async () =>
            {
                return await _skuSupervisor.GetListPageBySearch(model);
            });
        }

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListPage([FromQuery] BaseSearchModel model)
        {
            return await ResponseResult(async () =>
            {
                return await _skuSupervisor.GetListPage(model);
            });
        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await ResponseResult(async () =>
            {
                return await _skuSupervisor.GetAll();
            });
        }
    }
}
