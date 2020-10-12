using DataAccess;
using Entity.Sys;
using Interface.System;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DAO.System
{
    public class PermissionResourceDAO : BaseDAO, IPermissionResourceDAO
    {
        public PermissionResourceDAO() : base() { }

        public PermissionResourceDAO(IDataRepository repository) : base(repository) { }

        public async Task<bool> InsertTransAsync(List<T_SYSTEM_PERMISSION_RESOURCE> entities, IDbTransaction transaction = null)
        {
            bool result = false;
            if (transaction == null)
            {
                result = await Repository.InsertBatchAsync(entities);
            }
            else
            {
                result = await Repository.InsertBatchAsync(entities, transaction);
            }

            return result;
        }

        public async Task<bool> DeleteByPermission(string permissionCode, IDbTransaction transaction = null)
        {
            string sql = string.Format(" DELETE FROM system_permission_resource WHERE permission_id IN (SELECT id FROM system_permission WHERE code='{0}') ", permissionCode);
            return await Repository.ExecuteAsync(sql, transaction) >= 0;
        }

        public async Task<bool> InsertAsync(string permissionCode, string resourceCode, IDbTransaction transaction = null)
        {
            string id = await Repository.InsertAsync(new T_SYSTEM_PERMISSION_RESOURCE
            {
                PERMISSION_CODE = permissionCode,
                RESOURCE_CODE = resourceCode
            }, transaction);
            return string.IsNullOrEmpty(id) ? false : true;
        }
    }
}
