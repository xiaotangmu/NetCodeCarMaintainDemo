using DateModel.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Interface.System
{
    public interface ISystemConfigurationRepository : IBaseRepository
    {
        Task<string> AddAsync(T_SYSTEM_CONFIGURATION config, IDbTransaction transaction = null);
        Task<T_SYSTEM_CONFIGURATION> GetAsync(string code);
        Task<bool> Clear(IDbTransaction transaction);
    }
}
