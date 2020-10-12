using Entity.Sys;
using Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Interface.System
{
    public interface IRolePermissionDAO : IBaseRepository
    {
        Task<bool> InsertAsync(T_SYSTEM_ROLE_PERMISSION permission, IDbTransaction transaction = null);

        Task<bool> DeleteByRole(string roleCode, IDbTransaction transaction = null);

        Task<bool> IsExist(string roleCode);
    }
}
