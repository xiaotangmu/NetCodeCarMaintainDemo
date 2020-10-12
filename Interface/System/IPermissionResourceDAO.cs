using Entity.Sys;
using Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Interface.System
{
    public interface IPermissionResourceDAO : IBaseRepository
    {
        Task<bool> DeleteByPermission(string permissionCode, IDbTransaction transaction = null);
        Task<bool> InsertAsync(string permissionCode, string resourceCode, IDbTransaction transaction = null);
        Task<bool> InsertTransAsync(List<T_SYSTEM_PERMISSION_RESOURCE> entities, IDbTransaction transaction = null);
    }
}
