using DataModel.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supervisor.System
{
    public interface IResourceSupervisor
    {
        Task<string> AddMenu(AddMenuModel model, CurrentUserInfo userInfo);
        Task<string> AddResource(AddResourceModel model, CurrentUserInfo userInfo);
        Task<bool> DeleteResource(string resourceCode);
        Task<List<MenuModel>> GetMenuTree(CurrentUserInfo userInfo = null);
        Task<ResourcePageViewModel> GetResourcePageList(ResourceSearchConditionModel searchCondition);
        Task<List<MenuTreeModel>> GetResourceTree(string permissionCode);
        Task<bool> UpdateMenu(AddMenuModel model, CurrentUserInfo userInfo);
        Task<bool> UpdateResource(UpdateResourceModel model, CurrentUserInfo userInfo);
    }
}
