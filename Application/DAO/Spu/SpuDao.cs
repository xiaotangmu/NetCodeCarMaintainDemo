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
            return await Repository.DeleteAsync<PMS_SPU>(id, transaction) > 0 ? true : false;
        }

        /// <summary>
        /// 根据SpuId 删除关联属性值
        /// </summary>
        /// <param name="SpuId"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<bool> DeleteSpuAttrBySpuId(string SpuId, IDbTransaction transaction = null)
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
        public async Task<bool> DeleteSpuAttrValueBySpuId(string SpuId, IDbTransaction transaction = null)
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

        public async Task<IEnumerable<SpuModel>> SelectAllWithPaging(BaseSearchModel model)
        {
            var pSort = Predicates.Sort<PMS_SPU>(item => item.OCD, false);
            IEnumerable<PMS_SPU> entityList = await Repository.GetPageListAsync<PMS_SPU>(model.PageIndex, model.PageSize, null, new[] { pSort });
            return EntityListToModelList(entityList);
        }

        public async Task<IEnumerable<SpuModel>> SelectSpuListWithPaging(SpuPageSearchModel model)
        {
            string sql = "select * from PMS_SPU where ";
            if (!string.IsNullOrEmpty(model.Catalog2Id))
            {
                sql += "CATALOG2_ID = @Catalog2Id And";
            }
            if (!string.IsNullOrEmpty(model.ProductName))
            {
                sql += " PRODUCT_NAME = @ProductName And";
            }
            // 去除多余And
            sql = sql.Substring(0, sql.Length - 3);
            IEnumerable<PMS_SPU> entityList = await Repository.GetPageAsync<PMS_SPU>(model.PageIndex, model.PageSize, sql, "order by OCD desc",
                new { Catalog2Id= model.Catalog2Id, ProductName= model.ProductName });
            return EntityListToModelList(entityList);
        }

        public async Task<bool> Update(PMS_SPU entity, IDbTransaction transaction = null)
        {
            string sql = @"update PMS_SPU 
                        set CATALOG2_ID = @CATALOG2_ID,
                            PRODUCT_NAME = @PRODUCT_NAME, 
                            DESCRIPTION = @DESCRIPTION, 
                            LUD = @LUD
                        where ID = @ID";
            return await Repository.ExecuteAsync(sql, new { entity }, transaction) > 0 ? true : false;
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
    }
}
