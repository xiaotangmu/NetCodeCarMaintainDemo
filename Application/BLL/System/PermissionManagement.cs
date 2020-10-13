using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.System;
using DataAccess;
using DataModel.System;
using Entity.Sys;
using Interface.System;
using Localization;
using ORM;
using Supervisor.System;

namespace BLL.System
{
    public class PermissionManagement : BaseBLL, IPermissionSupervisor
    {
        private IPermissionDAO _permissionDAO;
        private IResourceDAO _resourceDAO;
        private IPermissionResourceDAO _permissionResourceDAO;

        public PermissionManagement(IPermissionDAO permissionDAO = null,
                                                            IResourceDAO resourceDAO = null,
                                                            IPermissionResourceDAO permissionResourceDAO = null)
        {
            _permissionDAO = InitDAO<PermissionDAO>(permissionDAO) as IPermissionDAO;
            _resourceDAO = InitDAO<ResourceDAO>(resourceDAO) as IResourceDAO;
            _permissionResourceDAO = InitDAO<PermissionResourceDAO>(permissionResourceDAO) as IPermissionResourceDAO;
        }

        public async Task<PermissionPageViewModel> GetPageList(PermissionPageSearchModel searchModel)
        {
            PermissionPageViewModel model = new PermissionPageViewModel();
            model.TotalCount = await _permissionDAO.GetCount(searchModel);
            if (model.TotalCount == 0)
            {
                return model;
            }
            var permissions = await _permissionDAO.GetPageAsync<T_SYSTEM_PERMISSION>(searchModel);
            if (permissions == null)
            {
                return model;
            }
            foreach (var permission in permissions)
            {
                model.Items.Add(new PermissionViewModel
                {
                    PermissionCode = permission.CODE,
                    PermissionName = permission.NAME,
                    SortNum = (int)permission.SORT_NUM,
                    ParentCode = permission.PARENT_CODE
                });
            }
            return model;
        }

        public async Task<string> Add(PermissionAddModel model, CurrentUserInfo userInfo)
        {
            T_SYSTEM_PERMISSION permission = new T_SYSTEM_PERMISSION();
            permission.CODE = model.PermissionCode;
            permission.NAME = model.PermissionName;
            permission.PARENT_CODE = model.ParentCode;
            permission.TYPE = ((int)PermissionType.AUTHORIZATION).ToString();
            permission.SORT_NUM = model.SortNumber;
            permission.OCD = DateTime.Now;
            string result = string.Empty;
            try
            {
                result = await _permissionDAO.InsertAsync(permission);
            }
            catch (Npgsql.PostgresException ex)
            {
                throw await ContrainExceptionFactory.Singleton.Create<T_SYSTEM_PERMISSION>(ex);
            }
            return result;
        }

        public async Task<bool> Edit(PermissionUpdateModel model, CurrentUserInfo userInfo)
        {
            UpdateModel update = new UpdateModel();
            update.SetCollection.Add(T_SYSTEM_PERMISSION.FIELD_NAME, model.PermissionName);
            update.SetCollection.Add(T_SYSTEM_PERMISSION.FIELD_SORT_NUM, model.SortNumber);
            update.SetCollection.Add(T_SYSTEM_PERMISSION.FIELD_LUD, DateTime.Now);
            update.WhereCollection.Add(T_SYSTEM_PERMISSION.FIELD_CODE, model.PermissionCode);
            return await _permissionDAO.EditAsync(update);
        }

        public async Task<IEnumerable<PermissionTreeModel>> GetAuthorityModelGroup(ResourceSearchConditionModel resourceSearchModel, string roleCode = null)
        {
            var rolePermission = await _permissionDAO.GetPermissionByRoleAsync(roleCode);
            var allMenu = await new ResourceManagement(_resourceDAO).ReturnAllMenus(resourceSearchModel);
            var rootMenuTree = allMenu?.Where(exp => exp.ParentMenuCode.Equals(BaseBLL.DEFAULT_PARENT_CODE));
            return await BuildPermissionTree(rootMenuTree, rolePermission);
        }

        private async Task<List<PermissionTreeModel>> BuildPermissionTree(IEnumerable<MenuModel> menus, IEnumerable<T_SYSTEM_PERMISSION> rolePermissions)
        {
            if (menus == null)
            {
                return null;
            }
            List<PermissionTreeModel> permissionTree = new List<PermissionTreeModel>();
            foreach (MenuModel menu in menus)
            {
                PermissionTreeModel treeModel = new PermissionTreeModel
                {
                    MenuCode = menu.MenuCode,
                    MenuName = menu.MenuName,
                    ParentMenuCode = menu.ParentMenuCode,
                    Subset = await BuildPermissionTree(menu.Subset, rolePermissions)
                };
                treeModel.PermissionGroup = await BuildPermissionGroup(menu.MenuCode, rolePermissions);
                permissionTree.Add(treeModel);
            }
            return permissionTree;
        }

        private async Task<List<BaseSelectedPermission>> BuildPermissionGroup(string menuCode, IEnumerable<T_SYSTEM_PERMISSION> rolePermissions)
        {
            var menuPermissionGroup = await _permissionDAO.GetAllAsync(menuCode);
            if (menuPermissionGroup == null)
            {
                return null;
            }
            List<BaseSelectedPermission> permissionGroup = new List<BaseSelectedPermission>();
            foreach (T_SYSTEM_PERMISSION menuPermission in menuPermissionGroup)
            {
                permissionGroup.Add(new BaseSelectedPermission
                {
                    PermissionCode = menuPermission.CODE,
                    PermissionName = menuPermission.NAME,
                    ParentCode = menuPermission.PARENT_CODE,
                    IsChecked = IsChecked(menuPermission, rolePermissions)
                });
            }
            return permissionGroup;
        }

        private bool IsChecked(T_SYSTEM_PERMISSION menuPermission, IEnumerable<T_SYSTEM_PERMISSION> rolePermissions)
        {
            return rolePermissions.Any(exp => exp.CODE.Equals(menuPermission.CODE));
        }

        private void CheckMenus(IEnumerable<SearchPermissionModel> allMenus, IEnumerable<SearchPermissionModel> roleMenus)
        {
            foreach (var permission in allMenus)
            {
                if (roleMenus != null && roleMenus.Any(menu => menu.PermissionCode == permission.PermissionCode))
                {
                    permission.IsChecked = true;
                }
            }
        }

        private List<SearchPermissionModel> GetSubPermission(string parentCode, IEnumerable<SearchPermissionModel> items)
        {
            List<SearchPermissionModel> children = items.Where(item => item.ParentCode == parentCode).ToList();
            foreach (var child in children)
            {
                child.SubSet = GetSubPermission(child.PermissionCode, items);
            }
            return children;
        }

        public async Task<bool> Delete(string code)
        {
            bool result = false;
            using (IDbTransaction transaction = _permissionDAO.Repository.DbSession.Begin())
            {
                try
                {
                    result = await DeleteTransactionExecute(code, transaction);
                    if (result)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        private async Task<bool> DeleteTransactionExecute(string code, IDbTransaction transaction)
        {
            bool isSuccess = await _permissionDAO.DeleteAsync(code, transaction);
            if (isSuccess)
            {
                isSuccess = await _permissionResourceDAO.DeleteByPermission(code, transaction);
            }
            return isSuccess;
        }

        public async Task<bool> BindResources(AllocateResourceModel model)
        {
            bool result = false;
            if (model == null || string.IsNullOrEmpty(model.PermissionCode))
            {
                return result;
            }
            using (IDbTransaction transaction = _permissionDAO.Repository.DbSession.Begin())
            {
                try
                {
                    result = await BindResourcesTransactionExecute(model, transaction);
                    if (result)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        private async Task<bool> BindResourcesTransactionExecute(AllocateResourceModel model, IDbTransaction transaction)
        {
            //先清除关系
            bool result = await _permissionResourceDAO.DeleteByPermission(model.PermissionCode, transaction);
            //再添加
            if (result)
            {
                result = await InsertResources(model.PermissionCode, model.ResourceGroup, transaction);
            }
            return result;
        }

        private async Task<bool> InsertResources(string permissionCode, List<string> resourceGroup, IDbTransaction transaction)
        {
            bool result = false;
            var permission = await _permissionDAO.GetAsync(permissionCode);
            if (permission == null)
            {
                return result;
            }
            foreach (string resourceCode in resourceGroup)
            {
                var resource = await _resourceDAO.GetAsync(resourceCode);
                if (resource == null)
                {
                    continue;
                }
                result = await _permissionResourceDAO.InsertAsync(permission.ID, resource.ID, transaction);
            }
            return result;
        }
    }
}
