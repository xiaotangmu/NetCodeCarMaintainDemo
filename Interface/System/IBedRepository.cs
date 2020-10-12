using Domain.DataModel;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Interface.System
{
    public interface IBedRepository : IBaseRepository
    {
        Task<string> AddAsync(T_BED bed, IDbTransaction transaction = null);
        Task<bool> Clear(string roomIndex, IDbTransaction transaction = null);
        Task<IEnumerable<T_BED>> GetGroup(T_BED searchCondition);

        Task<IEnumerable<T_BED>> GetVacantGroup();
    }

}
