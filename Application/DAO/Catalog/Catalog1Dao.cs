using DataModel;
using DateModel.Catalog;
using Interface.Catalog;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Common;

namespace DAO.Catalog
{
    public class Catalog1Dao: BaseDAO, ICatalog1Repository
    {
        public Catalog1Dao() : base() { }

        public Catalog1Dao(IDataRepository repository) : base(repository) { }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(string id, IDbTransaction transaction = null)
        {
            string sql = @"delete from BMMS_CATALOG1 where ID = @Id";
            bool result = await Repository.ExecuteAsync(sql, new { Id = id }, transaction) > 0 ? true : false;
            if (!result)
            {
                throw new Exception("删除失败");
            }
            return result;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<string> InsertAsync(BMMS_CATALOG1 application, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync(application, transaction);
        }

        /// <summary>
        /// 选择所有
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Catalog1Model>> SelectAllAsync()
        {
            string sql = "select * from BMMS_CATALOG1 where 1=1";
            IEnumerable<BMMS_CATALOG1> entityList = await Repository.GetGroupAsync<BMMS_CATALOG1>(sql);
            List<Catalog1Model> modelList = new List<Catalog1Model>();
            foreach(var entity in entityList)
            {
                modelList.Add(EntityToModel(entity));
            }
            return modelList;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(BMMS_CATALOG1 entity, IDbTransaction tran = null)
        {
            string sql = @"update BMMS_CATALOG1
                           set CATALOG_NAME = @CatalogName,
                                LUD = @LUD
                            where ID = @ID";
            var paramsData = new
            {
                CatalogName = entity.CATALOG_NAME,
                LUD = entity.LUD,
                ID = entity.ID
            };
            return await Repository.ExecuteAsync(sql, paramsData, tran) > 0 ? true : false;
        }

        /// <summary>
        /// 将表实体类entity 转换为页面操作类 model
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Catalog1Model EntityToModel(BMMS_CATALOG1 entity)
        {
            return new Catalog1Model
            {
                CatalogName = entity?.CATALOG_NAME,
                Id = entity?.ID
            };
        }
        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }

        public async Task<bool> InsertBatchAsync(IEnumerable<BMMS_CATALOG1> entityList, IDbTransaction transaction = null)
        {
            return await Repository.InsertBatchAsync<BMMS_CATALOG1>(entityList, transaction);
        }

        public async Task<bool> DeleteBatch(IEnumerable<string> ids, IDbTransaction transaction)
        {
            foreach (var id in ids)
            {
                string sql = @"delete from BMMS_CATALOG1 where ID = @Id";
                bool result = await Repository.ExecuteAsync(sql, new { Id = id }, transaction) > 0 ? true : false;
                if (!result)
                {
                    throw new Exception("删除失败");
                }
            }
            return true;
        }
        public async Task<int> CountAsync()
        {
            string sql = "select Count(1) from BMMS_CATALOG1 where 1 = 1";
            return await Repository.CountAsync(sql);
        }

        public async Task<PageModel<Catalog1Model>> GetCatalog1GroupWithPagingBySearch(BaseSearchModel model)
        {
            PageModel<Catalog1Model> pageModel = new PageModel<Catalog1Model>();
            Catalog1Model viewModel = new Catalog1Model();
            pageModel.TotalCount = await CountAsync();
            if (pageModel.TotalCount == 0)
            {
                pageModel.Items = new List<Catalog1Model>();
                return pageModel;
            }
            string sql = "select * from BMMS_CATALOG1 where 1=1";
            IEnumerable<BMMS_CATALOG1> entityList = await Repository.GetPageAsync<BMMS_CATALOG1>(model.PageIndex, model.PageSize, sql, " order by OCD desc");
            List<Catalog1Model> modelList = new List<Catalog1Model>();
            foreach (var entity in entityList)
            {
                modelList.Add(EntityToModel(entity));
            }
            pageModel.Items = modelList;
            return pageModel;
        }
    }
}
