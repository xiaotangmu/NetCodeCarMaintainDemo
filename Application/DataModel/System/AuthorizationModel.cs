using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.System
{
    /// <summary>
    /// 用户数据权限参数模型
    /// </summary>
    public class UserDataAuthoriseModel
    {
        public string UserCode { get; set; }

        public List<AssetCategoryAuthority> CategoryAuthorization { get; set; } = new List<AssetCategoryAuthority>();

        public List<OrganizationAuthority> OrganizationAuthorization { get; set; } = new List<OrganizationAuthority>();

        public List<AreaAuthority> AreaAuthorization { get; set; } = new List<AreaAuthority>();
    }

    public class AreaAuthority : BaseAuthority
    {
    }

    public class OrganizationAuthority : BaseAuthority
    {
    }

    public class AssetCategoryAuthority : BaseAuthority
    {
    }

    /// <summary>
    /// 角色权限参数模型
    /// </summary>
    public class SelectedRoleAuthorityModel
    {
        public string RoleCode { get; set; }

        public IEnumerable<string> SelectedAuthorityCodes { get; set; } = new List<string>();
    }

    /// <summary>
    /// 选择的菜单权限项
    /// </summary>
    public class SelectedAuthority : BaseSelectedAuthority
    {
    }

    /// <summary>
    /// 搜索的菜单权限项
    /// </summary>
    public class SearchAuthorityModel : BaseSelectedAuthority
    {
        public List<SearchAuthorityModel> SubSet { get; set; } = new List<SearchAuthorityModel>();
    }

    public class BaseSelectedAuthority
    {
        public bool IsChecked { get; set; } = false;

        /// <summary>
        /// 父级权限编码
        /// </summary>
        public string ParentCode { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string AuthorityName { get; set; }

        /// <summary>
        /// 权限编码
        /// </summary>
        public string AuthorityCode { get; set; }

        /// <summary>
        /// 权限类型，对应PermissionType枚举值，0：分类；1：权限
        /// </summary>
        public string AuthorityType { get; set; }
    }

    public class BaseAuthority
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
