using Common.Encryption;
using Common.Encryption.Core;
using DAO.System;
using DataAccess;
using DataModel.System;
using Entity.Sys;
using Interface.System;
using Localization;
using NPOI.SS.UserModel;
using ORM;
using Supervisor.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.System
{
    public class UserManagement : BaseBLL, IUserSupervisor
    {
        private IUserRepository _userDAO;
        private IRoleDAO _roleDAO;

        public UserManagement(IUserRepository userDAO = null, IRoleDAO roleDAO = null)
        {
            _userDAO = InitDAO<UserDAO>(userDAO) as IUserRepository;
            _roleDAO = InitDAO<RoleDAO>(roleDAO) as IRoleDAO;
        }

        public async Task<string> AddUser(UserModel data, CurrentUserInfo userInfo)
        {
            T_SYSTEM_USER user = new T_SYSTEM_USER
            {
                ACCOUNT = data?.Account,
                NAME = data.Name,
                CREATE_TIME = DateTime.Now,
            };
            string result = string.Empty;
            try
            {
                result = await _userDAO.InsertAsync(user);
            }
            catch (Npgsql.PostgresException ex)
            {
                throw await ContrainExceptionFactory.Singleton.Create<T_SYSTEM_USER>(ex);
            }
            return result;
        }

        public async Task<bool> DeleteUser(string loginName)
        {
            await IfOpenAndThrowException(loginName);

            return await _userDAO.DeleteAsync(loginName);
        }

        public async Task<UserPageViewModel> QueryPageAsync(UserSearchModel model)
        {
            UserPageViewModel resultModel = new UserPageViewModel();
            resultModel.TotalCount = await _userDAO.GetCount(model);
            if (resultModel.TotalCount == 0)
            {
                return resultModel;
            }
            var data = await _userDAO.GetPageAsync<T_SYSTEM_USER>(model);
            if (data == null)
            {
                return resultModel;
            }
            foreach (var user in data)
            {
                resultModel.Items.Add(GetUserViewModel(user));
            }
            return resultModel;
        }

        public async Task<bool> IsExitsUser(UserModel user)
        {
            return await _userDAO.IsExitsUser(user.Account);
        }

        /// <summary>
        /// 判断用户是否是启用状态
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        private async Task IfOpenAndThrowException(string loginName)
        {
            if (await _userDAO.IsOpen(loginName))
            {
                throw new Exception(await Localizer.GetValueAsync("用戶已啓用"));
            }
        }

        /// <summary>
        /// 获取Userid
        /// </summary>
        /// <param name="loginName">用户登录名</param>
        /// <returns></returns>
        public async Task<string> GetUserId(string loginName)
        {
            var result = await _userDAO.GetByLoginNameAsync(loginName);
            if (result != null)
            {
                return result.ID;
            }
            return string.Empty;
        }

        public async Task<List<UserModel>> GetValidUserGroup()
        {
            List<T_SYSTEM_USER> users = (await _userDAO.GetValidUserGroup())?.ToList();
            if (users == null)
            {
                return null;
            }
            List<UserModel> models = new List<UserModel>();
            foreach (var user in users)
            {
                models.Add(new UserModel
                {
                    Account = user.ACCOUNT,
                    Name = user.NAME
                });
            }
            return models;
        }

        public async Task<List<RoleModel>> GetRoles(string loginName)
        {
            var roles = (await _roleDAO.GetRolesByLoginName(loginName))?.ToList();
            if (roles == null || roles.Count == 0)
            {
                return null;
            }
            List<RoleModel> models = new List<RoleModel>();
            foreach (var role in roles)
            {
                models.Add(new RoleModel
                {
                    RoleCode = role.CODE,
                    RoleName = role.NAME
                });
            }
            return models;
        }

        public async Task<bool> EnableUser(DeleteUserModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Account))
            {
                throw new Exception(await Localizer.GetValueAsync("Data_Empty"));
            }
            UpdateModel update = new UpdateModel();
            update.SetCollection.Add("isuse", ((int)Judge.YES).ToString());
            update.WhereCollection.Add("account", model.Account);
            return await _userDAO.EditAsync(update);
        }

        public async Task<bool> DisableUser(DeleteUserModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Account))
            {
                throw new Exception(await Localizer.GetValueAsync("Data_Empty"));
            }
            UpdateModel update = new UpdateModel();
            update.SetCollection.Add("isuse", ((int)Judge.NO).ToString());
            update.WhereCollection.Add("account", model.Account);
            return await _userDAO.EditAsync(update);
        }

        public async Task<bool> ModifyUserRoles(ModifyUserRoleModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Account))
            {
                throw new Exception(await Localizer.GetValueAsync("Data_Empty"));
            }
            return await _userDAO.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                return await ModifyUserRolesTransactionExecute(model, transaction);
            });
        }

        private async Task<bool> ModifyUserRolesTransactionExecute(ModifyUserRoleModel model, IDbTransaction transaction)
        {
            //先删除原有的
            bool isSuccessful = await _userDAO.DelUserRoleAsync(model.Account, transaction);
            //再增加新的角色
            if (isSuccessful)
            {
                isSuccessful = await AddRoles(model, transaction);
            }
            return isSuccessful;
        }

        private async Task<bool> AddRoles(ModifyUserRoleModel model, IDbTransaction transaction)
        {
            if (model == null)
            {
                return false;
            }
            bool isSuccess = true;
            foreach (var roleCode in model.RoleCodeGroup)
            {
                isSuccess = await _userDAO.AddUserRoleAsync(model.Account, roleCode, transaction);
                if (isSuccess == false)
                {
                    return isSuccess;
                }
            }
            return isSuccess;
        }

        private UserViewMode GetUserViewModel(T_SYSTEM_USER user)
        {
            UserViewMode model = new UserViewMode();
            model.Account = user.ACCOUNT;
            model.Name = user.NAME;
            model.IsUse = user.ISUSE.Equals(((int)Judge.YES).ToString()) ? true : false;
            return model;
        }
    }
}
