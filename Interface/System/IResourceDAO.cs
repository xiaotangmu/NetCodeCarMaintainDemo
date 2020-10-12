using DataModel.System;
using Entity.Sys;
using Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interface.System
{
    public interface IResourceDAO : IBaseRepository, ICommonOperation
    {
        Task<IEnumerable<T_SYSTEM_RESOURCE>> GetAllAsync();

        Task<T_SYSTEM_RESOURCE> GetAsync(string code);

        Task<bool> Delete(string code);

        Task<IEnumerable<T_SYSTEM_RESOURCE>> GetByPermission(string permissionCode);

        Task<IEnumerable<T_SYSTEM_RESOURCE>> GetPermissionMenus(string loginName);

        Task<IEnumerable<T_SYSTEM_RESOURCE>> GetAllAsync(ResourceSearchConditionModel searchModel);
    }
}
