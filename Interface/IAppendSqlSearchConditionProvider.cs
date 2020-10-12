using DataModel.System;
using System.Threading.Tasks;

namespace Interface
{
    public interface IAppendSqlSearchConditionProvider
    {
        Task<string> AppendSqlSearchConditionAsync(CurrentUserInfo userInfo);
    }
}