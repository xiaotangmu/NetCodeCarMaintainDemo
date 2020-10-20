using DataModel;
using Localization;
using Microsoft.AspNetCore.Mvc;
using Supervisor.Spu;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Spu;

namespace WebApi.Controllers.Spu
{
    /// <summary>
    /// 标准产品管理
    /// </summary>
    [SwaggerControllerGroup("Spu", "标准产品管理")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class SpuController : BaseController
    {
        private ISpuSupervisor _spuSupervisor;

        public SpuController(ISpuSupervisor spuSupervisor)
        {
            _spuSupervisor = spuSupervisor;
        }

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(SpuAddModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Catalog2Id) || string.IsNullOrWhiteSpace(model.ProductName))
                {
                    throw new Exception(("数据异常"));
                }
                string result = await _spuSupervisor.Add(model);
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(await Localizer.GetValueAsync("添加SPU：") + model.ProductName);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("添加SPU失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(String Id, String ProductionName)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(Id))
                {
                    throw new Exception(("数据异常"));
                }
                bool result = await _spuSupervisor.Delete(Id);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("删除SPU：") + ProductionName);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("删除SPU失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 更新产品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(SpuModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Catalog2Id) || string.IsNullOrWhiteSpace(model.ProductName) 
                    || string.IsNullOrWhiteSpace(model.Id))
                {
                    throw new Exception(("数据异常"));
                }
                bool result = await _spuSupervisor.Update(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新SPU：") + model.ProductName);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("更新SPU失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 查询产品
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSpuListWithPaging([FromQuery] 
        SpuPageSearchModel model)
        {
            return await ResponseResult(async () =>
            {
                return await _spuSupervisor.GetSpuListWithPaging(model);
            });
        }

        /// <summary>
        /// 获取所有产品分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]BaseSearchModel model)
        {
            return await ResponseResult(async () =>
            {
                return await _spuSupervisor.GetAllWithPaging(model);
            });
        }
    }
}
