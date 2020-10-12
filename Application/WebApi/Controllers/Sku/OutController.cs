using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace WebApi.Controllers.Sku
{
    /// <summary>
    /// 出库管理
    /// </summary>
    [SwaggerControllerGroup("OutStock", "出库管理")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class OutController : BaseController
    {

    }
}
