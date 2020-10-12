using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Supervisor.System;
using Swashbuckle.Swagger.Annotations;
using ViewModel.System;

namespace WebApi.Controllers.System
{
    /// <summary>
    /// 郵件模板管理
    /// </summary>
    [SwaggerControllerGroup("System", "郵件模板控制器")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmailTemplateController : BaseController
    {
        private readonly IEmailTemplateSupervisor _emailTemplateSupervisor;
        private readonly IConfiguration _configuration;
        public EmailTemplateController(IEmailTemplateSupervisor emailTemplateSupervisor, IConfiguration configuration)
        {
            _emailTemplateSupervisor = emailTemplateSupervisor;
            _configuration = configuration;
        }

        /// <summary>
        /// 新增模板
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(EmailTemplateInfoViewModel Data)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _emailTemplateSupervisor.Add(Data);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("CreateEmailTemplate") + Data.TemplateCode);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 更新模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(EmailTemplateInfoViewModel Data)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _emailTemplateSupervisor.Update(Data);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("UpdateEmailTemplate") + Data.TemplateCode);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 獲取全部的郵件模板
        /// </summary>
        /// <param name="SearchModel">搜索模型</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetGroupWithPaging([FromQuery]EmailTemplateSearchViewModel SearchModel)
        {
            return await ResponseResult(async () =>
            {
                return await _emailTemplateSupervisor.QueryPageAsync(SearchModel);
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(EmailTemplateDeleteViewModel Model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _emailTemplateSupervisor.Delete(Model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("刪除郵件模板：") + Model.TemplateCode);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("刪除失敗"));
                }
                return result;
            });
        }

        [HttpPost]
        public async Task<IActionResult> UploadAttachment(string param)
        {
            return await ResponseResult(async () =>
            {
                var files = Request.Form.Files;
                long size = files.Sum(f => f.Length);
                int fileMaxSize = int.Parse(_configuration.GetSection("UploadFileSize").Value);
                if (size > fileMaxSize)//限制
                {
                    throw new Exception(await Localizer.GetValueAsync("FileSizeIsOver"));
                }
                foreach (var formFile in files)
                {
                    if (formFile.Length <= 0)
                    {
                        continue;
                    }
                    string templateCode = Request.Form["TemplateCode"].ToString();
                    if (string.IsNullOrEmpty(templateCode))
                    {
                        throw new Exception(await Localizer.GetValueAsync("Failure"));
                    }
                    using (var stream = formFile.OpenReadStream())
                    {
                        byte[] bytes = new byte[formFile.Length];
                        await stream.ReadAsync(bytes, 0, (int)formFile.Length);
                        //缓存，先清理重复的，待表单提交后再取出
                        Cache.CacheHelper.RemoveCache(templateCode);
                        Cache.CacheHelper.SetCache(templateCode, bytes, new TimeSpan(0, 3, 0));
                    }
                }
                return true;
            });
        }
    }
}