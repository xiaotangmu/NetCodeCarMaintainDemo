using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.System
{
    public class ResourceSearchConditionModel : BaseSearchModel
    {
        public string MenuCode { get; set; }

        public ResourceType ResourceType { get; set; }
    }

    public class ResourcePageViewModel
    {
        public long TotalCount { get; set; }

        public List<ResourceViewModel> Items { get; set; } = new List<ResourceViewModel>();
    }

    public class BaseMenuModel
    {
        public string MenuCode { get; set; }

        public string MenuName { get; set; }
    }

    public class ResourceViewModel : AddResourceModel
    {
        public string MenuCode { get; set; }

        public string MenuName { get; set; }
    }

    public class MenuTreeModel : BaseMenuModel
    {
        public string Url { get; set; }

        public int SortNumber { get; set; }

        public bool IsChecked { get; set; }

        public List<MenuTreeModel> SubMenuGroup { get; set; } = new List<MenuTreeModel>();

        public List<ResourceTreeModel> ResourceGroup { get; set; } = new List<ResourceTreeModel>();
    }

    public class MenuModel : BaseMenuModel
    {
        public string ParentMenuCode { get; set; }

        public string Url { get; set; }

        public int Level { get; set; }

        public int SortNumber { get; set; }

        public List<MenuModel> Subset { get; set; } = new List<MenuModel>();
    }
}

public class ResourceTreeModel : UpdateResourceModel
{
    public bool IsChecked { get; set; }
}

/// <summary>
/// 资源基础模型
/// </summary>
public class BaseResourceModel
{
    public string ResourceCode { get; set; }

    public string ResourceName { get; set; }
}

public class AddMenuModel
{
    public string MenuCode { get; set; }

    public string MenuName { get; set; }

    public string ParentMenuCode { get; set; }

    public string Url { get; set; }

    public int SortNumber { get; set; }

    public int Level { get; set; }
}

public class DeleteMenuModel
{
    public string MenuCode { get; set; }
}

/// <summary>
/// 新增资源参数模型
/// </summary>
public class AddResourceModel : UpdateResourceModel
{
    /// <summary>
    /// 父节点编码
    /// </summary>
    public string ParentMenuCode { get; set; }
}

public class UpdateResourceModel : BaseResourceModel
{
    /// <summary>
    /// 资源路径
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// 排序序号
    /// </summary>
    public int SortNumber { get; set; }
}

public class DeleteResourceModel
{
    public string ResourceCode { get; set; }
}

public enum ResourceType
{
    /// <summary>
    /// 分類
    /// </summary>
    CATEGORY = 0,
    /// <summary>
    /// 菜單
    /// </summary>
    MENU = 1,
    /// <summary>
    /// API
    /// </summary>
    API = 2
}
