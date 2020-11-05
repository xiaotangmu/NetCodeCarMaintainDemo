using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    /// 维修预约
    /// </summary>
    [SwaggerControllerGroup("Appointment", "维修预约")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentSupervisor _appointmentSupervisor;
        public AppointmentController(IAppointmentSupervisor appointmentSupervisor)
        {
            _appointmentSupervisor = appointmentSupervisor;
        }

        /// <summary>
        /// 预约单添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(AppointmentAddModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.CarLicense))
                {
                    throw new MyServiceException("车牌号为空");
                }
                if (model.AppointmentDate == null || model.AppointmentDate.Year < 1900)
                {
                    throw new MyServiceException("预约时间异常");
                }
                string result = await _appointmentSupervisor.Add(model);
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(await Localizer.GetValueAsync("添加预约单：车牌：") + model.CarLicense);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("添加预约失败"));
                }
                return result;
            });
        }
        /// <summary>
        /// 预约单更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(AppointmentModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.CarLicense))
                {
                    throw new MyServiceException("车牌号为空");
                }
                if (string.IsNullOrWhiteSpace(model.AppointmentNo))
                {
                    throw new MyServiceException("预约单号为空");
                }
                if (model.AppointmentDate == null || model.AppointmentDate.Year < 1900)
                {
                    throw new MyServiceException("预约时间异常");
                }
                bool result = await _appointmentSupervisor.Update(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新预约单：") + model.AppointmentNo);
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
        public async Task<IActionResult> Delete(string Id, string AppoinmentNo)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(Id))
                {
                    throw new MyServiceException("提交的数据异常");
                }
                bool result = await _appointmentSupervisor.Delete(Id);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("删除预约单：") + AppoinmentNo);
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
                bool result = await _appointmentSupervisor.DeleteBatch(modelList);
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
                return await _appointmentSupervisor.GetAll();
            });
        }

        /// <summary>
        /// 条件查询/模糊查询 -- 分页
        /// 处理查询，0未处理，1已处理，2取消, -1 不开启处理查询 -- Status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListPageBySearch([FromQuery] AppointmentPageSearchModel model)
        {
            return await ResponseResult(async () =>
            {
                if (model.PageIndex < 1 || model.PageIndex < 1)
                {
                    throw new MyServiceException(("提交的数据有误"));
                }
                return await _appointmentSupervisor.GetListPageBySearch(model);
            });
        }
    }
}
