using Entity.Sys;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Interface.System
{
    public interface IPermissionDAO : IBaseRepository,ICommonOperation
    {
        Task<IEnumerable<T_SYSTEM_PERMISSION>> GetPermissionByRoleAsync(string roleCode);

        //Task<IEnumerable<SearchPermissionModel>> GetAllAuthorityAsync();

        Task<T_SYSTEM_PERMISSION> GetAsync(string permissionCode);

        Task<bool> DeleteAsync(string code, IDbTransaction transaction);
        Task<IEnumerable<T_SYSTEM_PERMISSION>> GetAllAsync(string menuCode);
    }
}
