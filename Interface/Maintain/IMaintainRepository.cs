using DateModel.Maintain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Maintain
{
    public interface IMaintainRepository : IBaseRepository
    {
        Task<bool> IsExistByMaintainNo(string maintainNo);
        Task<string> Insert(MMS_MAINTAIN mMS_MAINTAIN, IDbTransaction transaction);
        Task InsertTool(MMS_MAINTAIN_TOOL mMS_MAINTAIN_TOOL, IDbTransaction transaction);
        Task InsertMaintainOut(MMS_MAINTAIN_OUT mMS_MAINTAIN_OUT, IDbTransaction transaction);
        Task InsertOldPart(MMS_MAINTAIN_OLDPART mMS_MAINTAIN_OLDPART, IDbTransaction transaction);
    }
}
