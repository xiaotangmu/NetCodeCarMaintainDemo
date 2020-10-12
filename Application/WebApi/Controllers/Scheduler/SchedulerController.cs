using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supervisor.Scheduler;
using Swashbuckle.Swagger.Annotations;

namespace WebApi.Controllers.Scheduler
{
    /// <summary>
    /// 定时任务
    /// </summary>
    [SwaggerControllerGroup("Scheduler", "定时任务")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class SchedulerController : ControllerBase
    {
        private readonly ISchedulerSupervisor _schedulerSupervisor;
        public SchedulerController(ISchedulerSupervisor schedulerSupervisor)
        {
            _schedulerSupervisor = schedulerSupervisor;
        }

        [HttpGet]
        public string test()
        {
            return "xxx";
        }
    }
}
