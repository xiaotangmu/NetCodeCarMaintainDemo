using DAO.Sku;
using DataModel;
using DateModel.Sku;
using Interface.Sku;
using Supervisor.Sku;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Sku;

namespace BLL.Sku
{
    public class SkuSupervisor: BaseBLL, ISkuSupervisor
    {
        private ISkuRepository _skuDao;
        public SkuSupervisor(ISkuRepository skuDao = null)
        {
            _skuDao = InitDAO<SkuDao>(skuDao) as ISkuRepository;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Add(SkuAddModel model)
        {
            return await _skuDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 添加属性值

                // 添加
                return await _skuDao.Insert(ModelToEntityNoId(model), transaction);
            });
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id)
        {
            return await _skuDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 删除属性值

                // 删除库存
                return await _skuDao.Delete(id, transaction);
            });
            
        }

        /// <summary>
        /// 获取全部库存
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SkuModel>> GetAll()
        {
            return await _skuDao.SelectAll();
        }

        /// <summary>
        /// 条件获取库存，不分页
        /// </summary>
        /// <param name="searchStr"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SkuModel>> GetListBySearch(string searchStr)
        {
            return await _skuDao.SelectListBySearch(searchStr);
        }

        /// <summary>
        /// 分页获取库存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SkuModel>> GetListPage(BaseSearchModel model)
        {
            return await _skuDao.SelectListPage(model);
        }

        /// <summary>
        /// 分页条件获取库存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SkuModel>> GetListPageBySearch(SkuListSearchModel model)
        {
            return await _skuDao.SelectListPageBySearch(model);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Update(SkuModel model)
        {
            return await _skuDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 全删属性值

                // 添加属性值

                // 更新库存表
                return await _skuDao.Update(ModelToEntity(model), transaction);
            });
        }

        /// <summary>
        /// 将model 转换为表 entity，没有ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SMS_SKU ModelToEntityNoId(SkuAddModel model = null)
        {
            return new SMS_SKU
            {
                SKU_NO = model?.SkuNo,
                SKU_NAME = model?.SkuName,
                ROOM = model?.Room,
                SELF = model?.Self,
                BRAND = model?.Brand,
                PRICE = (decimal)model?.Price,
                UNIT = model?.Unit,
                QUANTITY = (int)model?.Quantity,
                ALARM = (int)model?.Alarm,
                DESCRIPTION = model?.Description,
                TYPE = model?.Type,
                STATUS = (int)model?.Status,
                OLD_PARTID = model?.OldPartId,
                CATALOG2_ID = model?.Catalog2Id
            };
        }
        /// <summary>
        /// 将model 转换为表 entity 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SMS_SKU ModelToEntity(SkuModel model)
        {
            SMS_SKU entity = ModelToEntityNoId(model);
            entity.ID = model?.Id;

            //entity.OCD = model?.OCD;
            //entity.OCU = model?.OCU;
            return entity;
        }
    }
}
