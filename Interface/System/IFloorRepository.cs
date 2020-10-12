using Domain.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Interface.System
{
    public interface IFloorRepository : IBaseRepository
    {
        Task<IEnumerable<T_FLOOR>> GetGroup();

        Task<string> AddAsync(T_FLOOR room, IDbTransaction transaction = null);

        Task<bool> EditAsync(Dictionary<string, object> setting, Dictionary<string, object> where, IDbTransaction transaction = null);

        Task<bool> DeleteAsync(string code, IDbTransaction transaction = null);
    }
}
