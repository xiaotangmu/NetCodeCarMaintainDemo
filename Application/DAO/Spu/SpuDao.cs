using DapperExtensions;
using DataModel;
using DateModel.Spu;
using Interface;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Spu;

namespace DAO.Spu
{
    public class SpuDao: BaseDAO, ISpuRepository
    {
        public SpuDao() {  }

        public SpuDao(IDataRepository repository) : base(repository) { }
        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }
        public async Task<string> Add(PMS_SPU pMS_SPU, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync<PMS_SPU>(pMS_SPU, transaction);
        }

        public async Task<string> AddAttr(PMS_SPU_ATTR pMS_SPU_ATTR, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync<PMS_SPU_ATTR>(pMS_SPU_ATTR, transaction);
        }

        public async Task<string> AddAttrValue(PMS_SPU_ATTR_VALUE pMS_SPU_ATTR_VALUE, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync(pMS_SPU_ATTR_VALUE, transaction);
        }

        public async Task<bool> Delete(string id, IDbTransaction transaction = null)
        {
            string sql = @"delete from PMS_SPU where ID  = @SpuId";
            return await Repository.ExecuteAsync(sql, new { SpuId = id }, transaction) > 0 ? true : false;
        }

        /// <summary>
        /// 根据SpuId 删除关联属性值
        /// </summary>
        /// <param name="SpuId"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<bool> DeleteSpuAttrValueBySpuId(string SpuId, IDbTransaction transaction = null)
        {
            string sql = @"delete from PMS_SPU_ATTR_VALUE where ID in 
                            (select pasv.ID from PMS_SPU_ATTR_VALUE pasv
                            LEFT JOIN PMS_SPU_ATTR psa on psa.ID = pasv.SPU_ATTR_ID
                            LEFT JOIN PMS_SPU ps on ps.ID = psa.SPU_ID 
                            where ps.ID = @SpuId)";
            return await Repository.ExecuteAsync(sql, new { SpuId }, transaction) > 0 ? true : false;
        }

        /// <summary>
        /// 根据SpuId 删除关联属性
        /// </summary>
        /// <param name="SpuId"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<bool> DeleteSpuAttrBySpuId(string SpuId, IDbTransaction transaction = null)
        {
            string sql = @"delete from PMS_SPU_ATTR where ID in 
                        (select psa.ID from PMS_SPU_ATTR psa 
                        LEFT JOIN PMS_SPU ps on ps.ID = psa.SPU_ID 
                        where ps.ID = @SpuId) ";
            return await Repository.ExecuteAsync(sql, new { SpuId }, transaction) > 0 ? true : false;
        }

        public async Task<bool> isExist(SpuAddModel model)
        {
            var predicateCode = Predicates.Field<PMS_SPU>(obj => obj.CATALOG2_ID, Operator.Eq, model.Catalog2Id);
            var predicateIsUse = Predicates.Field<PMS_SPU>(obj => obj.PRODUCT_NAME, Operator.Eq, model.ProductName);
            var predicateGroup = Predicates.Group(GroupOperator.And, predicateCode, predicateIsUse);
            return await Repository.CountAsync<PMS_SPU>(predicateGroup) > 0 ? true : false;
        }

        public async Task<SpuListWithPagingModel> SelectAllWithPaging(BaseSearchModel model)
        {
            string sql = "select * from PMS_SPU where 1 = 1";
            SpuListWithPagingModel pageModel = new SpuListWithPagingModel();
            string countSql = "select count(1) from PMS_SPU where 1 = 1";
            pageModel.TotalCount = await Repository.CountAsync(countSql);
            IEnumerable<PMS_SPU> entityList = await Repository.GetPageAsync<PMS_SPU>(model.PageIndex, model.PageSize, sql, " order by ss.OCD Desc");
            pageModel.Items = EntityListToModelList(entityList);
            return pageModel;
        }

        public async Task<SpuListWithPagingModel> SelectSpuListWithPaging(SpuPageSearchModel model)
        {
            SpuListWithPagingModel pageModel = new SpuListWithPagingModel();
            #region 注意拼接字符串不要用@传参
            string sql = "select * from PMS_SPU where ";
            if (!string.IsNullOrEmpty(model.Catalog2Id))
            {
                sql += "CATALOG2_ID = '{0}' And";
            }
            if (!string.IsNullOrEmpty(model.ProductName))
            {
                sql += " PRODUCT_NAME like '%' + '{1}' + '%' And";
            }
            sql = string.Format(sql, model.Catalog2Id, model.ProductName);
            // 去除多余And
            sql = sql.Substring(0, sql.Length - 3);

            string countSql = "Select Count(1) from (" + sql + ") as temp";
            pageModel.TotalCount = await Repository.CountAsync(countSql);

            IEnumerable<PMS_SPU> entityList = await Repository.GetPageAsync<PMS_SPU>(model.PageIndex, model.PageSize, sql, "order by OCD desc",
                model, null);
            pageModel.Items = EntityListToModelList(entityList);
            return pageModel;
            #endregion

            //string catalog2Id = model.Catalog2Id == null? "" : model.Catalog2Id.Trim();
            //string productName = model.ProductName == null ? "" : model.ProductName.Trim();

            //var pField1 = Predicates.Field<PMS_SPU>(item => item.CATALOG2_ID, Operator.Eq, catalog2Id);
            //var pField2 = Predicates.Field<PMS_SPU>(item => item.PRODUCT_NAME, Operator.Like, '%' + productName + '%');
            //var pSort = Predicates.Sort<PMS_SPU>(item => item.OCD, false);
            
            //var pGroup4 = Predicates.Group(GroupOperator.And, new[] { pField1, pField2 });
            //IEnumerable<PMS_SPU> entityList = null;
            //bool res = false;
            //#region 判断用哪种pGroud
            //if (!string.IsNullOrEmpty(catalog2Id) && !string.IsNullOrEmpty(productName))
            //{
            //    var pGroup = Predicates.Group(GroupOperator.And, new[] { pField1, pField2 });
            //    entityList = await Repository.GetPageListAsync<PMS_SPU>(model.PageIndex, model.PageSize, pGroup, new[] { pSort });
            //    res = true;
            //}
            //if (!res && !string.IsNullOrEmpty(catalog2Id)){
            //    var pGroup = Predicates.Group(GroupOperator.And, new[] { pField1 });
            //    entityList = await Repository.GetPageListAsync<PMS_SPU>(model.PageIndex, model.PageSize, pGroup, new[] { pSort });
            //    res = true;
            //}
            //if (!res && !string.IsNullOrEmpty(productName))
            //{
            //    var pGroup = Predicates.Group(GroupOperator.And, new[] { pField2 });
            //    entityList = await Repository.GetPageListAsync<PMS_SPU>(model.PageIndex, model.PageSize, pGroup, new[] { pSort });
            //    res = true;
            //}
            //if (!res)
            //{
            //    entityList = await Repository.GetPageListAsync<PMS_SPU>(model.PageIndex, model.PageSize, null, new[] { pSort });
            //}
            //#endregion
            //return EntityListToModelList(entityList);
        }

        public async Task<bool> Update(PMS_SPU entity, IDbTransaction transaction = null)
        {
            string sql = @"update PMS_SPU 
                        set CATALOG2_ID = @CATALOG2_ID,
                            PRODUCT_NAME = @PRODUCT_NAME, 
                            DESCRIPTION = @DESCRIPTION, 
                            LUD = @LUD
                        where ID = @ID";
            return await Repository.ExecuteAsync(sql, 
                entity, transaction) > 0 ? true : false;
        }

        public SpuModel EntityToModel(PMS_SPU entity)
        {
            return new SpuModel
            {
                Id = entity?.ID,
                Catalog2Id = entity?.CATALOG2_ID,
                ProductName = entity?.PRODUCT_NAME,
                Description = entity?.DESCRIPTION,
                LUD = (DateTime)entity?.LUD
            };
        }
        public IEnumerable<SpuModel> EntityListToModelList(IEnumerable<PMS_SPU> entityList)
        {
            List<SpuModel> modelList = new List<SpuModel>();
            foreach (var entity in entityList)
            {
                modelList.Add(EntityToModel(entity));
            }
            return modelList;
        }

        public async Task<IEnumerable<SpuAttrModel>> SelectAttrBySpuId(string SpuId)
        {
            string sql = @"select psa.ID Id, bca.ATTR_NAME AttrName, bca.ID AttrId, ps.ID SpuId from PMS_SPU_ATTR psa
                        LEFT JOIN BMMS_CATALOG_ATTR bca on bca.ID = psa.ATTR_ID
                        LEFT JOIN PMS_SPU ps on ps.ID = psa.SPU_ID 
                        where ps.ID = @SpuId";
            return await Repository.GetGroupAsync<SpuAttrModel>(sql, new { SpuId });
        }

        public async Task<IEnumerable<SpuAttrValueModel>> SelectAttrValueBySpuAttrId(string SpuAttrId)
        {
            string sql = @"select psav.ID Id, psav.VALUE Value from PMS_SPU_ATTR_VALUE psav
                LEFT JOIN PMS_SPU_ATTR psa on psa.ID = psav.SPU_ATTR_ID 
                where psa.ID = @SpuAttrId";
            return await Repository.GetGroupAsync<SpuAttrValueModel>(sql, new { SpuAttrId });
        }

        public async Task<IEnumerable<SpuModel>> GetAll()
        {
            var pSort = Predicates.Sort<PMS_SPU>(item => item.OCD, false);
            IEnumerable<PMS_SPU> entityList = await Repository.GetListAsync<PMS_SPU>(null, new[] { pSort });
            return EntityListToModelList(entityList);
        }

        public async Task<IEnumerable<SpuModel>> GetListByCatalog2Id(string catalog2Id)
        {
            var pField = Predicates.Field<PMS_SPU>(item => item.CATALOG2_ID, Operator.Eq, catalog2Id);
            var pGroup = Predicates.Group(GroupOperator.And, new[] { pField });
            var pSort = Predicates.Sort<PMS_SPU>(item => item.OCD, false);
            IEnumerable<PMS_SPU> entityList = await Repository.GetListAsync<PMS_SPU>(pGroup, new[] { pSort });
            return EntityListToModelList(entityList);
        }
    }
}
