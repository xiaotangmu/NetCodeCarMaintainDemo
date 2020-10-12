using DAO.System;
using DataAccess;
using DataModel.System;
using Entity.Sys;
using Interface.System;
using Localization;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.System
{
    public class LoginLogManagement : BaseBLL
    {
        private readonly ILoginLogDAO _loginLogDAO;

        public LoginLogManagement(ILoginLogDAO loginLogDAO = null)
        {
            _loginLogDAO = InitDAO<LoginLogDAO>(loginLogDAO) as ILoginLogDAO;
        }

        /// <summary>
        /// 登入日志记录
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <param name="ip">用户IP</param>
        /// <returns></returns>
        public async Task<bool> LoginLog(CurrentUserInfo userInfo, string ip)
        {
            SYSTEM_LOGIN_LOG log = new SYSTEM_LOGIN_LOG
            {
                IP = ip,
                STATUS = ((int)LoginStatus.IN).ToString(),
                LOGIN_TIME = DateTime.Now,
                LOGIN_NAME = userInfo.Name
            };
            string id = await _loginLogDAO.InsertAsync(log);
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 登出日志记录
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <param name="ip">用户IP</param>
        /// <returns></returns>
        public async Task<bool> LogOutLog(CurrentUserInfo userInfo, string ip)
        {
            if (!await HasLogin(userInfo))
            {
                return false;
            }
            SYSTEM_LOGIN_LOG log = new SYSTEM_LOGIN_LOG
            {
                IP = ip,
                STATUS = ((int)LoginStatus.OUT).ToString(),
                LOGIN_TIME = DateTime.Now,
                LOGIN_NAME = userInfo.Name
            };
            string id = await _loginLogDAO.InsertAsync(log);
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 是否已登录
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public async Task<bool> HasLogin(CurrentUserInfo userInfo)
        {
            SYSTEM_LOGIN_LOG lastRecord = await _loginLogDAO.GetLast(userInfo.Name);
            if (lastRecord == null)
            {
                return false;
            }
            if (lastRecord.STATUS.Equals(((int)LoginStatus.IN).ToString()))
            {
                return true;
            }
            return false;
        }

        public async Task<LoginLogTableModel> Search(LogSearchModel search)
        {
            LoginLogTableModel table = new LoginLogTableModel();
            table.TotalCount = await _loginLogDAO.GetCount(search);
            if (table.TotalCount == 0)
            {
                return table;
            }
            IEnumerable<SYSTEM_LOGIN_LOG> data = await _loginLogDAO.GetPageAsync<SYSTEM_LOGIN_LOG>(search);
            if (data == null)
            {
                return table;
            }
            table.Data = await BuildModels(data);
            return table;
        }

        private async Task<List<LoginLogViewModel>> BuildModels(IEnumerable<SYSTEM_LOGIN_LOG> enumerable)
        {
            List<LoginLogViewModel> models = new List<LoginLogViewModel>();
            foreach (SYSTEM_LOGIN_LOG log in enumerable.ToList())
            {
                LoginLogViewModel model = await BuildModel(log);
                models.Add(model);
            }
            return models;
        }

        private async Task<LoginLogViewModel> BuildModel(SYSTEM_LOGIN_LOG log)
        {
            LoginLogViewModel model = new LoginLogViewModel();
            model.IP = log.IP;
            model.LoginStatus = log.STATUS.Equals(((int)LoginStatus.IN).ToString()) ? await Localizer.GetValueAsync("LoginStatus_Login") : await Localizer.GetValueAsync("LoginStatus_Logout");
            model.LogTime = log.LOGIN_TIME.ToString();
            model.LoginName = log.LOGIN_NAME;
            return model;
        }
    }
}
