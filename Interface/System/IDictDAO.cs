using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Entity.Sys;
using Interface;
using ORM;

namespace Interface.System
{
    public interface IDictDAO : IBaseRepository
    {
        Task<bool> Delete(string typeCode);
        Task<bool> Delete(string code, string typeCode);
        Task<bool> EditAsync(Dictionary<string, object> setting, Dictionary<string, object> where, IDbTransaction transaction = null);
        Task<IEnumerable<T_SYSTEM_DICT>> GetByTypeCodeAsync(string typeCode, string isUse);
        Task<int> GetCount(T_SYSTEM_DICT model);
        Task<string> GetDictCode(string typeCode, string name);
        Task<T_SYSTEM_DICT> GetDictData(string typeCode, string code);
        Task<T> GetEntityByIdAsync<T>(string id) where T : BaseEntity;
        Task<IEnumerable<T>> GetPageAsync<T>(T_SYSTEM_DICT model, int pageIndex, int pageSize);
        Task<string> InsertAsync<T>(T entity, IDbTransaction transaction = null) where T : BaseEntity;
        Task<IEnumerable<T_SYSTEM_DICT>> GetAllAsync(T_SYSTEM_DICT searchCondition);
    }
}
