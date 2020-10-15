using DateModel.Catalog;
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
    public class Catalog1Dao: BaseDAO, ICatalog1Repository
    {
        public Catalog1Dao() : base() { }

        public Catalog1Dao(IDataRepository repository) : base(repository) { }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(BMMS_CATALOG1 entity, IDbTransaction tran = null)
        {
            return await Repository.DeleteAsync<BMMS_CATALOG1>(entity.ID, tran) > 0? true : false;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        //public async Task<string> InsertAsync(BMMS_CATALOG1 application, IDbTransaction transaction = null)
        //{
        //    return await Repository.InsertAsync(application, transaction);
        //}
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
            string sql = "select * from BMMS_CATALOG1";
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
                                DESCRIPTION = @Description,
                                LUD = @LUD
                            where ID = @ID";
            var paramsData = new
            {
                CatalogName = entity.CATALOG_NAME,
                Description = entity.DESCRIPTION,
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
                Description = entity?.DESCRIPTION,
                Id = entity?.ID
            };
        }
        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }
    }
}
