using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interface.Maintain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace WebApi.Controllers.Maintain
{
    /// <summary>
    /// 维修单
    /// </summary>
    [SwaggerControllerGroup("Maintain", "维修单")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class MaintainController : BaseController
    {
        private readonly IMaintainRepository _maintainRepository;
        public MaintainController(IMaintainRepository maintainRepository)
        {
            _maintainRepository = maintainRepository;
        }

        [HttpGet]
        public string test()
        {
            return "Hello";
        }
    }
}
