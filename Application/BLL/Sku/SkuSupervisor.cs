using DAO.Sku;
using DataModel;
using DateModel.Sku;
using Interface.Sku;
using NPOI.SS.Formula;
using Supervisor.Sku;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.CustomException;
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
            // 判断属性值和地址是否重复
            IsAttrOrAddressRepeatedThrowException(model.attrList, model.addressList);
            // 判断sku 是否已经存在
            await IsExistSkuThrowException(model);
            return await _skuDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 添加sku
                string skuId = await _skuDao.Insert(ModelToEntityNoId(model), transaction);
                // 添加属性值
                await AddSpuAttrValue(model.attrList, skuId, transaction);
                // 添加位置并统计总数量
                int count = await AddSpuAddressAndCountQuantity(model.addressList, skuId, transaction);
                if(!count.Equals(model.TotalCount)) // 不更新，交由前端修改
                {
                    throw new MyServiceException(MsgCode.Data_Failure, "提交的数据有误，总数不一");
                }
                return skuId;
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
                await DeleteAttrValueBySkuId(id, transaction);
                // 删除地址
                await DeleteAddressBySkuId(id, transaction);
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
            // 搜索
            IEnumerable<SkuModel> modelList = await _skuDao.SelectAll();
            // 放入属性值
            await GetSkuAttrList(modelList);
            // 放入地址
            await GetSkuAddressList(modelList);
            return modelList;
        }

        /// <summary>
        /// 条件获取库存，不分页
        /// </summary>
        /// <param name="searchStr"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SkuModel>> GetListBySearch(string searchStr)
        {
            // 查询条件没有，查询所有
            if (string.IsNullOrEmpty(searchStr))
            {
                return await GetAll();
            }
            // 2. 搜索
            IEnumerable<SkuModel> modelList = await _skuDao.SelectListBySearch(searchStr);
            // 放入属性值
            await GetSkuAttrList(modelList);
            // 放入地址
            await GetSkuAddressList(modelList);
            return modelList;
        }

        /// <summary>
        /// 分页获取库存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<SkuListWithPagingViewModel> GetListPage(BaseSearchModel model)
        {
            // 搜索
            SkuListWithPagingViewModel pageModel = await _skuDao.SelectListPage(model);
            IEnumerable<SkuModel> modelList = pageModel.Items;
            // 放入属性值
            await GetSkuAttrList(modelList);
            // 放入地址
            await GetSkuAddressList(modelList);
            return pageModel;
        }

        /// <summary>
        /// 分页条件获取库存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<SkuListWithPagingViewModel> GetListPageBySearch(SkuListSearchModel model)
        {
            // 搜索
            SkuListWithPagingViewModel pageModel = await _skuDao.SelectListPageBySearch(model);
            IEnumerable<SkuModel> modelList = pageModel.Items;
            // 放入属性值
            await GetSkuAttrList(modelList);
            // 放入地址
            await GetSkuAddressList(modelList);
            return pageModel;
        }
        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SkuModel>> GetSkuAttrList(IEnumerable<SkuModel> modelList)
        {
            foreach (var model in modelList)
            {
                // 1. 获取属性值
                IEnumerable<SkuAttrModel> attrList = await _skuDao.SelectAttrBySkuId(model.Id);
                model.attrList = attrList;
            }
            return modelList;
        }
        /// <summary>
        /// 获取地址
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SkuModel>> GetSkuAddressList(IEnumerable<SkuModel> modelList)
        {
            foreach (var model in modelList)
            {
                // 1. 获取地址
                IEnumerable<SkuAddressModel> addressList = await _skuDao.SelectAddressBySkuId(model.Id);
                model.addressList = addressList;
            }
            return modelList;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Update(SkuModel model)
        {
            // 判断是否已经存在
            await IsExistSkuThrowException(model, model.Id);
            return await _skuDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 全删属性值
                await DeleteAttrValueBySkuId(model.Id, transaction);
                await DeleteAddressBySkuId(model.Id, transaction);

                // 添加属性值
                await AddSpuAttrValue(model.attrList, model.Id, transaction);
                int total = await AddSpuAddressAndCountQuantity(model.addressList, model.Id, transaction);
                model.TotalCount = total;
                // 更新库存表
                return await _skuDao.Update(ModelToEntity(model), transaction);
            });
        }

        /// <summary>
        /// 添加属性值
        /// </summary>
        /// <returns></returns>
        public async Task AddSpuAttrValue(IEnumerable<SkuAttrModel> spuAttrModelList, string SpuId, IDbTransaction transaction)
        {
            // 添加属性值
            foreach (var attr in spuAttrModelList)
            {
                string SpuAttrId = await _skuDao.AddAttrValue(SkuAttrModelToEntityNoId(attr, SpuId), transaction);
            }
        }
        public async Task<int> AddSpuAddressAndCountQuantity(IEnumerable<SkuAddressModel> skuAddressModelList, string SpuId, IDbTransaction transaction)
        {
            int count = 0;
            // 添加属性值
            foreach (var address in skuAddressModelList)
            {
                string SpuAttrId = await _skuDao.AddAdress(SkuAddressModelToEntityNoId(address, SpuId), transaction);
                count += address.Quantity;
            }
            return count;
        }
        /// <summary>
        /// 删除Sku属性值
        /// </summary>
        /// <returns></returns>
        public async Task DeleteAttrValueBySkuId(string SkuId, IDbTransaction transaction = null)
        {
            // 1. 删除属性值
            await _skuDao.DeleteSkuAttrValueBySkuId(SkuId, transaction);
        }
        public async Task DeleteAddressBySkuId(string SkuId, IDbTransaction transaction = null)
        {
            // 1. 删除位置
            await _skuDao.DeleteSkuAddressBySkuId(SkuId, transaction);
        }
        /// <summary>
        /// 判断是否已经存在sku，存在抛出异常
        /// </summary>
        /// <param name="model"></param>
        public async Task IsExistSkuThrowException(SkuAddModel model, string skuId = null)
        {
            // 1. 判断sku 名，品牌，单位, 状态，是否工具是否相同
            IEnumerable<SkuModel> modelList = await _skuDao.GetSameSku(model);
            if(modelList == null || modelList.Count() == 0)
            {
                return;
            }
            List<string> list1 = new List<string>();
            foreach(var attr in model.attrList)
            {
                list1.Add(attr.SpuAttrValueId);
            }
            list1.Sort();

            // 2. 判断sku 规格是否相同
            foreach (var sku in modelList)
            {
                // 过滤本身
                if(skuId != null && sku.Id.Equals(skuId))
                {
                    continue;
                }
                IEnumerable<SkuAttrModel> attrList = await _skuDao.SelectAttrBySkuId(sku.Id);

                if (attrList == null && model.attrList == null)
                {
                    throw new MyServiceException(MsgCode.SameData, "该数据已存在");
                }
                if(attrList != null && attrList.Count().Equals(model.attrList.Count()))
                {
                    List<string> list2 = new List<string>();
                    foreach(var attr in attrList)
                    {
                        list2.Add(attr.SpuAttrValueId);
                    }
                    // 数量相同，进一步判断值
                    list2.Sort();
                    if (list1.SequenceEqual(list2))
                    {
                        throw new MyServiceException(MsgCode.SameData, "该数据已存在");
                    }
                }
            }
        }
        /// <summary>
        /// 判断属性和属性值是否重复，重复抛出异常
        /// </summary>
        /// <param name="spuAttrModelList"></param>
        public void IsAttrOrAddressRepeatedThrowException(IEnumerable<SkuAttrModel> attrlList, IEnumerable<SkuAddressModel> addresslList)
        {
            // 1. 判断属性值是否重复
            if (attrlList != null && attrlList.Count() > 0)
            {
                
                HashSet<string> attrSet = new HashSet<string>();
                foreach (var attr in attrlList)
                {

                    if (!string.IsNullOrEmpty(attr.SpuAttrValueId))
                    {
                        attrSet.Add(attr.SpuAttrValueId);
                    }
                }
                if (!attrSet.Count().Equals(attrlList.Count()))
                {
                    throw new MyServiceException(MsgCode.Duplicate_Name, "属性重复");
                }
            }
            // 2. 判断位置是否重复
            if (addresslList != null && addresslList.Count() > 0)
            {
                HashSet<string> attrSet = new HashSet<string>();
                for (int i = 0; i < addresslList.Count(); i++)
                {
                    for (int j = i + 1; j < addresslList.Count(); j++)
                    {
                        SkuAddressModel address1 = addresslList.ToList()[i];
                        SkuAddressModel address2 = addresslList.ToList()[j];
                        if(address1.Room.Equals(address2.Room) && address1.Self.Equals(address2.Self) && address1.Status.Equals(address2.Status))
                        {
                            throw new MyServiceException(MsgCode.Duplicate_Name, "位置重复，请先合并再操作");
                        }
                    }
                }
            }
        }
        public SMS_SKU_ADDRESS SkuAddressModelToEntityNoId(SkuAddressModel model = null, string SkuId = null)
        {
            return new SMS_SKU_ADDRESS
            {
                SKU_ID = SkuId,
                ROOM = model?.Room,
                SELF = model?.Self,
                PRICE = (decimal)model?.Price,
                STATUS = (int)model?.Status,
                OLD_PARTID = model?.OldPartId,
                QUANTITY = (int)model?.Quantity
            };
        }
        public SMS_SKU_ATTR_VALUE SkuAttrModelToEntityNoId(SkuAttrModel model = null, string SkuId = null)
        {
            return new SMS_SKU_ATTR_VALUE
            {
                SKU_ID = SkuId,
                SPU_ATTR_VALUE_ID = model?.SpuAttrValueId
            };
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
                BRAND = model?.Brand,
                PRICE = (decimal)model?.Price,
                UNIT = model?.Unit,
                TOTAL_COUNT = (int)model?.TotalCount,
                ALARM = (int)model?.Alarm,
                DESCRIPTION = model?.Description,
                TOOL = (int)model?.Tool,
                CATALOG2_ID = model?.Catalog2Id,
                SPU_ID = model?.SpuId
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

        public async Task<SkuModel> GetSkuById(string id)
        {
            // 搜索
            SkuModel model = await _skuDao.SelectSkuById(id);
            if(model != null)
            {
                // 1. 获取属性值
                IEnumerable<SkuAttrModel> attrList = await _skuDao.SelectAttrBySkuId(id);
                model.attrList = attrList;
                // 1. 获取地址
                IEnumerable<SkuAddressModel> addressList = await _skuDao.SelectAddressBySkuId(model.Id);
                model.addressList = addressList;
            }
            return model;
        }

        public async Task<IEnumerable<SkuAddressModel>> GetSkuAddressListBySkuId(string id)
        {
            return await _skuDao.SelectAddressBySkuId(id);
        }
        public async Task<IEnumerable<SkuAttrModel>> GetSkuAttrListBySkuId(string id)
        {
            return await _skuDao.SelectAttrBySkuId(id);
        }
    }
}
