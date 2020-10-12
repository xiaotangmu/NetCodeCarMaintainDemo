using Entity.Sys;
using Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Interface.System
{
    public interface IRoleDAO : IBaseRepository, ICommonOperation
    {
        Task<IEnumerable<T_SYSTEM_ROLE>> GetValidAsync();

        Task<T_SYSTEM_ROLE> GetAsync(string code);

        Task<bool> DeleteAsync(string code, IDbTransaction transaction = null);

        Task<bool> IsUseRole(string code);

        Task<IEnumerable<T_SYSTEM_ROLE>> GetRolesByLoginName(string loginName);
    }
}
