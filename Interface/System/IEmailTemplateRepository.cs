using DateModel.System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Interface.System
{
    public interface IEmailTemplateRepository : IBaseRepository
    {
        Task<string> Insert(T_EMAIL_TEMPLATE entity, IDbTransaction transaction = null);

        Task<bool> Edit(Dictionary<string, object> setting, Dictionary<string, object> where, IDbTransaction transaction = null);

        Task<bool> Delete(string templateCode, IDbTransaction transaction = null);

        Task<int> Count(T_EMAIL_TEMPLATE entity);

        Task<IEnumerable<T_EMAIL_TEMPLATE>> GetGroupWithPaging(T_EMAIL_TEMPLATE entity, int pageIndex, int pageSize);
    }
}
