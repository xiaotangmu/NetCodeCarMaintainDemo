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
    public class Catalog2Dao: BaseDAO, ICatalog2Repository
    {
        public Catalog2Dao() { }
        public Catalog2Dao(IDataRepository repository) : base(repository) { }

        public async Task<bool> Delete(string id, IDbTransaction transaction = null)
        {
            string sql = @"delete from BMMS_CATALOG2 where ID = @Id";
            bool result = await Repository.ExecuteAsync(sql, new { Id = id }, transaction) > 0 ? true : false;
            if (!result)
            {
                throw new Exception("属性并不存在");
            }
            return true;
        }

        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }

        public async Task<string> Insert(BMMS_CATALOG2 entity, IDbTransaction tran = null)
        {
            return await Repository.InsertAsync<BMMS_CATALOG2>(entity, tran);
        }

        public async Task<IEnumerable<Catalog2Model>> SelectListByCatalog1Id(string catalog1Id)
        {
            var predicateIsUse = Predicates.Field<BMMS_CATALOG2>(item => item.PARENT_ID, Operator.Eq, catalog1Id);
            var predicateSort = Predicates.Sort<BMMS_CATALOG2>(item => item.OCD, true);
            IEnumerable<BMMS_CATALOG2> entityList = await Repository.GetListAsync<BMMS_CATALOG2>(predicateIsUse, new[] { predicateSort });
            return EntityListToModelList(entityList);
        }

        public async Task<bool> Update(BMMS_CATALOG2 entity, IDbTransaction tran = null)
        {
            string sql = @"update BMMS_CATALOG2 
                        set CATALOG_NAME = @CatalogName,
                            LUD = @LUD
                        where ID = @Id";
            return await Repository.ExecuteAsync(sql,
                new
                {
                    CatalogName = entity.CATALOG_NAME,
                    Id = entity.ID,
                    LUD = entity.LUD
                }
                ) > 0 ? true : false;
        }

        public Catalog2Model EntityToModel(BMMS_CATALOG2 entity)
        {
            return new Catalog2Model
            {
                Id = entity?.ID,
                Catalog1Id = entity?.PARENT_ID,
                CatalogName = entity?.CATALOG_NAME
            };
        }
        public IEnumerable<Catalog2Model> EntityListToModelList(IEnumerable<BMMS_CATALOG2> entityList)
        {
            List<Catalog2Model> modelList = new List<Catalog2Model>();
            foreach(var entity in entityList)
            {
                modelList.Add(EntityToModel(entity));
            }
            return modelList;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBatch(IEnumerable<string> ids, IDbTransaction transaction = null)
        {
            foreach (var id in ids)
            {
                string sql = @"delete from BMMS_CATALOG2 where ID = @Id";
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
        public async Task<bool> InsertBatch(IEnumerable<BMMS_CATALOG2> entityList, IDbTransaction tran = null)
        {
            return await Repository.InsertBatchAsync<BMMS_CATALOG2>(entityList, tran);
        }

        public async Task<bool> DeleteListByCatalog1Id(string catalogId, IDbTransaction tran = null)
        {
            string sql = @"delete from BMMS_CATALOG2 where PARENT_ID = @CatalogId";
            return await Repository.ExecuteAsync(sql, new { CatalogId = catalogId }, tran) > 0 ? true : false;
        }

    }
}
