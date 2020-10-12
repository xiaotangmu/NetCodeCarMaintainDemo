using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.System
{
    /// <summary>
    /// 角色信息
    /// </summary>
    public class RoleModel
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string RoleCode { get; set; }
        /// <summary>
        ///名称
        /// </summary>
        public string RoleName { get; set; }
    }

    public class DeleteRoleViewModel
    {
        public string RoleCode { get; set; }
    }

    public class RoleViewModel : RoleModel
    {
        /// <summary>
        /// 0停用;1启用
        /// </summary>
        public bool IsUse
        {
            get;
            set;
        }
    }

    public class RolePageViewModel
    {
        public long TotalCount { get; set; }

        public List<RoleViewModel> Items { get; set; } = new List<RoleViewModel>();
    }

    /// <summary>
    /// 角色状态模型
    /// </summary>
    public class RoleStatus
    {
        /// <summary>
        /// 是否启用，true为启用
        /// </summary>
        public bool IsUse { get; set; }

        /// <summary>
        /// 角色编码
        /// </summary>
        public string RoleCode { get; set; }
    }
}
