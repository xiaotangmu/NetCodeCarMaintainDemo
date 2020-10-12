using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace WebApi.Controllers.System
{
    /// <summary>
    /// 系統參數配置
    /// </summary>
    [SwaggerControllerGroup("System", "參數配置")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class SystemConfiguration : BaseController
    {

    }
}
