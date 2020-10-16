using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Common;
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

    
}
