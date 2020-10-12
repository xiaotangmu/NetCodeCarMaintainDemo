using DataModel.System;
using Entity.Sys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supervisor.System
{
   public interface IDictSupervisor
    {
        Task<string> Add(AddDictModel model);
        Task<bool> Delete(DeleteDictModel model);
        Task<bool> Delete(string dictType);
        Task<bool> Edit(AddDictModel model);
        Task<List<DictViewModel>> GetChildren(DictSearchPageModel searchModel);
        Task<List<T_SYSTEM_DICT>> GetDictData(string typeCode);
        Task<string> GetDictDataText(string typeCode, string code, bool needLocalize);
        Task<DictPageModel> GetPageList(DictSearchPageModel searchModel);
    }
}
