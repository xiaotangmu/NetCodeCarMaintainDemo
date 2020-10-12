using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supervisor.Client;
using Swashbuckle.Swagger.Annotations;

namespace WebApi.Controllers.Client
{
    /// <summary>
    /// 客户管理
    /// </summary>
    [SwaggerControllerGroup("Client", "客户管理")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
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
    }
}
