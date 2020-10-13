using Interface.System;
using DataModel;
using DataModel.System;
using Entity.Sys;
using Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DAO.System;
using Supervisor.System;

namespace BLL.System
{
    public class RoleManagement : BaseBLL, IRoleSupervisor
    {
        private IRoleDAO _roleDAO;
        private IPermissionDAO _permissionDAO;
        private IRolePermissionDAO _rolePermissionDAO;

        public RoleManagement(IRoleDAO roleDAO = null, IRolePermissionDAO rolePermissionDAO = null, IPermissionDAO permissionDAO = null)
        {
            _roleDAO = InitDAO<RoleDAO>(roleDAO) as IRoleDAO;
            _permissionDAO = InitDAO<PermissionDAO>(permissionDAO) as IPermissionDAO;
            _rolePermissionDAO = InitDAO<RolePermissionDAO>(rolePermissionDAO) as IRolePermissionDAO;
        }

        public async Task<RolePageViewModel> GetPageList(BaseSearchModel searchCondition)
        {
            RolePageViewModel model = new RolePageViewModel();
            model.TotalCount = await _roleDAO.GetCount(searchCondition);
            if (model.TotalCount == 0)
            {
                return model;
            }
            var roles = await _roleDAO.GetPageAsync<T_SYSTEM_ROLE>(searchCondition);
            if (roles == null)
            {
                return model;
            }
            foreach (var role in roles)
            {
                model.Items.Add(new RoleViewModel
                {
                    RoleCode = role.CODE,
                    RoleName = role.NAME,
                    IsUse = role.ISUSE.Equals(((int)Judge.YES).ToString()) ? true : false
                });
            }
            return model;
        }

        /// <summary>
        /// 获取所有正常状态角色
        /// </summary>
        /// <param name="sm_id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RoleViewModel>> GetValidRoles()
        {
            var roles = await _roleDAO.GetValidAsync();
            if (roles == null)
            {
                return null;
            }
            List<RoleViewModel> models = new List<RoleViewModel>();
            foreach (var role in roles)
            {
                RoleViewModel model = new RoleViewModel();
                model.RoleCode = role.CODE;
                model.RoleName = role.NAME;
                model.IsUse = role.ISUSE == ((int)Judge.YES).ToString() ? true : false;

                models.Add(model);
            }
            return models;
        }

        public async Task<string> GetRoleId(string roleCode)
        {
            string roleID = string.Empty;
            var result = await _roleDAO.GetAsync(roleCode);

            if (result != null)
            {
                roleID = result.ID;
            }
            return roleID;
        }

        public async Task<string> Add(RoleModel role)
        {
            T_SYSTEM_ROLE entity = new T_SYSTEM_ROLE();
            entity.CODE = role.RoleCode;
            entity.NAME = role.RoleName;
            entity.ISUSE = ((int)Judge.YES).ToString();
            entity.OCD = DateTime.Now;
            string result = string.Empty;
            try
            {
                result = await _roleDAO.InsertAsync(entity);
            }
            catch (Npgsql.PostgresException ex)
            {
                throw await ContrainExceptionFactory.Singleton.Create<T_SYSTEM_ROLE>(ex);
            }
            return result;
        }

        public async Task<bool> Edit(RoleModel role)
        {
            UpdateModel update = new UpdateModel();
            update.SetCollection.Add("name", role.RoleName);
            update.SetCollection.Add("modify_date", DateTime.Now);
            update.WhereCollection.Add("code", role.RoleCode);

            if (string.IsNullOrEmpty(role.RoleName))
            {
                throw new Exception(await Localizer.GetValueAsync("RoleNameEmpty"));
            }
            return await _roleDAO.EditAsync(update);
        }

        public async Task<bool> Delete(DeleteRoleViewModel role)
        {
            await ConditionsConstrain(role);
            return await _roleDAO.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                return await DeleteTransaction(role, transaction);
            });
        }

        private async Task ConditionsConstrain(DeleteRoleViewModel role)
        {
            if (role == null || string.IsNullOrEmpty(role.RoleCode))
            {
                throw new Exception(await Localizer.GetValueAsync("Data_Empty"));
            }
            if (await _roleDAO.IsUseRole(role.RoleCode))
            {
                throw new Exception(await Localizer.GetValueAsync("RoleIsUsing"));
            }
        }

        private async Task<bool> DeleteTransaction(DeleteRoleViewModel role, IDbTransaction transaction)
        {
            //先删除角色权限关联表数据
            bool isSuccessful = await new RolePermissionDAO(_roleDAO.Repository).DeleteByRole(role.RoleCode, transaction);
            if (isSuccessful)
            {
                isSuccessful = await _roleDAO.DeleteAsync(role.RoleCode, transaction);
            }
            return isSuccessful;
        }

        public async Task<RoleModel> Get(string roleId)
        {
            T_SYSTEM_ROLE role = await _roleDAO.GetEntityByIdAsync<T_SYSTEM_ROLE>(roleId);
            if (role == null)
            {
                return null;
            }
            return new RoleModel
            {
                RoleCode = role.CODE,
                RoleName = role.NAME
            };
        }

        public async Task<bool> ChangeState(bool isUsing, string roleCode)
        {
            if (isUsing)
            {
                return await StartUsing(roleCode);
            }
            else
            {
                return await Forbidden(roleCode);
            }
        }

        /// <summary>
        /// 保存角色菜单权限
        /// </summary>
        public async Task<bool> SaveAuthority(SelectedRolePermissionModel roleMenu)
        {
            if (roleMenu == null || string.IsNullOrEmpty(roleMenu.RoleCode))
            {
                throw new Exception(await Localizer.GetValueAsync("角色權限數據無效"));
            }
            return await _rolePermissionDAO.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                return await SaveAuthorityTransaction(roleMenu, transaction);
            });
        }

        private async Task<bool> SaveAuthorityTransaction(SelectedRolePermissionModel roleMenu, IDbTransaction transaction)
        {
            bool isSuccessful = await _rolePermissionDAO.DeleteByRole(roleMenu.RoleCode, transaction);
            if (isSuccessful)
            {
                isSuccessful = await InsertAuthority(roleMenu, transaction);
            }
            return isSuccessful;
        }

        private async Task<bool> InsertAuthority(SelectedRolePermissionModel roleMenu, IDbTransaction transaction)
        {
            bool result = true;
            if (roleMenu.SelectedPermissionGroup == null)
            {
                return false;
            }
            foreach (var permission in roleMenu.SelectedPermissionGroup)
            {
                result = await InsertRolePermission(permission, roleMenu.RoleCode, transaction);
            }
            return result;
        }

        private async Task<bool> InsertRolePermission(string permissionCode, string roleCode, IDbTransaction transaction)
        {
            T_SYSTEM_ROLE role = await _roleDAO.GetAsync(roleCode);
            if (role == null)
            {
                throw new Exception(await Localizer.GetValueAsync("Role_IsNotExist"));
            }
            T_SYSTEM_PERMISSION permission = await _permissionDAO.GetAsync(permissionCode);
            if (permission == null)
            {
                throw new Exception(await Localizer.GetValueAsync("ErrorAuthorization") + "：" + permissionCode);
            }
            //分类不作保存
            if (permission.TYPE.Equals(((int)PermissionType.CATEGORY).ToString()))
            {
                return true;
            }
            T_SYSTEM_ROLE_PERMISSION role_permission = new T_SYSTEM_ROLE_PERMISSION();
            role_permission.ROLE_CODE = role.CODE;
            role_permission.PERMISSION_CODE = permission.CODE;
            permission.OCD = DateTime.Now;

            return await _rolePermissionDAO.InsertAsync(role_permission, transaction);
        }

        private async Task<bool> DeleteAuthority(string roleCode, IDbTransaction transaction)
        {
            return await _rolePermissionDAO.DeleteByRole(roleCode, transaction);
        }

        private async Task<bool> StartUsing(string roleCode)
        {
            UpdateModel model = new UpdateModel();
            model.SetCollection.Add("isuse", ((int)Judge.YES).ToString());
            model.WhereCollection.Add("code", roleCode);

            return await _roleDAO.EditAsync(model);
        }

        private async Task<bool> Forbidden(string roleCode)
        {
            UpdateModel model = new UpdateModel();
            model.SetCollection.Add("isuse", ((int)Judge.NO).ToString());
            model.WhereCollection.Add("code", roleCode);

            return await _roleDAO.EditAsync(model);
        }
    }
}
