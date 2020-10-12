using DataModel;
using DataModel.System;
using Entity;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Interface
{
    public interface ICommonOperation
    {
        Task<IEnumerable<T>> GetPageAsync<T>(BaseSearchModel model, CurrentUserInfo userInfo = null, IAppendSqlSearchConditionProvider dataProvider = null) where T : BaseEntity;

        Task<int> GetCount(BaseSearchModel model, CurrentUserInfo userInfo = null, IAppendSqlSearchConditionProvider dataProvider = null);

        Task<T> GetEntityByIdAsync<T>(string id) where T : BaseEntity;

        Task<string> InsertAsync<T>(T entity, IDbTransaction transaction = null) where T : BaseEntity;

        Task<bool> EditAsync(UpdateModel model, IDbTransaction transaction = null);
    }
}
