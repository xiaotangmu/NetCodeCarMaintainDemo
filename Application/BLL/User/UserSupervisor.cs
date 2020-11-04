using DAO.User;
using DateModel.User;
using Interface.Sku;
using Supervisor.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.CustomException;
using ViewModel.User;

namespace BLL.User
{
    public class UserSupervisor : BaseBLL, IUserSupervisor
    {
        public IUserRepository _userDao;
        public UserSupervisor(IUserRepository userDao = null)
        {
            _userDao = InitDAO<UserDao>(userDao) as IUserRepository;
        }

        public async Task<bool> Login(UserAddModel model)
        {
            // 1. 判断是否已经存在该用户
            bool res = await IsExistUserName(model.UserName);
            if (!res)
            {
                throw new MyServiceException("该用户不存在");
            }
            // 2. 判断是否密码正确
            bool res2 = await _userDao.IsExistUserByNameAndPwd(model);
            if (!res2)
            {
                throw new MyServiceException("密码错误");
            }
            // 3. 认证授权
            return true;
        }

        public async Task<string> Register(UserAddModel model)
        {
            // 1. 判断是否已经存在该用户
            bool res = await IsExistUserName(model.UserName);
            if (res)
            {
                throw new MyServiceException(MsgCode.SameData, "该用户已经存在");
            }
            // 2. 保存用户
            UMS_USER entity = ModelToEntityNoId(model);
            return await _userDao.Insert(entity);
        }

        /// <summary>
        /// 判断该用户名是否已经存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public async Task<bool> IsExistUserName(string UserName)
        {
            return await _userDao.IsExistUserName(UserName);
        }
        public UMS_USER ModelToEntityNoId(UserAddModel model = null)
        {
            return new UMS_USER
            {
                USER_NAME = model?.UserName,
                PWD = model?.Pwd,
                LUD = DateTime.Now
            };
        }
    }
}
