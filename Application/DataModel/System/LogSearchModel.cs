using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.System
{
    /// <summary>
    /// 日志查询条件模型
    /// </summary>
    public class LogSearchModel : BaseSearchModel
    {
        /// <summary>
        /// 查询开始时间
        /// </summary>
        public string BeginTime { get; set; }

        /// <summary>
        /// 查询结束时间
        /// </summary>
        public string EndTime { get; set; }
    }

    /// <summary>
    /// 登录日志数据列表模型
    /// </summary>
    public class LoginLogTableModel
    {
        /// <summary>
        /// 查询总数，分页使用
        /// </summary>
        public long TotalCount { get; set; }

        /// <summary>
        /// 分页数据
        /// </summary>
        public List<LoginLogViewModel> Data { get; set; } = new List<LoginLogViewModel>();
    }

    /// <summary>
    /// 登录日志模型
    /// </summary>
    public class LoginLogViewModel : BaseLogViewModel
    {
        /// <summary>
        /// 登录状态，登入/登出
        /// </summary>
        public string LoginStatus { get; set; }

        /// <summary>
        /// 登录IP
        /// </summary>
        public string IP { get; set; }
    }

    /// <summary>
    /// 操作日志数据列表模型
    /// </summary>
    public class OperationLogTableModel
    {
        /// <summary>
        /// 查询总数，分页使用
        /// </summary>
        public long TotalCount { get; set; }

        /// <summary>
        /// 分页数据
        /// </summary>
        public List<OperationLogViewModel> Data { get; set; } = new List<OperationLogViewModel>();
    }

    /// <summary>
    /// 操作日志模型
    /// </summary>
    public class OperationLogViewModel : BaseLogViewModel
    {
        /// <summary>
        /// 操作内容
        /// </summary>
        public string Operation { get; set; }
    }

    public class BaseLogViewModel
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 日志时间
        /// </summary>
        public string LogTime { get; set; }
    }
}
