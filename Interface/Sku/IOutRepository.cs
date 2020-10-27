using DateModel.Sku;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Sku;

namespace Interface.Sku
{
    public interface IOutRepository : IBaseRepository
    {
        Task<bool> IsExistByOutNo(string outNo);
        Task<string> Insert(SMS_OUT sMS_OUT, IDbTransaction transaction);
        Task<bool> UpdateAddressSkuNumByAddressId(OutSkuAddModel outSku, IDbTransaction transaction);
        //Task<bool> UpdateSkuTotalCount(string skuId, IDbTransaction transaction);
        Task<string> AddOutSku(SMS_OUT_SKU entity, IDbTransaction transaction);
        Task<IEnumerable<OutModel>> GetAll();
        Task<OutListWithPagingModel> GetOutPageBySearch(OutPageSearchModel model);
        Task<IEnumerable<SkuModel>> GetListOutSkuByOutId(string id);
        Task<IEnumerable<SkuModel>> GetListOutSkuToolByOutId(string Id);
        Task<bool> UpdateDescriptionByOutId(string outId, string description);
        Task<bool> CheckSkuIsEnough(OutSkuAddModel outSku);
        Task<bool> DeleteOutSkuByOutId(string outId, IDbTransaction transaction = null);
        Task<bool> DeleteOutById(string Id, IDbTransaction transaction = null);
        Task<bool> UpdateOut(OutUpdateModel model, IDbTransaction transaction);
    }
}
