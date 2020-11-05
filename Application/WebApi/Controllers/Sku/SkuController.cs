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
using ViewModel.CustomException;
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
        /// 添加库存, 库存名（冗余）也要提交，方便后面操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(SkuAddModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Catalog2Id) || string.IsNullOrWhiteSpace(model.SpuId) 
                    || string.IsNullOrWhiteSpace(model.SkuName))
                {
                    throw new MyServiceException(("数据异常"));
                }
                string result = await _skuSupervisor.Add(model);
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(await Localizer.GetValueAsync("添加库存：") + model.SkuName);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("添加库存失败"));
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
        public async Task<IActionResult> Delete(string SkuId, string SkuName)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(SkuId))
                {
                    throw new MyServiceException(("数据异常"));
                }
                bool result = await _skuSupervisor.Delete(SkuId);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("删除库存：") + SkuName);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("删除库存失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 更新库存, 只更新库存属性, 不更新库存名等（Spu关联）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(SkuModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Id))
                {
                    throw new MyServiceException(("数据异常"));
                }
                bool result = await _skuSupervisor.Update(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新库存：") + model.SkuName);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("更新库存失败"));
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
                if ( model.PageIndex < 1 || model.PageSize < 1)
                {
                    throw new MyServiceException(("提交的数据有误"));
                }
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
                if ( model.PageIndex < 1 || model.PageIndex < 1)
                {
                    throw new MyServiceException(("提交的数据有误"));
                }
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
