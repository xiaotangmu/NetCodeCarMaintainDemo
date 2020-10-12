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
    /// 入库管理
    /// </summary>
    [SwaggerControllerGroup("EntryStock", "入库管理")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class EntryController : BaseController
    {

    }
}
