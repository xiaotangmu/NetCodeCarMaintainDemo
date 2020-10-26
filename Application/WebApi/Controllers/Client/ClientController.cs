using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel;
using Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supervisor.Client;
using Swashbuckle.Swagger.Annotations;
using ViewModel.Client;
using ViewModel.CustomException;

namespace WebApi.Controllers.Client
{
    /// <summary>
    /// 客户管理
    /// </summary>
    [SwaggerControllerGroup("Client", "客户管理")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IClientSupervisor _clientSupervisor;

        public ClientController(IClientSupervisor clientSupervisor)
        {
            _clientSupervisor = clientSupervisor;
        }

        /// <summary>
        /// 新增客户
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddClient(ClientAddModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Company))
                {
                    throw new MyServiceException(("数据异常"));
                }
                string result = await _clientSupervisor.AddClient(model);
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(await Localizer.GetValueAsync("CreateClient") + model.Company);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 分页获取客户信息
        /// </summary>
        /// <param name="SearchModel">搜索模型</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetClientListWithPaging([FromQuery] BaseSearchModel SearchModel)
        {

            return await ResponseResult(async () =>
            {
                return await _clientSupervisor.QueryPageAsync(SearchModel);
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClient(DeleteClientModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.id))
                {
                    throw new MyServiceException(("数据异常"));
                }
                bool result = await _clientSupervisor.DeleteClient(model.id);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("刪除客户：") + model.Company);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("刪除失敗"));
                }
                return result;
            });
        }

        /// <summary>
        /// 更新客户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateClient(ClientViewModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.id))
                {
                    throw new MyServiceException(("数据异常"));
                }
                bool result = await _clientSupervisor.UpdateClientBySQL(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新用戶：") + model.Company + "; id:" + model.id);
                }
                else
                {
                    throw new MyServiceException(await Localizer.GetValueAsync("刪除失敗"));
                }
                return result;
            });
        }

        /// <summary>
        /// 获取所有客户，不分页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await ResponseResult(async () =>
            {
                return await _clientSupervisor.GetAll();
            });
        }
    
        /// <summary>
        /// 条件模糊查询客户信息，分页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetClientListPageBySearch([FromQuery] ClientListSearchViewModel model)
        {
            return await ResponseResult(async () =>
            {
                if (model.PageIndex < 1 || model.PageSize < 1)
                {
                    throw new MyServiceException(("数据异常"));
                }
                return await _clientSupervisor.GetClientListPageBySearch(model);
            });
        }

        /// <summary>
        /// 条件模糊查询，不分页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetClientListBySearch(string SearchStr)
        {
            return await ResponseResult(async () =>
            {
                return await _clientSupervisor.GetClientListBySearch(SearchStr);
            });
        }
    }
}
