using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace WebApi.Controllers.System
{
    /// <summary>
    /// 登录
    /// </summary>
    [SwaggerControllerGroup("System", "LoginManagement")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class LoginManagementController : BaseController
    {
        //private readonly IConfiguration _configuration;
        //private readonly IStudentSupervisor _studentSupervisor;
        //private readonly IHttpClientFactory _httpClientFactory;

        //public LoginManagementController(IConfiguration configuration, IStudentSupervisor studentSupervisor, IHttpClientFactory httpClientFactory) : base()
        //{
        //    _configuration = configuration;
        //    _studentSupervisor = studentSupervisor;
        //    _httpClientFactory = httpClientFactory;
        //}

        //[HttpPost]
        //[ImmuneApi]
        //public async Task<IActionResult> NewStudentLogin(QuickLoginModel model)
        //{
        //    ResultData<string> result = new ResultData<string>();
        //    try
        //    {
        //        if (model == null || string.IsNullOrEmpty(model.ApplicationCode) || string.IsNullOrEmpty(model.IdCard))
        //        {
        //            throw new Exception("登錄信息錯誤");
        //        }
        //        StudentBaseInfoViewModel baseInfo = await _studentSupervisor.GetNewStudentBaseInfo(model);
        //        if (baseInfo == null)
        //        {
        //            baseInfo = await GetNewStudentFromDPSI(model);
        //        }
        //        if (baseInfo == null)
        //        {
        //            throw new Exception("不存在該學生資料");
        //        }
        //        Startup.CurrentUser = new CurrentUserInfo
        //        {
        //            Account = baseInfo.ApplicationCode,
        //            Name = baseInfo.FullName,
        //            UserType = UserType.VISITOR
        //        };
        //        //登录日志
        //        // await new LoginLogManagement().LoginLog(userInfo, IPService.GetRealIP(HttpContext));
        //        result.code = MsgCode.Success;
        //        result.message = await Localizer.GetValueAsync("Success");
        //    }
        //    catch (Exception ex)
        //    {
        //        result.code = MsgCode.Failure;
        //        result.message = ex.Message;
        //        //Common.Logger.LoggerManager.DefaultLogger.Error("Occur a error:" + ex.StackTrace, ex);
        //    }
        //    return Ok(result);
        //}

        //private async Task<StudentBaseInfoViewModel> GetNewStudentFromDPSI(QuickLoginModel loginModel)
        //{
        //    DPSIServiceHelper helper = new DPSIServiceHelper(_configuration, _httpClientFactory);
        //    StudentBaseInfoViewModel baseInfo = await helper.GetNewStudentInfo(loginModel);
        //    if (baseInfo != null)
        //    {
        //        //保存一份到宿舍學生資料庫中
        //        baseInfo.ApplicationCode = loginModel.ApplicationCode;
        //        baseInfo.IdNo = loginModel.IdCard;
        //        await _studentSupervisor.AddAsync("", baseInfo);
        //    }
        //    return baseInfo;
        //}

        //private async Task<StudentBaseInfoViewModel> GetOldStudentFromDPSI(string account)
        //{
        //    DPSIServiceHelper helper = new DPSIServiceHelper(_configuration, _httpClientFactory);
        //    StudentBaseInfoViewModel baseInfo = await helper.GetOldStudentInfo(account);
        //    if (baseInfo != null)
        //    {
        //        //保存一份到宿舍學生資料庫中
        //        await _studentSupervisor.AddAsync("", baseInfo);
        //    }
        //    return baseInfo;
        //}

        ///// <summary>
        ///// 获取登录用户的显示名称
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[ImmuneApi]
        //public async Task<IActionResult> GetUserDisplay()
        //{
        //    return await ResponseResult(async () =>
        //    {
        //        CurrentUserInfo user = base.GetCurrentUser();
        //        if (user == null)
        //        {
        //            return string.Empty;
        //        }
        //        if (string.IsNullOrEmpty(user.Name))
        //        {
        //            if (user.UserType == UserType.USER)
        //            {
        //                user.Name = await GetUserName(user);
        //            }
        //        }
        //        return user.Name;
        //    });
        //}

        //private async Task<string> GetUserName(CurrentUserInfo user)
        //{
        //    StudentBaseInfoViewModel baseInfo = await _studentSupervisor.GetOldStudentBaseInfo(user.Account);
        //    if (baseInfo == null)
        //    {
        //        baseInfo = await GetOldStudentFromDPSI(user.Account);
        //    }
        //    if (baseInfo == null)
        //    {
        //        throw new Exception("不存在該學生資料");
        //    }
        //    return baseInfo.FullName;
        //}
    }
}