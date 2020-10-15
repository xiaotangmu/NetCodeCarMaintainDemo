using Microsoft.AspNetCore.Mvc;
using Supervisor.Catalog;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.Catalog
{
    /// <summary>
    /// 属性管理
    /// </summary>
    [SwaggerControllerGroup("Attr", "属性管理")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class AttrController : BaseController
    {
        private IAttrSupervisor _attrSupervisor;

        public AttrController(IAttrSupervisor attrSupervisor)
        {
            _attrSupervisor = attrSupervisor;
        }
    }
}
