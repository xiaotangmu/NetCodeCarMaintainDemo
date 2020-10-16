using DAO.Catalog;
using DateModel.Catalog;
using Interface.Catalog;
using Supervisor.Catalog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Common;
using ViewModel.CustomException;

namespace BLL.Catalog
{
    /// <summary>
    /// 属性管理
    /// </summary>
    public class AttrSupervisor : BaseBLL, IAttrSupervisor
    {
        private IAttrRepository _attrDao;
        public AttrSupervisor(IAttrRepository attrRepository = null)
        {
            _attrDao = InitDAO<AttrDao>(attrRepository) as IAttrRepository;
        }

        public async Task<string> Add(AttrAddModel model)
        {
            // 判断是否已经存在
            await IsExistThrowException(model);
            return await _attrDao.Add(ModelToEntityNoId(model));
        }

        public async Task<bool> Delete(string id)
        {
            return await _attrDao.Delete(id);
        }

        public async Task<IEnumerable<AttrModel>> GetListByCatalogId(string catalogId)
        {
            return await _attrDao.SelectListByCatalogId(catalogId);
        }

        public async Task<bool> Update(AttrModel model)
        {
            return await _attrDao.Update(ModelToEntity(model));
        }

        /// <summary>
        /// 将model 转换为表 entity，没有ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BMMS_CATALOG_ATTR ModelToEntityNoId(AttrAddModel model = null)
        {
            return new BMMS_CATALOG_ATTR
            {
                ATTR_NAME = model?.AttrName,
                CATALOG_ID = model?.CatalogId
            };
        }
        /// <summary>
        /// 将model 转换为表 entity 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BMMS_CATALOG_ATTR ModelToEntity(AttrModel model)
        {
            BMMS_CATALOG_ATTR entity = ModelToEntityNoId(model);
            entity.ID = model.Id;
            return entity;
        }
        public IEnumerable<BMMS_CATALOG_ATTR> ModelListToEntityListNoId(IEnumerable<AttrAddModel> models)
        {
            List<BMMS_CATALOG_ATTR> entityList = new List<BMMS_CATALOG_ATTR>();
            foreach (var model in models)
            {
                entityList.Add(ModelToEntityNoId(model));
            }
            return entityList;
        }
        public IEnumerable<BMMS_CATALOG_ATTR> ModelListToEntityList(IEnumerable<AttrModel> models)
        {
            List<BMMS_CATALOG_ATTR> entityList = new List<BMMS_CATALOG_ATTR>();
            foreach(var model in models)
            {
                entityList.Add(ModelToEntity(model));
            }
            return entityList;
        }

        /// <summary>
        /// 删除分类下的所有属性
        /// </summary>
        /// <param name="CatalogId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAttrListByCatalog(string CatalogId)
        {
            return await _attrDao.DeleteAttrListByCatalog(CatalogId);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBatch(IEnumerable<AttrModel> models)
        {
            return await _attrDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                List<string> ids = new List<string>();
                foreach (var model in models)
                {
                    ids.Add(model.Id);
                }
                return await _attrDao.DeleteBatch(ids, transaction);
            }); 
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public async Task<bool> AddBatch(IEnumerable<AttrAddModel> models)
        {
            // 判断数据是否重复
            IsExistSameWithInputThrowException(models);
            // 判断是否存在
            foreach (var model in models)
            {
                await IsExistThrowException(model);
            }
            // 插入数据
            return await _attrDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                return await _attrDao.InsertBatch(ModelListToEntityListNoId(models), transaction);
            });
        }

        /// <summary>
        /// 判断是否有相同数据
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsExist(AttrAddModel model)
        {
            // 判断是否已经存在该分类
            IEnumerable<AttrModel> models = await _attrDao.SelectListByCatalogId(model.CatalogId);
            foreach (var item in models)
            {
                if (item.AttrName.Equals(model.AttrName))
                {
                    return true;    // 存在相同数据
                }
            }
            return false;   // 没有相同数据
        }

        /// <summary>
        /// 存在相同数据时抛出异常
        /// </summary>
        /// <returns></returns>
        public async Task IsExistThrowException(AttrAddModel model)
        {
            bool exist = await IsExist(model);
            if (exist)
            {
                throw new MyServiceException(MsgCode.SameData, "存在相同数据");
            }
        }
        /// <summary>
        /// 判断 models 中是否有重复数据
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public void IsExistSameWithInputThrowException(IEnumerable<AttrAddModel> models)
        {
            HashSet<string> hs = new HashSet<string>();
            // 判断数据是否重复
            foreach (var model in models)
            {
                hs.Add(model.AttrName.Trim());
            }
            if (!hs.Count().Equals(models.Count()))
            {
                throw new MyServiceException(MsgCode.SameData, "提交的数据有重");
            }
        }
    }
}
