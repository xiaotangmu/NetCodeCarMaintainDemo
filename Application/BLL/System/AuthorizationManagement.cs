using Interface.System;
using DataAccess;
using DataModel.System;
using ORM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.System
{
    /// <summary>
    /// 创建人：Xavier
    /// 创建时间：2018-12-19
    /// 描述：权限验证管理器
    /// </summary>
    public class AuthorizationManagement
    {
        private readonly AuthorizationDAO _dao;

        public AuthorizationManagement(IDataRepository repository = null)
        {
            _dao = new AuthorizationDAO(repository);
        }

        /// <summary>
        /// 验证当前用户请求资源是否有权限
        /// </summary>
        /// <param name="resourcePath">资源路径</param>
        /// <param name="currentUser">当前用户</param>
        /// <returns>true/false</returns>
        public async Task<bool> IsAuthorize(string resourcePath, CurrentUserInfo currentUser)
        {
            return await _dao.IsAuthorizedForUser(resourcePath, currentUser.Name);
        }
    }
}
