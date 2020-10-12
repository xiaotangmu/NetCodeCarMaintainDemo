using DAO;
using ORM;
using System.Threading.Tasks;

namespace Interface.System
{
    public class AuthorizationDAO : BaseDAO
    {
        public AuthorizationDAO() : base() { }

        public AuthorizationDAO(IDataRepository repository) : base(repository) { }

        public async Task<bool> IsAuthorizedForUser(string resourcePath, string account)
        {
            string sql = @"SELECT COUNT(*) FROM t_system_userrole WHERE user_code IN 
                                                 (SELECT id FROM t_system_user WHERE account='{0}' AND isuse='1') AND role_code IN
																		(SELECT role_code FROM t_system_role_permission WHERE permission_code IN
																		(SELECT permission_code FROM t_system_permission_resource WHERE resource_code IN 
																		(SELECT code FROM t_system_resource WHERE url='{1}' AND type='2')))";

            return await Repository.CountAsync(string.Format(sql, account, resourcePath)) > 0 ? true : false;
        }
    }
}
