using DateModel.Maintain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.Maintain;
using ViewModel.Sku;

namespace Interface.Maintain
{
    public interface IMaintainRepository : IBaseRepository
    {
        Task<int> IsExistByMaintainNo(string maintainNo);
        Task<string> Insert(MMS_MAINTAIN mMS_MAINTAIN, IDbTransaction transaction = null);
        Task<string> InsertTool(MMS_MAINTAIN_TOOL mMS_MAINTAIN_TOOL, IDbTransaction transaction = null);
        Task<string> InsertMaintainOut(MMS_MAINTAIN_OUT mMS_MAINTAIN_OUT, IDbTransaction transaction = null);
        Task<string> InsertOldPart(MMS_MAINTAIN_OLDPART mMS_MAINTAIN_OLDPART, IDbTransaction transaction = null);
        Task<bool> HasNoDealToolByMaintainId(string id);
        Task<bool> HasNoDealOlPartByMaintainId(string id);
        Task<bool> IsNoSignByMaintainId(string id);
        Task<bool> DeleteToolByMaintainId(string id, IDbTransaction transaction = null);
        Task<bool> DeleteOldPartByMaintainId(string id, IDbTransaction transaction = null);
        Task<bool> Delete(string id, IDbTransaction transaction);
        Task<bool> UpdateTool(MaintainToolUpdateModel model, IDbTransaction transaction = null);
        Task<IEnumerable<MaintainShowModel>> SelectAll();
        Task<PageModel<MaintainShowModel>> SelectListPageBySearch(MaintainPageSearchModel model);
        Task<bool> HasDealOldPartByMaintainId(string id);
        Task<bool> HasDealToolByMaintainId(string id);
        Task<bool> DeleteMaintainOutByMaintainId(string id, IDbTransaction transaction);
        Task<bool> UpdateMaintainNoRelation(MaintainModel model, IDbTransaction transaction = null);
        Task<bool> UpdateOldPart(MaintainOldPartUpdateModel model, IDbTransaction transaction = null);
        Task<IEnumerable<MaintainToolModel>> GetToolsByMaintainId(string id);
        Task<IEnumerable<SkuAttrModel>> GetToolTypeById(string id);
        Task<IEnumerable<MaintainOldPartModel>> GetOldPartsByMaintainId(string id);
        Task<IEnumerable<SkuAttrModel>> GetOldPartTypeById(string id);
        Task<IEnumerable<SkuModel>> GetSkusByMaintainId(string id);
        Task<bool> DeleteNoDealToolByMaintainId(string id, IDbTransaction transaction);
        Task<bool> DeleteNoDealOldPartByMaintainId(string id, IDbTransaction transaction);
        Task<MaintainEntryShowModel> SelectMaintainInfoById(string id);
        Task<IEnumerable<MaintainShowModel>> GetNoDealToolOrPartWithMaintain();
        Task<MaintainShowModel> SelectMaintainAllInfoById(string id);
    }
}
