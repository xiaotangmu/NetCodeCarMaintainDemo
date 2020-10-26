using DataModel;
using DateModel.Sku;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Sku;

namespace Interface.Sku
{
    public interface ISkuRepository : IBaseRepository
    {
        Task<bool> Update(SMS_SKU sMS_SKU, IDbTransaction transaction = null);
        Task<SkuListWithPagingViewModel> SelectListPageBySearch(SkuListSearchModel model);
        Task<SkuListWithPagingViewModel> SelectListPage(BaseSearchModel model);
        Task<IEnumerable<SkuModel>> SelectListBySearch(string searchStr);
        Task<IEnumerable<SkuModel>> SelectAll();
        Task<bool> Delete(string id, IDbTransaction transaction = null);
        Task<string> Insert(SMS_SKU sMS_SKU, IDbTransaction transaction = null);
        Task<string> AddAttrValue(SMS_SKU_ATTR_VALUE sMS_SKU_ATTR_VALUE, IDbTransaction transaction);
        Task<string> AddAdress(SMS_SKU_ADDRESS sMS_SKU_ADDRESS, IDbTransaction transaction);
        Task<bool> DeleteSkuAttrValueBySkuId(string skuId, IDbTransaction transaction);
        Task<bool> DeleteSkuAddressBySkuId(string skuId, IDbTransaction transaction);
        Task<IEnumerable<SkuModel>> GetSameSku(SkuAddModel model);
        Task<IEnumerable<SkuAttrModel>> SelectAttrBySkuId(string skuId);
        Task<IEnumerable<SkuAddressModel>> SelectAddressBySkuId(string skuId);
        Task<SkuModel> GetSkuById(string skuId);
        Task<bool> UpdateSkuTotalCount(string SkuId, IDbTransaction transaction);
        Task<SkuAddressModel> SelectAddressByAddressId(string AddressId);
        Task<bool> UpdateSkuTotalCountByAddressId(string addressId, IDbTransaction transaction);
        Task<SkuModel> GetSkuByAddressId(string addressId);
    }
}
