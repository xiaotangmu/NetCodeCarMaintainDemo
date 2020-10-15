using DAO.Catalog;
using DateModel.Catalog;
using Interface.Catalog;
using Supervisor.Catalog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Catalog;

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
            return await _attrDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                return await _attrDao.InsertBatch(ModelListToEntityListNoId(models), transaction);
            });
        }
    }
}
