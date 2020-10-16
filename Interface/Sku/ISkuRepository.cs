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
        Task<IEnumerable<SkuModel>> SelectListPageBySearch(SkuListSearchModel model);
        Task<IEnumerable<SkuModel>> SelectListPage(BaseSearchModel model);
        Task<IEnumerable<SkuModel>> SelectListBySearch(string searchStr);
        Task<IEnumerable<SkuModel>> SelectAll();
        Task<bool> Delete(string id, IDbTransaction transaction = null);
        Task<string> Insert(SMS_SKU sMS_SKU, IDbTransaction transaction = null);
    }
}
