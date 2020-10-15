using DapperExtensions;
using DateModel.Catalog;
using Interface;
using Interface.Catalog;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Catalog;

namespace DAO.Catalog
{
    public class AttrDao: BaseDAO, IAttrRepository
    {
        public AttrDao() { }
        public AttrDao(IDataRepository repository) : base(repository) { }
        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }
        public AttrModel EntityToModel(BMMS_CATALOG_ATTR entity)
        {
            return new AttrModel
            {
                Id = entity?.ID,
                CatalogId = entity?.CATALOG_ID,
                AttrName = entity?.ATTR_NAME
            };
        }
        public IEnumerable<AttrModel> EntityListToModelList(IEnumerable<BMMS_CATALOG_ATTR> entityList)
        {
            List<AttrModel> modelList = new List<AttrModel>();
            foreach (var entity in entityList)
            {
                modelList.Add(EntityToModel(entity));
            }
            return modelList;
        }

        public async Task<string> Add(BMMS_CATALOG_ATTR entity, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync<BMMS_CATALOG_ATTR>(entity);
        }

        public async Task<bool> Delete(string id, IDbTransaction transaction = null)
        {
            return await Repository.DeleteAsync<BMMS_CATALOG_ATTR>(id) > 0 ? true : false;
        }

        public async Task<IEnumerable<AttrModel>> SelectListByCatalogId(string catalogId)
        {
            var predicatesField = Predicates.Field<BMMS_CATALOG_ATTR>(item => item.CATALOG_ID, Operator.Eq, catalogId);
            var predicateSort = Predicates.Sort<BMMS_CATALOG_ATTR>(item => item.OCD, true); // 按创建时间排序
            IEnumerable<BMMS_CATALOG_ATTR> entityList = await Repository.GetListAsync<BMMS_CATALOG_ATTR>(predicatesField, new[] { predicateSort });
            return EntityListToModelList(entityList);
        }

        public async Task<bool> Update(BMMS_CATALOG_ATTR entity, IDbTransaction transaction = null)
        {
            string sql = @"update BMMS_CATALOG_ATTR 
                        set ATTR_NAME = @AttrName,
                            LUD = @LUD
                        where ID = @Id";
            return await Repository.ExecuteAsync(sql, 
                new { 
                    AttrName = entity.ATTR_NAME, 
                    Id = entity.ID,
                    LUD = entity.LUD
                }
                ) > 0 ? true : false;
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBatch(IEnumerable<string> ids, IDbTransaction transaction = null)
        {
            foreach(var id in ids)
            {
                string sql = @"delete from BMMS_CATALOG_ATTR where ID = @Id";
                bool result = await Repository.ExecuteAsync(sql, new { Id = id }, transaction) > 0 ? true : false;
                if (!result)
                {
                    throw new Exception("删除属性失败");
                }
            }
            return true;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public async Task<bool> InsertBatch(IEnumerable<BMMS_CATALOG_ATTR> entityList, IDbTransaction tran)
        {
            return await Repository.InsertBatchAsync<BMMS_CATALOG_ATTR>(entityList, tran);
        }

        public async Task<bool> DeleteAttrListByCatalog(string catalogId, IDbTransaction tran = null)
        {
            string sql = @"delete from BMMS_CATALOG_ATTR where CATALOG_ID = @CatalogId";
            return await Repository.ExecuteAsync(sql, new { CatalogId = catalogId }, tran) > 0 ? true : false;
        }
    }
}
