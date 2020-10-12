using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Sys;

namespace Interface.System
{
    public interface ILoginLogDAO : IBaseRepository
    {
        Task<SYSTEM_LOGIN_LOG> GetLast(string name);
        Task<string> InsertAsync(SYSTEM_LOGIN_LOG log);
        Task<long> GetCount(global::DataModel.System.LogSearchModel search);
        Task<IEnumerable<T>> GetPageAsync<T>(global::DataModel.System.LogSearchModel search);
    }
}
