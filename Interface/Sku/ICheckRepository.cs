using DateModel.Sku;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.Sku;

namespace Interface.Sku
{
    public interface ICheckRepository : IBaseRepository
    {
        Task<string> Insert(SMS_CHECK sMS_CHECK, IDbTransaction transaction = null);
        Task<IEnumerable<CheckModel>> SelectAll();
        Task<string> InsertCheckSku(SMS_CHECK_SKU sMS_CHECK_SKU, IDbTransaction transaction = null);
        Task<bool> IsExistByCheckNo(string checkNo);
        Task<IEnumerable<CheckSkuModel>> SelectCheckSkuByCheckId(string id);
        Task<PageModel<CheckModel>> GetCheckPageBySearch(CheckPageSearchModel model);
        Task<bool> UpdateCheckStatusById(CheckUpdateModel model, IDbTransaction transaction = null);
        Task<bool> UpdateCheckSkuStatusByCheckId(string id, IDbTransaction transaction = null);
        Task<bool> UpdateCheckSkuStatus(CheckUpdateModel model, IDbTransaction transaction = null);
        Task<bool> HasCheckSkuToDealByCheckSkuId(string CheckSkuId, IDbTransaction transaction = null);
        Task<bool> UpdateCheckStatusByCheckSkuId(string id, IDbTransaction transaction = null);
    }
}
