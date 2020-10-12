using DataModel;
using DataModel.System;
using Entity.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Interface.System
{
    public interface IUserRepository: IBaseRepository, ICommonOperation
    {
        Task<bool> AddUserRoleAsync(string account, string roleCode, IDbTransaction transaction = null);
        Task<bool> DeleteAsync(string loginName);
        Task<bool> DelUserRoleAsync(string account, IDbTransaction transaction = null);
        Task<T_SYSTEM_USER> GetByLoginNameAsync(string loginName);
        Task<IEnumerable<T_SYSTEM_USER>> GetValidUserGroup();
        Task<bool> IsExitsUser(string loginName);
        Task<bool> IsOpen(string loginName);
    }
}
