using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interface.Maintain;
using Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supervisor.Maintain;
using Swashbuckle.Swagger.Annotations;
using ViewModel.CustomException;
using ViewModel.Maintain;

namespace WebApi.Controllers.Maintain
{
    /// <summary>
    /// 维修单
    /// </summary>
    [SwaggerControllerGroup("Maintain", "维修单")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class MaintainController : BaseController
    {
        private readonly IMaintainSupervisor _maintainSupervisor;
        public MaintainController(IMaintainSupervisor maintainSupervisor)
        {
            _maintainSupervisor = maintainSupervisor;
        }

        /// <summary>
        /// 维修单添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(MaintainAddModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Operator))
                {
                    throw new MyServiceException("车牌号为空");
                }
                if (model.StartDate == null || model.StartDate.Year < 1900)
                {
                    throw new MyServiceException("维修时间异常");
                }
                if (string.IsNullOrWhiteSpace(model.AppointmentId))
                {
                    throw new MyServiceException("预约单异常");
                }
                if (string.IsNullOrWhiteSpace(model.MaintainNo))
                {
                    throw new MyServiceException("提交的数据异常");
                }
                string result = await _maintainSupervisor.Add(model);
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(await Localizer.GetValueAsync("添加维修单：") + model.MaintainNo);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("添加维修单失败"));
                }
                return result;
            });
        }
        /// <summary>
        /// 删除预约单
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(string Id, string MaintainNo)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(Id))
                {
                    throw new MyServiceException("提交的数据异常");
                }
                bool result = await _maintainSupervisor.Delete(Id);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("删除预约单：") + MaintainNo);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("删除预约单失败"));
                }
                return result;
            });
        }
        /// <summary>
        /// 批量删除预约
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteBatch(IEnumerable<MaintainDeleteModel> modelList)
        {
            return await ResponseResult(async () =>
            {
                if (modelList == null || modelList.Count() == 0)
                {
                    throw new MyServiceException("提交的数据异常");
                }
                bool result = await _maintainSupervisor.DeleteBatch(modelList);
                if (result)
                {
                    foreach (var model in modelList)
                    {
                        await LogOperation(await Localizer.GetValueAsync("删除维修单：") + model.MaintainNo);
                    }
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("删除维修单失败"));
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
                return await _maintainSupervisor.GetAll();
            });
        }

        /// <summary>
        /// 条件查询/模糊查询 -- 分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListPageBySearch([FromQuery] MaintainPageSearchModel model)
        {
            return await ResponseResult(async () =>
            {
                if (model.PageIndex < 1 || model.PageIndex < 1)
                {
                    throw new MyServiceException(("提交的数据有误"));
                }
                return await _maintainSupervisor.GetListPageBySearch(model);
            });
        }
        /// <summary>
        /// 1. 零件栏打开，更新，只更新大框
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //[HttpPost]
        //public async Task<IActionResult> Update(MaintainModel model)
        //{
        //    return await ResponseResult(async () =>
        //    {
        //        if (string.IsNullOrWhiteSpace(model.Operator))
        //        {
        //            throw new MyServiceException("负责人为空");
        //        }
        //        if (string.IsNullOrWhiteSpace(model.MaintainNo))
        //        {
        //            throw new MyServiceException("维修单为空");
        //        }
        //        if (model.StartDate == null || model.StartDate.Year < 1900)
        //        {
        //            throw new MyServiceException("数据异常");
        //        }
        //        bool result = await _maintainSupervisor.Update(model);
        //        if (result)
        //        {
        //            await LogOperation(await Localizer.GetValueAsync("更新维修单：") + model.MaintainNo);
        //        }
        //        else
        //        {
        //            throw new MyServiceException(await Localizer.GetValueAsync("添加预约失败"));
        //        }
        //        return result;
        //    });
        //}
        /// <summary>
        /// 更新出库单栏
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateWithOut(MaintainModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Operator))
                {
                    throw new MyServiceException("负责人为空");
                }
                if (string.IsNullOrWhiteSpace(model.MaintainNo))
                {
                    throw new MyServiceException("维修单为空");
                }
                if (model.StartDate == null || model.StartDate.Year < 1900)
                {
                    throw new MyServiceException("数据异常");
                }
                bool result = await _maintainSupervisor.UpdateWithOut(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新维修单：") + model.MaintainNo);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("添加预约失败"));
                }
                return result;
            });

        }
        /// <summary>
        /// 更新工具栏 -- 强制更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateWithTool(MaintainModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Operator))
                {
                    throw new MyServiceException("负责人为空");
                }
                if (string.IsNullOrWhiteSpace(model.MaintainNo))
                {
                    throw new MyServiceException("维修单为空");
                }
                if (model.StartDate == null || model.StartDate.Year < 1900)
                {
                    throw new MyServiceException("数据异常");
                }
                bool result = await _maintainSupervisor.UpdateWithTool(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新维修单：") + model.MaintainNo);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("更新失败"));
                }
                return result;
            });

        }
        /// <summary>
        /// 更新配件栏 -- 强制更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateWithOldPart(MaintainModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Operator))
                {
                    throw new MyServiceException("负责人为空");
                }
                if (string.IsNullOrWhiteSpace(model.MaintainNo))
                {
                    throw new MyServiceException("维修单为空");
                }
                if (model.StartDate == null || model.StartDate.Year < 1900)
                {
                    throw new MyServiceException("数据异常");
                }
                bool result = await _maintainSupervisor.UpdateWithOldPart(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新维修单：") + model.MaintainNo);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("更新失败"));
                }
                return result;
            });

        }
        /// <summary>
        /// 单个强制更新工具信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateTool(MaintainToolUpdateModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Id))
                {
                    throw new MyServiceException("提交的数据异常");
                }
                bool result = await _maintainSupervisor.UpdateTool(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新维修单工具：维修单：")  + model.MaintainId + " 工具：" + model.Id);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("更新维修工具失败"));
                }
                return result;
            });
        }
        /// <summary>
        /// 批量更新工具信息
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateToolList(IEnumerable<MaintainToolUpdateModel> modelList)
        {
            return await ResponseResult(async () =>
            {
                foreach(var item in modelList)
                {
                    if (string.IsNullOrWhiteSpace(item.Id))
                    {
                        throw new MyServiceException("提交的数据异常");
                    }
                }
                bool result = await _maintainSupervisor.UpdateToolList(modelList);
                if (result)
                {
                    foreach(var model in modelList)
                    {
                        await LogOperation(await Localizer.GetValueAsync("更新维修单工具：维修单：") + model.MaintainId + " 工具：" + model.Id);
                    }
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("更新维修单工具失败"));
                }
                return true;
            });
        }
        /// <summary>
        /// 强制更新单个旧配件信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateOldPart(MaintainOldPartUpdateModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Id))
                {
                    throw new MyServiceException("提交的数据异常");
                }
                bool result = await _maintainSupervisor.UpdateOldPart(model);

                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新维修单配件信息：维修单：") + model.MaintainId + " 工具：" + model.Id);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("更新维修配件信息失败"));
                }
                return result;
            });
        }
        /// <summary>
        /// 更新旧配件列表信息
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateOldPartList(IEnumerable<MaintainOldPartUpdateModel> modelList)
        {
            return await ResponseResult(async () =>
            {
                foreach(var model in modelList)
                {
                    if (string.IsNullOrWhiteSpace(model.Id))
                    {
                        throw new MyServiceException("提交的数据异常");
                    }
                }
                bool result = await _maintainSupervisor.UpdateOldPartList(modelList);
                if (result)
                {
                    foreach (var model in modelList)
                    {
                        await LogOperation(await Localizer.GetValueAsync("更新维修单配件：维修单：") + model.MaintainId + " 配件：" + model.Id);
                    }
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("更新维修配件信息失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 更新零件栏：更新维修单基本信息（状态, 员工等），不更新关联信息（出库/工具/配件），没有强制更新工具栏，零件栏
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateMaintainNoRelation(MaintainModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Id))
                {
                    throw new MyServiceException("提交的数据异常");
                }
                bool result = await _maintainSupervisor.UpdateMaintainNoRelation(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新维修单：") + model.Id);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("更新维修单失败"));
                }
                return result;
            });
        }
    }
}
