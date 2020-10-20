using DataModel;
using DateModel.Spu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Spu;

namespace Interface
{
    public interface ISpuRepository : IBaseRepository
    {
        Task<bool> isExist(SpuAddModel model);
        Task<string> Add(PMS_SPU pMS_SPU, IDbTransaction transaction = null);
        Task<string> AddAttr(PMS_SPU_ATTR pMS_SPU_ATTR, IDbTransaction transaction = null);
        Task<string> AddAttrValue(PMS_SPU_ATTR_VALUE pMS_SPU_ATTR_VALUE, IDbTransaction transaction = null);
        Task<bool> DeleteSpuAttrValueBySpuId(string id, IDbTransaction transaction = null);
        Task<bool> DeleteSpuAttrBySpuId(string id, IDbTransaction transaction = null);
        Task<bool> Delete(string id, IDbTransaction transaction = null);
        Task<SpuListWithPagingModel> SelectAllWithPaging(BaseSearchModel model);
        Task<SpuListWithPagingModel> SelectSpuListWithPaging(SpuPageSearchModel model);
        Task<bool> Update(PMS_SPU entity, IDbTransaction transaction = null);
        Task<IEnumerable<SpuAttrModel>> SelectAttrBySpuId(string SpuId);
        Task<IEnumerable<SpuAttrValueModel>> SelectAttrValueBySpuAttrId(string SpuAttrId);
    }
}
