using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Auth;

namespace WebApi.Models.Results
{
    /// <summary>
    /// 无数据的统一返回格式
    /// </summary>
    public class ResultData
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public MsgCode code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 相关的链接帮助地址
        /// </summary>
        public string url { get; set; }
    }

    /// <summary>
    /// 带数据的统一返回格式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultData<T> : ResultData
    {
        /// <summary>
        /// 数据
        /// </summary>
        public virtual T data { get; set; }
    }

    /// <summary>
    /// 错误码 枚举
    /// </summary>
    public enum MsgCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 1000,
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Failure = 1001,
        /// <summary>
        /// 验证码过期
        /// </summary>
        [Description("验证码过期！")]
        Login_ValidaterCodeExpire = 1150,
        /// <summary>
        /// 验证码错误
        /// </summary>
        [Description("验证码错误！")]
        Login_ValidaterCodeError = 1151,
        /// <summary>
        /// 登录名或密码错误
        /// </summary>
        [Description("登录名或密码错误！")]
        Login_NameOrPwdError = 1152,
        /// <summary>
        /// 用户已被禁用
        /// </summary>
        [Description("该用户已被禁用！")]
        Login_UserDisabled = 1153,
        /// <summary>
        /// 检测到重复的请求
        /// </summary>
        [Description("检测到重复的请求！")]
        Request_Repeat = 1199,
        /// <summary>
        /// 长时间未操作，会话过期
        /// </summary>
        [Description("会话过期")]
        Session_Expire = 1100,
        /// <summary>
        /// 该用户被其他用户踢下线，请重新登录
        /// </summary>
        [Description("该用户被其他用户踢下线，请重新登录")]
        Session_BeKicked = 1101,
        /// <summary>
        /// 相同用户登录
        /// </summary>
        [Description("相同用户登录，是否踢掉？")]
        Session_SameUserLogin = 1102,
        /// <summary>
        /// 相同用户登录
        /// </summary>
        [Description("会话无效")]
        Session_Invalid = 1103,
        /// <summary>
        /// 无操作权限
        /// </summary>
        [Description("无操作权限")]
        Session_NotPermission = 1104,

        /// <summary>
        /// 请先登录
        /// </summary>
        [Description("请先登录")]
        Please_Login = 1105,

        /// <summary>
        /// 删除缓存错误
        /// </summary>
        [Description("删除缓存错误")]
        Cache_Error_Del = 1200,

        /// <summary>
        /// 删除缓存错误
        /// </summary>
        [Description("重新加载缓存错误")]
        Cache_Error_ReLoad = 1201,

        #region 业务层编码
        /// <summary>
        /// 名称重复
        /// </summary>
        [Description("名称重复")]
        Duplicate_Name = 100001,

        /// <summary>
        /// 存在相同数据
        /// </summary>
        [Description("存在相同数据")]
        SameData = 100002,

        /// <summary>
        /// 数据已更新
        /// </summary>
        [Description("数据已更新")]
        Data_Updated = 100003,

        #endregion
    }
}
