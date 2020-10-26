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
    /// 入库管理
    /// </summary>
    [SwaggerControllerGroup("Entry", "入库管理")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class EntryController : BaseController
    {
        private IEntrySupervisor _entrySupervisor;

        public EntryController(IEntrySupervisor entrySupervisor) : base()
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
                if (string.IsNullOrWhiteSpace(model.Operator) || string.IsNullOrWhiteSpace(model.SupplierId))
                {
                    throw new MyServiceException("操作人员或供应商为空");
                }
                if (model.EntryDate == null || model.EntryDate > DateTime.Now || model.EntryDate.Year < 1900)
                {
                    throw new MyServiceException("入库时间异常");
                }
                if(model.Batch < 1)
                {
                    throw new MyServiceException("批次异常");
                }
                if(model.entrySkuList == null || model.entrySkuList.Count() < 1)
                {
                    throw new MyServiceException("添加的库存为空");
                }
                // 生成入库单号： 入库时间(年月日 + 供应商 + 批次) ： 2019012200101
                model.EntryNo = string.Format("{0:yyyyMMdd}", model.EntryDate) + model.SupplierId.PadLeft(3, '0') + model.Batch.ToString().PadLeft(2, '0');
                string result = await _entrySupervisor.Add(model);
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(await Localizer.GetValueAsync("添加入库单：") + model.EntryNo);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("添加入库单失败"));
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
                    throw new MyServiceException(("数据异常"));
                }
                bool result = await _entrySupervisor.UpdateDescription(EntryId, Description);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("备注入库单：") + EntryId);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("备注入库单失败或没有该入库单"));
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
                    throw new MyServiceException(("提交的数据有误"));
                }
                return await _entrySupervisor.GetListPageBySearch(model);
            });
        }
        /// <summary>
        /// 删除入库
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(string Id, string EntryNo)
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                throw new MyServiceException("提交的数据异常");
            }
            return await ResponseResult(async () =>
            {
                bool result = await _entrySupervisor.Delete(Id);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("删除入库单：") + EntryNo);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("删除入库单失败"));
                }
                return result;
            });
        }
        /// <summary>
        /// 批量删除入库
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteBatch(IEnumerable<EntryDeleteModel> modelList)
        {
            if (modelList == null || modelList.Count() == 0)
            {
                throw new MyServiceException("提交的数据异常");
            }
            return await ResponseResult(async () =>
            {
                bool result = await _entrySupervisor.DeleteBatch(modelList);
                if (result)
                {
                    foreach (var model in modelList)
                    {
                        await LogOperation(await Localizer.GetValueAsync("删除入库单：") + model.EntryNo);
                    }
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("删除入库单失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 更新整个入库单,除了入库单号
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(EntryUpdateModel model)
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
                if (model.EntryDate == null || model.EntryDate > DateTime.Now || model.EntryDate.Year < 1900)
                {
                    throw new MyServiceException("入库时间异常");
                }

                if (model.entrySkuList == null || model.entrySkuList.Count() < 1)
                {
                    throw new MyServiceException("库存为空");
                }

                bool result = await _entrySupervisor.Update(model);
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
