using DapperExtensions;
using DateModel.System;
using Interface.System;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DAO.System
{
    public class SystemConfigurationRepository : BaseDAO, ISystemConfigurationRepository
    {
        public SystemConfigurationRepository() : base() { }

        public SystemConfigurationRepository(IDataRepository repository) : base(repository) { }

        public async Task<T_SYSTEM_CONFIGURATION> GetAsync(string code)
        {
            var predicateCode = Predicates.Field<T_SYSTEM_CONFIGURATION>(exp => exp.CONFIG_CODE, Operator.Eq, code);
            return await Repository.GetFirstAsync<T_SYSTEM_CONFIGURATION>(predicateCode);
        }

        public async Task<string> AddAsync(T_SYSTEM_CONFIGURATION config, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync(config, transaction);
        }

        public async Task<bool> Clear(IDbTransaction transaction)
        {
            return await Repository.DeleteAsync<T_SYSTEM_CONFIGURATION>(null, transaction) > 0 ? true : false;
        }
    }
}
