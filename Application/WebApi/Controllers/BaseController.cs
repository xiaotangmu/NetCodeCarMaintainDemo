using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataModel.System;
using BLL.System;
using WebApi.Models.Results;
using Localization;
using System;
using Microsoft.AspNetCore.Http;
using WebApi.Utils.Filters;
using ViewModel.CustomException;

namespace WebApi.Controllers
{
    /// <summary>
    /// controller的基类
    /// </summary>
    [ApiController]
    public class BaseController : ControllerBase
    {
        private CurrentUserInfo _currentUser;

        public BaseController()
        {
        }

        /// <summary>
        /// 获得当前请求用户信息
        /// </summary>
        /// <returns></returns>
        protected CurrentUserInfo GetCurrentUser()
        {
            if (_currentUser == null)
            {
                _currentUser = Startup.CurrentUser;
            }
            return _currentUser;
        }

        /// <summary>
        /// Create事件响应
        /// </summary>
        /// <param name="createAction">创建对象动作</param>
        /// <param name="successfulLogRecord">成功日志记录</param>
        /// <returns></returns>
        protected virtual async Task<OkObjectResult> ResponseCreateResult(Func<Task<string>> createAction, string successfulLogRecord)
        {
            return await ResponseResult(async () =>
            {
                string result = await createAction();
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(successfulLogRecord);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 返回布爾類型事件响应
        /// </summary>
        /// <param name="executeAction">创建对象动作</param>
        /// <param name="successfulLogRecord">成功日志记录</param>
        /// <returns></returns>
        protected virtual async Task<OkObjectResult> ResponseBoolResult(Func<Task<bool>> executeAction, string successfulLogRecord)
        {
            return await ResponseResult(async () =>
            {
                bool result = await executeAction();
                if (result)
                {
                    await LogOperation(successfulLogRecord);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("Failure"));
                }
                return result;
            });
        }

        /// <summary>
        /// 结果响应
        /// </summary>
        /// <typeparam name="T">任意类型</typeparam>
        /// <param name="hookAction">获取数据方法体以及相关逻辑，返回数据结果</param>
        /// <returns></returns>
        protected virtual async Task<OkObjectResult> ResponseResult<T>(Func<Task<T>> hookAction)
        {
            ResultData<T> result = new ResultData<T>();
            try
            {
                await DefaultSuccessHook(result, await hookAction());
                if (ApiAttributeFilter.IsAuthorize(HttpContext))
                {
                    //result.token = await _tokenManager.ValidToken(GetCurrentUser());
                }
            }
            catch (InfoException info)
            {
                result.data = default;
                result.code = MsgCode.Success;
                result.message = info.Message;
            }
            catch (Exception ex)
            {
                result.data = default;
                result.code = MsgCode.Failure;
                result.message = ex.Message;
                Common.Logger.LoggerManager.DefaultLogger.Error("Occur a error:" + ex.StackTrace, ex);
            }
            return Ok(result);
        }

        private async Task DefaultSuccessHook<T>(ResultData<T> result, T data)
        {
            result.data = data;
            result.code = MsgCode.Success;
            result.message = await Localizer.GetValueAsync("Success");
        }

        /// <summary>
        /// 操作日志记录
        /// </summary>
        /// <param name="logContent">记录的内容</param>
        /// <returns></returns>
        protected async Task LogOperation(string logContent)
        {
            string resourcePath = HttpContext.Request.Path.Value.Replace(Startup.ApiPrefix, "");
            if (resourcePath.StartsWith("//"))
            {
                resourcePath = resourcePath.Remove(0, 1);
            }
            //记录API的访问日志
            //await new OperationLogManagement().WriteOperationLog(GetCurrentUser(), new OperationElement
            //{
            //    RequestUrl = resourcePath,
            //    RequestArgs = HttpContext.Request.QueryString.Value,
            //    Operation = logContent
            //});
        }

        /// <summary>
        /// 字符串返回值判断
        /// </summary>
        /// <param name="identity">鉴别数据</param>
        /// <param name="tipTitle">提示名称</param>
        /// <param name="tipData">提示数据</param>
        /// <param name="failTip">失败提示</param>
        public async Task ResponseAddLogStr(string identity, string tipTitle, string tipData, string failTip)
        {
            if (!string.IsNullOrEmpty(identity))
            {
                await LogOperation(await Localizer.GetValueAsync(tipTitle + ": ") + tipData);
            }
            else
            {
                throw new Exception(await Localizer.GetValueAsync(failTip));
            }
        }
        /// <summary>
        /// bool返回值判断
        /// </summary>
        /// <param name="identity">鉴别数据</param>
        /// <param name="tipTitle">提示名称</param>
        /// <param name="tipData">提示数据</param>
        /// <param name="failTip">失败提示</param>
        public async Task ResponseAddLogBool(bool identity, string tipTitle, string tipData, string failTip)
        {
            if (identity)
            {
                await LogOperation(await Localizer.GetValueAsync(tipTitle + ": ") + tipData);
            }
            else
            {
                throw new Exception(await Localizer.GetValueAsync(failTip));
            }
        }
    }
}