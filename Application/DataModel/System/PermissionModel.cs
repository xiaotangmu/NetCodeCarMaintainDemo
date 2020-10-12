using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.System
{
    /// <summary>
    /// 分页查询模型
    /// </summary>
    public class PermissionPageSearchModel : BaseSearchModel
    {
        public string ParentCode { get; set; }
    }

    /// <summary>
    /// 表格分页视图模型
    /// </summary>
    public class PermissionPageViewModel
    {
        public long TotalCount { get; set; }

        public List<PermissionViewModel> Items { get; set; } = new List<PermissionViewModel>();
    }

    /// <summary>
    /// 单行数据视图模型
    /// </summary>
    public class PermissionViewModel : PermissionBaseModel
    {
        /// <summary>
        /// 排序序号
        /// </summary>
        public int SortNum { get; set; }
    }

    /// <summary>
    /// 基础参数模型
    /// </summary>
    public class PermissionBaseModel
    {
        public string PermissionCode { get; set; }

        public string PermissionName { get; set; }

        public string ParentCode { get; set; }
    }

    /// <summary>
    /// 新增参数模型
    /// </summary>
    public class PermissionAddModel : PermissionUpdateModel
    {

    }

    public class PermissionUpdateModel : PermissionBaseModel
    {
        public int SortNumber { get; set; }
    }

    public class PermissionDeleteModel
    {
        public string PermissionCode { get; set; }
    }

    public class BindResourceModel
    {
        public string PermissionCode { get; set; }

        public List<MenuTreeModel> Resources { get; set; } = new List<MenuTreeModel>();
    }

    public class AllocateResourceModel
    {
        public string PermissionCode { get; set; }

        public List<string> ResourceGroup { get; set; } = new List<string>();
    }

    /// <summary>
    /// 角色权限参数模型
    /// </summary>
    public class SelectedRolePermissionModel
    {
        public string RoleCode { get; set; }

        public IEnumerable<string> SelectedPermissionGroup { get; set; } = new List<string>();
    }

    public class PermissionTreeModel : BaseMenuModel
    {
        public string ParentMenuCode { get; set; }

        public List<BaseSelectedPermission> PermissionGroup { get; set; } = new List<BaseSelectedPermission>();

        public List<PermissionTreeModel> Subset { get; set; } = new List<PermissionTreeModel>();
    }

    /// <summary>
    /// 搜索的菜单权限项
    /// </summary>
    public class SearchPermissionModel : BaseSelectedPermission
    {
        public List<SearchPermissionModel> SubSet { get; set; } = new List<SearchPermissionModel>();
    }

    public class BaseSelectedPermission : PermissionBaseModel
    {
        public bool IsChecked { get; set; } = false;
    }

    /// <summary>
    /// 权限节点类型
    /// </summary>
    public enum PermissionType
    {
        CATEGORY = 0, AUTHORIZATION = 1
    }
}
