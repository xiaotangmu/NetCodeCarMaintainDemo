using DAO;
using DapperExtensions;
using Entity.Sys;
using ORM;
using System.Data;
using System.Threading.Tasks;

namespace Interface.System
{
    /// <summary>
    /// 角色权限数据管理
    /// </summary>
    public class RolePermissionDAO : BaseDAO, IRolePermissionDAO
    {
        public RolePermissionDAO() : base() { }

        public RolePermissionDAO(IDataRepository repository) : base(repository) { }

        public async Task<bool> InsertAsync(T_SYSTEM_ROLE_PERMISSION permission, IDbTransaction transaction = null)
        {
            return !string.IsNullOrEmpty(await Repository.InsertAsync(permission, transaction)) ? true : false;
        }

        public async Task<bool> DeleteByRole(string roleCode, IDbTransaction transaction = null)
        {
            var predicateRoleCode = Predicates.Field<T_SYSTEM_ROLE_PERMISSION>(exp => exp.ROLE_CODE, Operator.Eq, roleCode);
            return await Repository.DeleteAsync<T_SYSTEM_ROLE_PERMISSION>(predicateRoleCode, transaction) > 0 ? true : false;
        }

        public async Task<bool> IsExist(string roleCode)
        {
            var predicateRoleCode = Predicates.Field<T_SYSTEM_ROLE_PERMISSION>(exp => exp.ROLE_CODE, Operator.Eq, roleCode);
            return await Repository.CountAsync<T_SYSTEM_ROLE_PERMISSION>(predicateRoleCode) > 0 ? true : false;
        }
    }
}
