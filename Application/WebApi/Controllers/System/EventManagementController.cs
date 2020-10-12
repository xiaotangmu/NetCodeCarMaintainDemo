using System.Threading.Tasks;
using BLL.System;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace WebApi.Controllers.System
{
    /// <summary>
    /// 事件管理
    /// </summary>
    [SwaggerControllerGroup("System", "EventManagement")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class EventManagementController : BaseController
    {
        public EventManagementController() : base()
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetEventGroupWithPaging([FromQuery]SearchMethodParameter searchModel)
        {
            return await ResponseResult(async () =>
            {
                return await new EventManagement().GetPageGroup(searchModel.Text, searchModel.PageIndex, searchModel.PageSize);
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetEventGroup()
        {
            return await ResponseResult(async () =>
            {
                return await new EventManagement().GetPageGroup();
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMethodParameter parameter)
        {
            return await ResponseCreateResult(async () =>
            {
                return await new EventManagement().Add(parameter.Text);
            }, await Localization.Localizer.GetValueAsync("新增事件：") + parameter.Text);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMethodParameter parameter)
        {
            return await ResponseBoolResult(async () =>
            {
                return await new EventManagement().Update(parameter.Code, parameter.Text);
            }, await Localization.Localizer.GetValueAsync("更新事件：") + parameter.Code);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteMethodParameter parameter)
        {
            return await ResponseBoolResult(async () =>
            {
                return await new EventManagement().Delete(parameter.Code);
            }, await Localization.Localizer.GetValueAsync("刪除事件：") + parameter.Code);
        }
    }

    public class AddMethodParameter
    {
        public string Text { get; set; }
    }

    public class UpdateMethodParameter
    {
        public string Code { get; set; }

        public string Text { get; set; }
    }

    public class DeleteMethodParameter
    {
        public string Code { get; set; }
    }

    public class SearchMethodParameter : BaseSearchModel
    {
        public string Text { get; set; }
    }
}