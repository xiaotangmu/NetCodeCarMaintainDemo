﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supervisor.Client;
using Swashbuckle.Swagger.Annotations;
using ViewModel.Client;

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

        [HttpGet]
        public string test()
        {
            return "Hello";
        }

        /// <summary>
        /// 新增客户
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddClient(ClientAddModel Data)
        {
            return await ResponseResult(async () =>
            {
                string result = await _clientSupervisor.AddClient(Data);
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(await Localizer.GetValueAsync("CreateClient") + Data.Company);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
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
        public async Task<IActionResult> GetUserGroupWithPaging([FromQuery] ClientListSearchViewModel SearchModel)
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
                bool result = await _clientSupervisor.DeleteClient(model.id);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("刪除用戶：") + model.Company);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("刪除失敗"));
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
                bool result = await _clientSupervisor.UpdateClientBySQL(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新用戶：") + model.Company + "; id:" + model.id);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("刪除失敗"));
                }
                return result;
            });
        }

        /// <summary>
        /// 获取所有客户，不分页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            return await ResponseResult(async () =>
            {
                bool result = await _clientSupervisor.UpdateClientBySQL(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新用戶：") + model.Company + "; id:" + model.id);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("刪除失敗"));
                }
                return result;
            });
        }
    }
}
