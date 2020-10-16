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
            _catalog2Dao = InitDAO<Catalog2Dao>(catalog2Dao) as ICatalog2Repository;
            _attrDao = InitDAO<AttrDao>(attrDao) as IAttrRepository;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Add(Catalog1AddModel model)
        {
            // 判断是否已经存在该分类
            await IsExistThrowException(model);
            return await _catalog1Dao.InsertAsync(ModelToEntityNoId(model));
        }

        /// <summary>
        /// 删除分类及其子类和属性
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string Id)
        {
            return await _catalog1Dao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 删除其子分类
                await DeleteCatalog2ByCatalog1Id(Id, transaction);
                return await _catalog1Dao.DeleteAsync(Id, transaction);
            });
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
            // 判断数据是否重复
            IsExistSameWithInputThrowException(models);
            // 判断数据库是否存在相同数据
            foreach(var model in models)
            {
                await IsExistThrowException(model);
            }
            // 添加
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
                _attrDao = new AttrDao(_catalog1Dao.Repository);
                await _attrDao.DeleteAttrListByCatalog(model.Id, transaction);
                // 删除二级分类
                _catalog2Dao = new Catalog2Dao(_catalog1Dao.Repository);
                await _catalog2Dao.Delete(model.Id, transaction);
            }
        }

        /// <summary>
        /// 判断是否有相同数据
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsExist(Catalog1AddModel model)
        {
            // 判断是否已经存在该分类
            IEnumerable<Catalog1Model> models = await _catalog1Dao.SelectAllAsync();
            foreach (var item in models)
            {
                if (item.CatalogName.Equals(model.CatalogName))
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
        public async Task IsExistThrowException(Catalog1AddModel model)
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
        public void IsExistSameWithInputThrowException(IEnumerable<Catalog1AddModel> models)
        {
            HashSet<string> hs = new HashSet<string>();
            // 判断数据是否重复
            foreach (var model in models)
            {
                hs.Add(model.CatalogName.Trim());
            }
            if (!hs.Count().Equals(models.Count()))
            {
                throw new MyServiceException(MsgCode.SameData, "提交的数据有重");
            }
        }
    }
}
