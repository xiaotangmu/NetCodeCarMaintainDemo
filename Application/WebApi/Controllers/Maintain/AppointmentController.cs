using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supervisor.Maintain;
using Swashbuckle.Swagger.Annotations;

namespace WebApi.Controllers.Maintain
{
    /// <summary>
    /// 维修预约
    /// </summary>
    [SwaggerControllerGroup("Appointment", "维修预约")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentSupervisor _appointmentSupervisor;
        public AppointmentController(IAppointmentSupervisor appointmentSupervisor)
        {
            _appointmentSupervisor = appointmentSupervisor;
        }

        [HttpGet]
        public string test()
        {
            return "xxxx";
        }
    }
}
