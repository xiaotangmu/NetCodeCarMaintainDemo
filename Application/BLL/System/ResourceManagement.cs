using DAO.System;
using DataAccess;
using DataModel;
using DataModel.System;
using Entity.Sys;
using Interface.System;
using Localization;
using ORM;
using Supervisor.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.System
{
    public class ResourceManagement : BaseBLL, IResourceSupervisor
    {
        private IResourceDAO _resourceDAO;

        public ResourceManagement(IResourceDAO resourceDAO = null)
        {
            _resourceDAO = InitDAO<ResourceDAO>(resourceDAO) as IResourceDAO;
        }

        public async Task<List<MenuTreeModel>> GetResourceTree(string permissionCode)
        {
            var permissionResource = (await _resourceDAO.GetByPermission(permissionCode))?.ToList();
            return await BuildAllResourceTree(permissionResource);
        }

        public async Task<string> AddMenu(AddMenuModel model, CurrentUserInfo userInfo)
        {
            T_SYSTEM_RESOURCE resource = new T_SYSTEM_RESOURCE();
            resource.CODE = model.MenuCode;
            resource.NAME = model.MenuName;
            resource.PARENT_CODE = string.IsNullOrEmpty(model.ParentMenuCode) ? BaseBLL.DEFAULT_PARENT_CODE : model.ParentMenuCode;
            resource.TYPE = ((int)ResourceType.MENU).ToString();
            resource.URL = model.Url;
            resource.SORT_NUM = model.SortNumber;
            resource.CREATE_TIME = DateTime.Now;
            string result = string.Empty;
            try
            {
                result = await _resourceDAO.InsertAsync(resource);
            }
            catch (Npgsql.PostgresException ex)
            {
                throw await ContrainExceptionFactory.Singleton.Create<T_SYSTEM_RESOURCE>(ex);
            }
            return result;
        }

        public async Task<bool> UpdateMenu(AddMenuModel model, CurrentUserInfo userInfo)
        {
            return await Update(new T_SYSTEM_RESOURCE
            {
                CODE = model.MenuCode,
                TYPE = ((int)ResourceType.MENU).ToString(),
                NAME = model.MenuName,
                SORT_NUM = model.SortNumber,
                URL = model.Url,
                UPDATE_TIME = DateTime.Now
            });
        }

        public async Task<string> AddResource(AddResourceModel model, CurrentUserInfo userInfo)
        {
            T_SYSTEM_RESOURCE resource = new T_SYSTEM_RESOURCE();
            resource.CODE = model.ResourceCode;
            resource.NAME = model.ResourceName;
            resource.PARENT_CODE = model.ParentMenuCode;
            resource.TYPE = ((int)ResourceType.API).ToString();
            resource.URL = model.Url;
            resource.SORT_NUM = model.SortNumber;
            resource.CREATE_TIME = DateTime.Now;
            return await _resourceDAO.InsertAsync(resource);
        }

        public async Task<bool> UpdateResource(UpdateResourceModel model, CurrentUserInfo userInfo)
        {
            return await Update(new T_SYSTEM_RESOURCE
            {
                CODE = model.ResourceCode,
                TYPE = ((int)ResourceType.API).ToString(),
                NAME = model.ResourceName,
                SORT_NUM = model.SortNumber,
                URL = model.Url,
                UPDATE_TIME = DateTime.Now
            });
        }

        public async Task<bool> DeleteResource(string resourceCode)
        {
            if (string.IsNullOrEmpty(resourceCode))
            {
                throw new Exception(await Localizer.GetValueAsync("刪除失敗"));
            }
            return await _resourceDAO.Delete(resourceCode);
        }

        public async Task<List<MenuModel>> GetMenuTree(CurrentUserInfo userInfo = null)
        {
            if (userInfo == null)
            {
                return null;
            }
            return await ReturnPermissionMenus(userInfo.Account);
        }

        public async Task<ResourcePageViewModel> GetResourcePageList(ResourceSearchConditionModel searchCondition)
        {
            ResourcePageViewModel result = new ResourcePageViewModel();
            searchCondition.ResourceType = ResourceType.API;
            result.TotalCount = await _resourceDAO.GetCount(searchCondition);
            if (result.TotalCount == 0)
            {
                return result;
            }
            var resources = await _resourceDAO.GetPageAsync<T_SYSTEM_RESOURCE>(searchCondition);
            if (resources == null)
            {
                return result;
            }
            result.Items = await BuildResourceModel(resources);
            return result;
        }

        private async Task<bool> Update(T_SYSTEM_RESOURCE resource)
        {
            UpdateModel update = new UpdateModel();
            update.SetCollection.Add(T_SYSTEM_RESOURCE.FIELD_NAME, resource.NAME);
            update.SetCollection.Add(T_SYSTEM_RESOURCE.FIELD_SORT_NUM, (int)resource.SORT_NUM);
            update.SetCollection.Add(T_SYSTEM_RESOURCE.FIELD_URL, resource.URL);
            update.SetCollection.Add(T_SYSTEM_RESOURCE.FIELD_UPDATE_TIME, resource.UPDATE_TIME);
            update.WhereCollection.Add(T_SYSTEM_RESOURCE.FIELD_CODE, resource.CODE);
            update.WhereCollection.Add(T_SYSTEM_RESOURCE.FIELD_TYPE, resource.TYPE);
            return await _resourceDAO.EditAsync(update);
        }

        public async Task<List<MenuModel>> ReturnAllMenus(ResourceSearchConditionModel searchModel)
        {
            searchModel.ResourceType = ResourceType.MENU;
            IEnumerable<T_SYSTEM_RESOURCE> menus = await _resourceDAO.GetAllAsync(searchModel);
            return BuildMenuTree(BaseBLL.DEFAULT_PARENT_CODE, menus);
        }

        private async Task<List<MenuModel>> ReturnPermissionMenus(string account)
        {
            var menus = await _resourceDAO.GetPermissionMenus(account);
            return BuildMenuTree(BaseBLL.DEFAULT_PARENT_CODE, menus);
        }

        private List<MenuTreeModel> BuildTree(List<T_SYSTEM_RESOURCE> resources, List<T_SYSTEM_RESOURCE> allResources, List<T_SYSTEM_RESOURCE> permissionResources)
        {
            if (resources == null)
            {
                return null;
            }
            List<MenuTreeModel> tree = new List<MenuTreeModel>();
            foreach (var resource in resources)
            {
                tree.Add(BuildMenuTree(resource, allResources, permissionResources));
            }
            return tree;
        }

        private MenuTreeModel BuildMenuTree(T_SYSTEM_RESOURCE resource, List<T_SYSTEM_RESOURCE> allResources, List<T_SYSTEM_RESOURCE> permissionResources)
        {
            if (!IsMenu(resource))
            {
                return null;
            }
            MenuTreeModel treeModel = new MenuTreeModel();
            List<T_SYSTEM_RESOURCE> subResources = allResources.Where(exp => exp.PARENT_CODE == resource.CODE
                                                                                                     && exp.TYPE == ((int)ResourceType.API).ToString()).ToList();
            List<T_SYSTEM_RESOURCE> subMenus = allResources.Where(exp => exp.PARENT_CODE == resource.CODE
                                                                                                                 && exp.TYPE == ((int)ResourceType.MENU).ToString()).ToList();
            treeModel.MenuCode = resource.CODE;
            treeModel.MenuName = resource.NAME;
            treeModel.SortNumber = (int)resource.SORT_NUM;
            treeModel.Url = resource.URL;
            treeModel.IsChecked = IsPermission(resource, permissionResources);
            treeModel.ResourceGroup = BuildResourceTree(subResources, permissionResources);
            treeModel.SubMenuGroup = BuildTree(subMenus, allResources, permissionResources);
            return treeModel;
        }

        private bool IsMenu(T_SYSTEM_RESOURCE resource)
        {
            return resource.TYPE.Equals(((int)ResourceType.MENU).ToString());
        }

        private async Task<List<ResourceViewModel>> BuildResourceModel(IEnumerable<T_SYSTEM_RESOURCE> resources)
        {
            if (resources == null)
            {
                return null;
            }
            List<ResourceViewModel> resourceViewModels = new List<ResourceViewModel>();
            foreach (var resource in resources)
            {
                T_SYSTEM_RESOURCE menu = await _resourceDAO.GetAsync(resource.PARENT_CODE);
                resourceViewModels.Add(new ResourceViewModel
                {
                    ResourceCode = resource.CODE,
                    ResourceName = resource.NAME,
                    ParentMenuCode = resource.PARENT_CODE,
                    SortNumber = (int)resource.SORT_NUM,
                    Url = resource.URL,
                    MenuCode = menu?.CODE,
                    MenuName = menu?.NAME
                });
            }
            return resourceViewModels;
        }

        private bool IsPermission(T_SYSTEM_RESOURCE resource, List<T_SYSTEM_RESOURCE> permissionResources)
        {
            if (resource == null || permissionResources == null)
            {
                return false;
            }
            return permissionResources.Exists(exp => exp.CODE.Equals(resource.CODE) && exp.TYPE.Equals(resource.TYPE));
        }

        private List<ResourceTreeModel> BuildResourceTree(List<T_SYSTEM_RESOURCE> subResources, List<T_SYSTEM_RESOURCE> permissionResources)
        {
            List<ResourceTreeModel> tree = new List<ResourceTreeModel>();
            foreach (var resource in subResources)
            {
                tree.Add(new ResourceTreeModel
                {
                    ResourceCode = resource.CODE,
                    ResourceName = resource.NAME,
                    SortNumber = (int)resource.SORT_NUM,
                    Url = resource.URL,
                    IsChecked = IsPermission(resource, permissionResources)
                });
            }
            return tree;
        }

        private async Task<List<MenuTreeModel>> BuildAllResourceTree(List<T_SYSTEM_RESOURCE> permissionResources)
        {
            List<T_SYSTEM_RESOURCE> allResources = (await _resourceDAO.GetAllAsync())?.ToList();
            if (allResources == null)
            {
                return null;
            }
            List<T_SYSTEM_RESOURCE> rootMenus = GetRootMenus(allResources);
            List<MenuTreeModel> tree = new List<MenuTreeModel>();
            foreach (var rootMenu in rootMenus)
            {
                MenuTreeModel menu = BuildMenuTree(rootMenu, allResources, permissionResources);
                tree.Add(menu);
            }
            return tree;
        }

        private List<T_SYSTEM_RESOURCE> GetRootMenus(List<T_SYSTEM_RESOURCE> resource)
        {
            return resource.Where(exp => exp.TYPE.Equals(((int)ResourceType.MENU).ToString()) && exp.PARENT_CODE.Equals(BaseBLL.DEFAULT_PARENT_CODE)).ToList();
        }

        private List<MenuModel> BuildMenuTree(string parentCode, IEnumerable<T_SYSTEM_RESOURCE> menus)
        {
            List<MenuModel> models = new List<MenuModel>();
            if (menus == null)
            {
                return null;
            }
            var subMenus = menus.Where(exp => exp.PARENT_CODE.Equals(parentCode));
            if (subMenus == null)
            {
                return null;
            }
            foreach (var subMenu in subMenus)
            {
                MenuModel model = BuildMenuModel(subMenu);
                model.Subset = BuildMenuTree(model.MenuCode, menus);
                models.Add(model);
            }
            return models;
        }

        private MenuModel BuildMenuModel(T_SYSTEM_RESOURCE menu)
        {
            MenuModel model = new MenuModel();
            model.MenuCode = menu.CODE;
            model.MenuName = menu.NAME;
            model.ParentMenuCode = menu.PARENT_CODE;
            model.Url = menu.URL;
            model.Level = (int)menu.LEVEL;
            model.SortNumber = (int)menu.SORT_NUM;
            return model;
        }
    }
}
