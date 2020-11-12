using DAO.Spu;
using DataModel;
using DateModel.Spu;
using Interface;
using Supervisor.Spu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.CustomException;
using ViewModel.Spu;

namespace BLL.Spu
{
    public class SpuSupervisor: BaseBLL, ISpuSupervisor
    {
        public ISpuRepository _spuDao;
        public SpuSupervisor(ISpuRepository spuDao = null)
        {
            _spuDao = InitDAO<SpuDao>(spuDao) as ISpuRepository;
        }

        public async Task<string> Add(SpuAddModel model)
        {
            // 1. 判断属性和属性值是否重复
            IEnumerable<SpuAttrModel> spuAttrModelList = model.SpuAttrModelList;
            IsAttrRepeatedThrowException(spuAttrModelList);
            // 3. 判断该spu 是否已经存在
            await IsExistSpuThrowException(model);
            return await _spuDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 4. 添加产品
                string SpuId = await _spuDao.Add(ModelToEntityNoId(model), transaction);

                // 5. 添加属性
                await AddSpuAttrAndAttrValue(spuAttrModelList, SpuId, transaction);
                return SpuId;
            });
        }

        public async Task<bool> Delete(string SpuId)
        {
            return await _spuDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 1. 删除关联属性和属性值
                await DeleteAttrAndAttrValueBySpuId(SpuId, transaction);
                // 3. 删除产品
                return await _spuDao.Delete(SpuId, transaction);
            });
        }

        /// <summary>
        /// 分页获取所有
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<SpuListWithPagingModel> GetAllWithPaging(BaseSearchModel model)
        {
            // 2. 搜索
            SpuListWithPagingModel pageModel = await _spuDao.SelectAllWithPaging(model);
            IEnumerable<SpuModel> modelList = pageModel.Items;
            // 放入属性和属性值
            await GetSpuAttrAndAttrValue(modelList);
            return pageModel;
        }

        /// <summary>
        /// 条件分页获取
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<SpuListWithPagingModel> GetSpuListWithPaging(SpuPageSearchModel model)
        {
            // 查询条件没有，查询所有
            if (string.IsNullOrEmpty(model.ProductName) && string.IsNullOrEmpty(model.Catalog2Id))
            {
                return await GetAllWithPaging(model);
            }
            // 2. 搜索
            SpuListWithPagingModel pageModel = await _spuDao.SelectSpuListWithPaging(model);
            IEnumerable<SpuModel> modelList = pageModel.Items;
            // 放入属性和属性值
            await GetSpuAttrAndAttrValue(modelList);
            return pageModel;
        }

        public async Task<bool> Update(SpuModel model)
        {
            // 1. 判断属性是否重复，2. 属性值是否重复
            IEnumerable<SpuAttrModel> spuAttrModelList = model.SpuAttrModelList;
            IsAttrRepeatedThrowException(spuAttrModelList);

            return await _spuDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 3. 删除属性值和属性
                await DeleteAttrAndAttrValueBySpuId(model.Id, transaction);
                // 5. 添加属性和属性值
                await AddSpuAttrAndAttrValue(spuAttrModelList, model.Id, transaction);
                // 7. 更新产品
                return await _spuDao.Update(ModelToEntity(model), transaction);
            });
        }

        /// <summary>
        /// 获取属性和属性值
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SpuModel>> GetSpuAttrAndAttrValue(IEnumerable<SpuModel> modelList)
        {
            foreach (var model in modelList)
            {
                await GetSpuAttrAndAttrValueByOne(model);
            }
            return modelList;
        }
        public async Task GetSpuAttrAndAttrValueByOne(SpuModel model)
        {
            // 1. 获取属性
            IEnumerable<SpuAttrModel> attrList = await _spuDao.SelectAttrBySpuId(model.Id);
            // 2. 获取属性值
            foreach (var attr in attrList)
            {
                IEnumerable<SpuAttrValueModel> valueList = await _spuDao.SelectAttrValueBySpuAttrId(attr.Id);
                attr.ValueList = valueList;
            }
            model.SpuAttrModelList = attrList;
        }
        /// <summary>
        /// 添加属性和属性值
        /// </summary>
        /// <param name="spuAttrModelList"></param>
        /// <param name="SpuId"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task AddSpuAttrAndAttrValue(IEnumerable<SpuAttrModel> spuAttrModelList, string SpuId, IDbTransaction transaction)
        {
            // 5. 添加属性
            foreach (var attr in spuAttrModelList)
            {
                string SpuAttrId = await _spuDao.AddAttr(SpuAttrModelToEntityNoId(attr.AttrId, SpuId), transaction);
                // 6. 添加属性值
                foreach (var value in attr.ValueList)
                {
                    await _spuDao.AddAttrValue(SpuAttrValueModelToEntityNoId(SpuAttrId, value.Value), transaction);
                }
            }
        }
        /// <summary>
        /// 删除Spu属性和属性值
        /// </summary>
        /// <returns></returns>
        public async Task DeleteAttrAndAttrValueBySpuId(string SpuId, IDbTransaction transaction)
        {
            // 1. 删除属性值
            await _spuDao.DeleteSpuAttrValueBySpuId(SpuId, transaction);
            // 2. 删除属性
            await _spuDao.DeleteSpuAttrBySpuId(SpuId, transaction);
        }
        /// <summary>
        /// 判断是否已经存在产品，存在抛出异常
        /// </summary>
        /// <param name="model"></param>
        public async Task IsExistSpuThrowException(SpuAddModel model)
        {
            bool res = await _spuDao.isExist(model);
            if (res)
            {
                throw new MyServiceException(MsgCode.SameData, "该数据已存在");
            }
        }
        /// <summary>
        /// 判断属性和属性值是否重复，重复抛出异常
        /// </summary>
        /// <param name="spuAttrModelList"></param>
        public void IsAttrRepeatedThrowException(IEnumerable<SpuAttrModel> spuAttrModelList)
        {
            if(spuAttrModelList == null || spuAttrModelList.Count() == 0)
            {
                return;
            }
            // 1. 判断属性是否重复
            HashSet<string> attrSet = new HashSet<string>();
            foreach (var attr in spuAttrModelList)
            {
                // 2. 判断属性值是否重复
                HashSet<string> valueSet = new HashSet<string>();
                foreach (var value in attr.ValueList)
                {
                    if (!string.IsNullOrEmpty(value.Value))
                    {
                        valueSet.Add(value.Value);
                    }
                }
                if (!valueSet.Count().Equals(attr.ValueList.Count()))
                {
                    throw new MyServiceException(MsgCode.Duplicate_Name, "存在属性值重复");
                }
                if (!string.IsNullOrEmpty(attr.AttrId))
                {
                    attrSet.Add(attr.AttrId);
                }
            }
            if (!attrSet.Count().Equals(spuAttrModelList.Count()))
            {
                throw new MyServiceException(MsgCode.Duplicate_Name, "属性名重复");
            }
        }

        /// <summary>
        /// 将model 转换为表 entity，没有ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PMS_SPU ModelToEntityNoId(SpuAddModel model = null)
        {
            return new PMS_SPU
            {
                CATALOG2_ID = model?.Catalog2Id,
                PRODUCT_NAME = model?.ProductName,
                DESCRIPTION = model?.Description
            };
        }
        /// <summary>
        /// 将model 转换为表 entity 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PMS_SPU ModelToEntity(SpuModel model)
        {
            PMS_SPU entity = ModelToEntityNoId(model);
            entity.ID = model.Id;
            return entity;
        }
        /// <summary>
        /// 将model 转换为表 entity，没有ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PMS_SPU_ATTR SpuAttrModelToEntityNoId(string AttrId, string SpuId)
        {
            return new PMS_SPU_ATTR
            {
                ATTR_ID = AttrId,
                SPU_ID = SpuId,
            };
        }
        /// <summary>
        /// 将model 转换为表 entity 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PMS_SPU_ATTR SpuAttrModelToEntity(SpuAttrModel model, string SpuId)
        {
            PMS_SPU_ATTR entity = SpuAttrModelToEntityNoId(model.AttrId, SpuId);
            entity.ID = model.Id;
            return entity;
        }
        /// <summary>
        /// 将model 转换为表 entity，没有ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PMS_SPU_ATTR_VALUE SpuAttrValueModelToEntityNoId(string SpuAttrId, string Value)
        {
            return new PMS_SPU_ATTR_VALUE
            {
                SPU_ATTR_ID = SpuAttrId,
                VALUE = Value
            };
        }
        /// <summary>
        /// 将model 转换为表 entity 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PMS_SPU_ATTR_VALUE SpuAttrValueModelToEntity(SpuAttrValueModel model, string SpuAttrId)
        {
            PMS_SPU_ATTR_VALUE entity = SpuAttrValueModelToEntityNoId(SpuAttrId, model.Value);
            entity.ID = model.Id;
            return entity;
        }

        public async Task<IEnumerable<SpuModel>> GetAll()
        {
            IEnumerable<SpuModel> modelList = await _spuDao.GetAll();
            // 放入属性和属性值
            await GetSpuAttrAndAttrValue(modelList);
            return modelList;
        }

        public async Task<IEnumerable<SpuModel>> GetListByCatalog2Id(string Catalog2Id)
        {
            IEnumerable<SpuModel> modelList = await _spuDao.GetListByCatalog2Id(Catalog2Id);
            // 放入属性和属性值
            await GetSpuAttrAndAttrValue(modelList);
            return modelList;
        }

        public async Task<IEnumerable<SpuAttrModel>> GetSpuAttrListBySpuId(string spuId)
        {
            IEnumerable<SpuAttrModel> attrList = await _spuDao.SelectAttrBySpuId(spuId);
            foreach(var item in attrList)
            {
                item.ValueList = await _spuDao.SelectAttrValueBySpuAttrId(item.Id);
            }
            return attrList;
        }

        public async Task<SpuModel> GetSpuById(string id)
        {
            SpuModel model = await _spuDao.SelectSpuById(id);
            if(model != null)
            {
                await GetSpuAttrAndAttrValueByOne(model);
            }
            return model;
        }
    }
}
