using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supervisor.Sku;
using Swashbuckle.Swagger.Annotations;
using ViewModel.CustomException;
using ViewModel.Sku;

namespace WebApi.Controllers.Sku
{
    /// <summary>
    /// 盘点管理
    /// </summary>
    [SwaggerControllerGroup("Check", "盘点管理")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class CheckController : BaseController
    {
        private ICheckSupervisor _checkSupervisor;

        public CheckController(ICheckSupervisor checkSupervisor)
        {
            _checkSupervisor = checkSupervisor;
        }

        /// <summary>
        /// 添加盘点
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CheckAddModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Operator))
                {
                    throw new MyServiceException("操作人员为空");
                }
                if (model.CheckDate == null || model.CheckDate > DateTime.Now || model.CheckDate.Year < 1900)
                {
                    throw new MyServiceException("盘点时间异常");
                }
                
                if (model.checkSkuAddList == null || model.checkSkuAddList.Count() < 1)
                {
                    throw new MyServiceException("添加的库存为空");
                }
                // 生成盘点单号：年月日+ 操作员
                model.CheckNo = string.Format("{0:yyyyMMdd}", model.CheckDate) + model.Operator.PadLeft(3, '0');
                string result = await _checkSupervisor.Add(model);
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(await Localizer.GetValueAsync("添加盘点单：") + model.CheckNo);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("添加盘点单失败"));
                }
                return result;
            });
        }
        /// <summary>
        /// 更新备注和状态，针对单个或多个库存
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(IEnumerable<CheckUpdateModel> modelList)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _checkSupervisor.UpdateCheckSkuStatus(modelList);
                if (result)
                {
                    foreach (var model in modelList)
                    {
                        await LogOperation(await Localizer.GetValueAsync("更新盘点单SKU单个状态：") + model.Id);
                    } 
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("更新盘点单失败"));
                }
                return result;
            });
        }
        /// <summary>
        /// 一键处理，处理盘点单全部标记
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateAllStatus(CheckUpdateModel model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _checkSupervisor.UpdateAllStatus(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新盘点单全部状态：") + model.Id);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("更新盘点单失败"));
                }
                return result;
            });
        }
        /// <summary>
        /// 删除盘点
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(string Id, string CheckNo)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(Id))
                {
                    throw new MyServiceException("提交的数据异常");
                }
                bool result = await _checkSupervisor.Delete(Id);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("删除盘点单：") + CheckNo);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("删除盘点单失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 批量删除盘点
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteBatch(IEnumerable<CheckDeleteModel> modelList)
        {
            return await ResponseResult(async () =>
            {
                if (modelList == null || modelList.Count() == 0)
                {
                    throw new MyServiceException("提交的数据异常");
                }
                bool result = await _checkSupervisor.DeleteBatch(modelList);
                if (result)
                {
                    foreach (var model in modelList)
                    {
                        await LogOperation(await Localizer.GetValueAsync("删除盘点单：") + model.CheckNo);
                    }
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("删除盘点单失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 更新整个盘点单,除了盘点单号
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(CheckWholeUpdateModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Operator))
                {
                    throw new MyServiceException("操作人员为空");
                }
                if (string.IsNullOrWhiteSpace(model.Id))
                {
                    throw new MyServiceException("数据异常");
                }
                if (model.CheckDate == null || model.CheckDate > DateTime.Now || model.CheckDate.Year < 1900)
                {
                    throw new MyServiceException("盘点时间异常");
                }

                if (model.checkSkuAddList == null || model.checkSkuAddList.Count() < 1)
                {
                    throw new MyServiceException("库存为空");
                }

                bool result = await _checkSupervisor.Update(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新盘点单：") + model.CheckNo);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("更新盘点单失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 获取所有,不分页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await ResponseResult(async () =>
            {
                return await _checkSupervisor.GetAll();
            });
        }
        /// <summary>
        /// 条件查询，D差错查询:0不开启,1差,2无差-Status处理查询(0 - 处理,1 - 未处理), 分页,条件为空时，查询所有
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListPageBySearch([FromQuery] CheckPageSearchModel model)
        {
            return await ResponseResult(async () =>
            {
                if (model.PageIndex < 1 || model.PageIndex < 1)
                {
                    throw new MyServiceException(("提交的数据有误"));
                }
                return await _checkSupervisor.GetListPageBySearch(model);
            });
        }

    }
}
