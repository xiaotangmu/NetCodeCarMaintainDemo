using DAO.Catalog;
using DataModel;
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
    /// 二级分类
    /// </summary>
    public class Catalog2Supervisor: BaseBLL, ICatalog2Supervisor
    {
        private ICatalog2Repository _catalog2Dao;
        private IAttrRepository _attrDao;
        public Catalog2Supervisor(ICatalog2Repository catalog2Repository = null, IAttrRepository attrDao = null)
        {
            _catalog2Dao = InitDAO<Catalog2Dao>(catalog2Repository) as ICatalog2Repository;
            //_attrDao = InitDAO<AttrDao>(attrDao) as IAttrRepository;
            _attrDao = new AttrDao(_catalog2Dao.Repository);
        }

        /// <summary>
        /// 添加新二级分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Add(Catalog2AddModel model)
        {
            // 判断是否存在相同数据
            await IsExistThrowException(model);
            return await _catalog2Dao.Insert(ModelToEntityNoId(model));
        }

        public async Task<bool> Delete(string id)
        {
            return await _catalog2Dao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 先删除其属性
                await DeleteAttrListByCatalog(id, transaction);
                return await _catalog2Dao.Delete(id, transaction);
            });
        }

        public async Task<IEnumerable<Catalog2Model>> GetListByCatalog1Id(string catalog1Id)
        {
            return await _catalog2Dao.SelectListByCatalog1Id(catalog1Id);
        }

        /// <summary>
        /// 更新二级分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Update(Catalog2Model model)
        {
            return await _catalog2Dao.Update(ModelToEntity(model));
        }

        /// <summary>
        /// 将model 转换为表 entity，没有ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BMMS_CATALOG2 ModelToEntityNoId(Catalog2AddModel model = null)
        {
            return new BMMS_CATALOG2
            {
                CATALOG_NAME = model?.CatalogName,
                PARENT_ID = model?.Catalog1Id
            };
        }
        /// <summary>
        /// 将model 转换为表 entity 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BMMS_CATALOG2 ModelToEntity(Catalog2Model model)
        {
            BMMS_CATALOG2 entity = ModelToEntityNoId(model);
            entity.ID = model.Id;
            return entity;
        }
        public IEnumerable<BMMS_CATALOG2> ModelListToEntityListNoId(IEnumerable<Catalog2AddModel> models)
        {
            List<BMMS_CATALOG2> entityList = new List<BMMS_CATALOG2>();
            foreach (var model in models)
            {
                entityList.Add(ModelToEntityNoId(model));
            }
            return entityList;
        }

        /// <summary>
        /// 删除一级分类下的所有子分类及其属性
        /// </summary>
        /// <param name="Catalog1Id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteListByCatalog1Id(string Catalog1Id)
        {
            return await _catalog2Dao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 先得到二级分类列表 
                IEnumerable<Catalog2Model> catalog2Models = await _catalog2Dao.SelectListByCatalog1Id(Catalog1Id);
                // 删除二级分类属性
                await DeleteAttrListByCatalogIdList(catalog2Models, transaction);
                // 删除二级分类
                return await _catalog2Dao.DeleteListByCatalog1Id(Catalog1Id, transaction);
            });
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBatch(IEnumerable<Catalog2Model> models)
        {
            return await _catalog2Dao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 删除其子分类
                await DeleteAttrListByCatalogIdList(models, transaction);
                List<string> ids = new List<string>();
                foreach (var model in models)
                {
                    ids.Add(model.Id);
                }
                return await _catalog2Dao.DeleteBatch(ids, transaction);
            });
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public async Task<bool> AddBatch(IEnumerable<Catalog2AddModel> models)
        {
            // 判断提交的数据是否重复
            IsExistSameWithInputThrowException(models);
            // 判断是否存在相同数据
            foreach (var model in models)
            {
                await IsExistThrowException(model);
            }
            // 添加
            return await _catalog2Dao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                return await _catalog2Dao.InsertBatch(ModelListToEntityListNoId(models), transaction);
            });
        }

        /// <summary>
        /// 删除分类下的所有属性
        /// </summary>
        /// <param name="CatalogId"></param>
        /// <returns></returns>
        public async Task DeleteAttrListByCatalog(string id, IDbTransaction transaction = null)
        {
            await _attrDao.DeleteAttrListByCatalog(id, transaction);
        }

        /// <summary>
        /// 删除多个分类下的所有属性
        /// </summary>
        /// <param name="CatalogId"></param>
        /// <returns></returns>
        public async Task DeleteAttrListByCatalogIdList(IEnumerable<Catalog2Model> catalog2Models, IDbTransaction transaction)
        {
            foreach(var item in catalog2Models)
            {
                await _attrDao.DeleteAttrListByCatalog(item.Id, transaction);
            }
        }

        /// <summary>
        /// 判断是否有相同数据
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsExist(Catalog2AddModel model)
        {
            // 判断是否已经存在该分类
            IEnumerable<Catalog2Model> models = await _catalog2Dao.SelectListByCatalog1Id(model.Catalog1Id);
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
        public async Task IsExistThrowException(Catalog2AddModel model)
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
        public void IsExistSameWithInputThrowException(IEnumerable<Catalog2AddModel> models)
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
        public async Task<PageModel<Catalog2Model>> GetCatalog1ListPageBySearch(BaseSearchModel model)
        {
            return await _catalog2Dao.GetCatalog2GroupWithPagingBySearch(model);
        }
    }
}
