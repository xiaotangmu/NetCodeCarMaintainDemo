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
        /// 维修单更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(MaintainModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Operator))
                {
                    throw new MyServiceException("负责人为空");
                }
                if (string.IsNullOrWhiteSpace(model.MaintainNo))
                {
                    throw new MyServiceException("负责人为空");
                }
                if (model.StartDate == null || model.StartDate.Year < 1900)
                {
                    throw new MyServiceException("数据异常");
                }
                bool result = await _maintainSupervisor.Update(model);
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
        public async Task<IActionResult> DeleteBatch(IEnumerable<AppointmentDeleteModel> modelList)
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
                        await LogOperation(await Localizer.GetValueAsync("删除预约单：") + model.AppointmentNo);
                    }
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("删除预约单失败"));
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
    }
}
