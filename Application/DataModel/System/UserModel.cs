using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.System
{
    public class UserModel
    {
        public string Account { get; set; }

        public string Name { get; set; }
    }

    public class UserSearchModel : BaseSearchModel
    {
        public string Account { get; set; }
    }

    /// <summary>
    /// 用户信息分页视图
    /// </summary>
    public class UserPageViewModel
    {
        public long TotalCount { get; set; }

        public List<UserViewMode> Items { get; set; } = new List<UserViewMode>();
    }

    public class UserViewMode : UserModel
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsUse { get; set; }
    }

    public class ModifyUserRoleModel
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        public string Account { get; set; }

        public List<string> RoleCodeGroup { get; set; } = new List<string>();
    }

    public class DeleteUserModel
    {
        public string Account { get; set; }
    }

    /// <summary>
    /// 用户类型
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// 一般用户
        /// </summary>
        USER = 1,
        /// <summary>
        /// 游客
        /// </summary>
        VISITOR = 2
    }
}
