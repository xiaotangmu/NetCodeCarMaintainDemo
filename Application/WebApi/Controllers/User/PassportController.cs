using Localization;
using Microsoft.AspNetCore.Mvc;
using Supervisor.User;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.CustomException;
using ViewModel.User;

namespace WebApi.Controllers.User
{
    /// <summary>
    /// 认证中心
    /// </summary>
    [SwaggerControllerGroup("Passport", "认证中心")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class PassportController : BaseController
    {
        private IUserSupervisor _userSupervisor;

        public PassportController(IUserSupervisor userSupervisor)
        {
            _userSupervisor = userSupervisor;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(UserAddModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.UserName) || string.IsNullOrWhiteSpace(model.Pwd))
                {
                    throw new MyServiceException("用户名或密码格式有误");
                }
                bool result = await _userSupervisor.Login(model);
                return result;
            });
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(UserAddModel model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.UserName) || string.IsNullOrWhiteSpace(model.Pwd))
                {
                    throw new MyServiceException("用户名或密码格式有误");
                }
                return await _userSupervisor.Register(model);
            });
        }
    }
}
