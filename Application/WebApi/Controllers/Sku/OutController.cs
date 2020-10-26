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
    /// 出库管理
    /// </summary>
    [SwaggerControllerGroup("OutStock", "出库管理")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class OutController : BaseController
    {
        private IOutSupervisor _outSupervisor;
        public OutController(IOutSupervisor outSupervisor)
        {
            _outSupervisor = outSupervisor;
        }

        /// <summary>
        /// 添加出库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(OutAddModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Operator))
                {
                    throw new MyServiceException("操作人员为空");
                }
                if (model.OutDate == null || model.OutDate > DateTime.Now || model.OutDate.Year < 1900)
                {
                    throw new MyServiceException("出库时间异常");
                }
                if (model.Batch < 1)
                {
                    throw new MyServiceException("批次异常");
                }
                if (model.outSkuList == null || model.outSkuList.Count() < 1)
                {
                    throw new MyServiceException("请先选择库存");
                }
                // 生成出库单号 年月日+客户+批次：2012020300101
                model.OutNo = string.Format("{0:yyyyMMdd}", model.OutDate) + model.ClientId.PadLeft(3, '0') + model.Batch.ToString().PadLeft(2, '0');
                string result = await _outSupervisor.Add(model);
                if (!string.IsNullOrEmpty(result))
                {
                    
                    await LogOperation(await Localizer.GetValueAsync("添加出库单：") + model.OutNo);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("添加出库单失败"));
                }
                return result;
            });
        }
        /// <summary>
        /// 备注出库单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RemarkEntry(string OutId, string Description)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(OutId))
                {
                    throw new MyServiceException(("数据异常"));
                }
                bool result = await _outSupervisor.UpdateDescription(OutId, Description);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("备注出库单 : ID：") + OutId);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("备注出库单失败或没有该出库单"));
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
                return await _outSupervisor.GetAll();
            });
        }

        /// <summary>
        /// 条件查询/模糊查询 -- 分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListPageBySearch([FromQuery] OutPageSearchModel model)
        {
            return await ResponseResult(async () =>
            {
                if (model.PageIndex < 1 || model.PageIndex < 1)
                {
                    throw new MyServiceException(("提交的数据有误"));
                }
                return await _outSupervisor.GetListPageBySearch(model);
            });
        }
        /// <summary>
        /// 删除出库
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(string Id, string OutNo)
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                throw new MyServiceException("提交的数据异常");
            }
            return await ResponseResult(async () =>
            {
                bool result = await _outSupervisor.Delete(Id);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("删除出库单：") + OutNo);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("删除出库单失败"));
                }
                return result;
            });
        }
        /// <summary>
        /// 批量删除出库
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteBatch(IEnumerable<OutDeleteModel> modelList)
        {
            if (modelList == null || modelList.Count() == 0)
            {
                throw new MyServiceException("提交的数据异常");
            }
            return await ResponseResult(async () =>
            {
                bool result = await _outSupervisor.DeleteBatch(modelList);
                if (result)
                {
                    foreach (var model in modelList)
                    {
                        await LogOperation(await Localizer.GetValueAsync("删除出库单：") + model.OutNo);
                    }
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("删除出库单失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 更新整个出库单,除了出库单号
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(OutUpdateModel model)
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
                if (model.OutDate == null || model.OutDate > DateTime.Now || model.OutDate.Year < 1900)
                {
                    throw new MyServiceException("出库时间异常");
                }

                if (model.outSkuList == null || model.outSkuList.Count() < 1)
                {
                    throw new MyServiceException("库存为空");
                }

                bool result = await _outSupervisor.Update(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新盘点单：") + model.EntryNo);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("更新盘点单失败"));
                }
                return result;
            });
        }
    }
}
