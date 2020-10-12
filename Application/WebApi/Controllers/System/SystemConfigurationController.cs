using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Supervisor.System;
using Swashbuckle.Swagger.Annotations;
using ViewModel.System;

namespace WebApi.Controllers.System
{
    /// <summary>
    /// 系統參數配置
    /// </summary>
    [SwaggerControllerGroup("System", "系統參數配置")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class SystemConfigurationController : BaseController
    {
        private readonly ISystemConfigurationSupervisor _systemConfigurationSupervisor;

        public SystemConfigurationController(IConfiguration configuration, ISystemConfigurationSupervisor systemConfigurationSupervisor)
        {
            _systemConfigurationSupervisor = systemConfigurationSupervisor;
        }

        [HttpGet]
        public async Task<IActionResult> GetParameterGroup()
        {
            return await ResponseResult(async () =>
            {
                return await _systemConfigurationSupervisor.GetParameterGroup();
            });
        }

        [HttpPost]
        public async Task<IActionResult> Save(SystemConfigurationViewModel viewModel)
        {
            return await ResponseResult(async () =>
            {
                return await _systemConfigurationSupervisor.Save(viewModel);
            });
        }
    }
}