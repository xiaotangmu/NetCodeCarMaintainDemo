using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.Maintain;

namespace Supervisor.Maintain
{

    public interface IMaintainSupervisor
    {
        Task<string> Add(MaintainAddModel model);
        Task<bool> Update(MaintainModel model);
        Task<bool> Delete(string id);
        Task<bool> DeleteBatch(IEnumerable<MaintainDeleteModel> modelList);
        Task<IEnumerable<MaintainShowModel>> GetAll();
        Task<PageModel<MaintainShowModel>> GetListPageBySearch(MaintainPageSearchModel model); 
        Task<bool> UpdateTool(MaintainToolUpdateModel model);
        Task<bool> UpdateOldPart(MaintainOldPartUpdateModel model);
        Task<bool> UpdateToolList(IEnumerable<MaintainToolUpdateModel> modelList);
        Task<bool> UpdateOldPartList(IEnumerable<MaintainOldPartUpdateModel> modelList);
        Task<bool> UpdateMaintainNoRelation(MaintainModel model);
    }
}
