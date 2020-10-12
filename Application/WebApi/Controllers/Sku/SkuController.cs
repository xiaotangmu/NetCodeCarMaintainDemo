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
    /// 库存管理
    /// </summary>
    [SwaggerControllerGroup("Sku", "库存管理")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class SkuController : BaseController
    {

    }
}
