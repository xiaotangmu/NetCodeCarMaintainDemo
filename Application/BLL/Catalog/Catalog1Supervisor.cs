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
    /// 一级分类
    /// </summary>
    public class Catalog1Supervisor: BaseBLL, ICatalog1Supervisor
    {
        private ICatalog1Repository _catalog1Dao;
        private ICatalog2Repository _catalog2Dao;
        private IAttrRepository _attrDao;
        public Catalog1Supervisor(ICatalog1Repository catalog1Dao = null, 
            ICatalog2Repository catalog2Dao = null, IAttrRepository attrDao = null)    // 不能少了默认值 null
        {
            _catalog1Dao = InitDAO<Catalog1Dao>(catalog1Dao) as ICatalog1Repository;
            //_catalog2Dao = InitDAO<Catalog2Dao>(catalog2Dao) as ICatalog2Repository;
            //_attrDao = InitDAO<AttrDao>(attrDao) as IAttrRepository;
            _catalog2Dao = new Catalog2Dao(_catalog1Dao.Repository);
            _attrDao = new AttrDao(_catalog1Dao.Repository);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Add(Catalog1AddModel model)
        {
            return await _catalog1Dao.InsertAsync(ModelToEntityNoId(model));
        }

        public async Task<bool> Delete(Catalog1Model model)
        {
            return await _catalog1Dao.DeleteAsync(ModelToEntity(model));
        }

        public async Task<IEnumerable<Catalog1Model>> GetAll()
        {
            return await _catalog1Dao.SelectAllAsync();
        }

        public async Task<bool> Update(Catalog1Model model)
        {
            return await _catalog1Dao.UpdateAsync(ModelToEntity(model));
        }

        /// <summary>
        /// 将model 转换为表 entity，没有ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BMMS_CATALOG1 ModelToEntityNoId(Catalog1AddModel model = null)
        {
            return new BMMS_CATALOG1
            {
                CATALOG_NAME = model?.CatalogName,
            };
        }
        /// <summary>
        /// 将model 转换为表 entity 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BMMS_CATALOG1 ModelToEntity(Catalog1Model model)
        {
            BMMS_CATALOG1 entity = ModelToEntityNoId(model);
            entity.ID = model.Id;
            return entity;
        }
        public IEnumerable<BMMS_CATALOG1> ModelListToEntityListNoId(IEnumerable<Catalog1AddModel> models)
        {
            List<BMMS_CATALOG1> entityList = new List<BMMS_CATALOG1>();
            foreach (var model in models)
            {
                entityList.Add(ModelToEntityNoId(model));
            }
            return entityList;
        }

        public async Task<bool> AddBatch(IEnumerable<Catalog1AddModel> models)
        {
            return await _catalog1Dao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                return await _catalog1Dao.InsertBatchAsync(ModelListToEntityListNoId(models), transaction);
            });
            
        }

        public async Task<bool> DeleteBatch(IEnumerable<Catalog1Model> models)
        {
            return await _catalog1Dao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                List<string> ids = new List<string>();
                foreach (var model in models)
                {
                    ids.Add(model.Id);
                }
                // 删除其子分类
                await DeleteCatalog2ListByCatalogIdList(ids, transaction);
                return await _catalog1Dao.DeleteBatch(ids, transaction);
            });
        }

        /// <summary>
        /// 由多个一级分类删除子分类
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task DeleteCatalog2ListByCatalogIdList(List<string> ids, IDbTransaction transaction = null)
        {
            foreach(var id in ids)
            {
                await DeleteCatalog2ByCatalog1Id(id, transaction);
            }
        }
        /// <summary>
        /// 删除子分类及其属性
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task DeleteCatalog2ByCatalog1Id(string id, IDbTransaction transaction)
        {
            // 获取二级分类
            IEnumerable<Catalog2Model> catalog2Models = await _catalog2Dao.SelectListByCatalog1Id(id);
            // 先删除二级分类下的属性
            foreach(var model in catalog2Models)
            {
                // 删除属性
                await _attrDao.DeleteAttrListByCatalog(model.Id, transaction);
                // 删除二级分类
                await _catalog2Dao.Delete(model.Id, transaction);
            }
        }
    }
}
