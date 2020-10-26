using Dapper;
using DapperExtensions;
using DataModel;
using DateModel.Sku;
using Interface.Sku;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Sku;

namespace DAO.Sku
{
    public class SkuDao : BaseDAO, ISkuRepository
    {
        public SkuDao() { }
        public SkuDao(IDataRepository repository) : base(repository) { }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<string> Insert(SMS_SKU entity, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync(entity, transaction);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id, IDbTransaction transaction = null)
        {
            string sql = @"delete from SMS_SKU where ID = @id";
            return await Repository.ExecuteAsync(sql, new { id }, transaction) > 0 ? true : false;
        }

        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SkuModel>> SelectAll()
        {
            string sql = @"select ss.CATALOG2_ID Catalog2Id, ps.PRODUCT_NAME SkuName, ss.ID Id, ss.SKU_NO SkuNo,
                ss.SPU_ID SpuId, ss.BRAND Brand, ss.PRICE Price, ss.UNIT Unit,
                ss.TOTAL_COUNT TotalCount, ss.ALARM Alarm, ss.DESCRIPTION Description,
                ss.Type type, ss.STATUS Status, ss.OLD_PARTID OldPartId
                from SMS_SKU ss
                LEFT JOIN PMS_SPU ps on ps.ID = ss.SPU_ID
                where 1 = 1";
            IEnumerable<SkuModel> entityList = await Repository.GetGroupAsync<SkuModel>(sql);
            return entityList;
        }

        public async Task<IEnumerable<SkuModel>> SelectListBySearch(string searchStr)
        {
            string sql = @"select ss.CATALOG2_ID Catalog2Id, ps.PRODUCT_NAME SkuName, ss.ID Id, ss.SKU_NO SkuNo,
                ss.SPU_ID SpuId, ss.BRAND Brand, ss.PRICE Price, ss.UNIT Unit,
                ss.TOTAL_COUNT TotalCount, ss.ALARM Alarm, ss.DESCRIPTION Description,
                ss.Type type, ss.STATUS Status, ss.OLD_PARTID OldPartId
                from SMS_SKU ss
                LEFT JOIN PMS_SPU ps on ps.ID = ss.SPU_ID
                where ps.PRODUCT_NAME like '%' + @searchStr + '%' or ss.BRAND like '%' + @searchStr + '%'
                    or ss.DESCRIPTION like '%' + @searchStr + '%'";
            IEnumerable<SkuModel> entityList = await Repository.GetGroupAsync<SkuModel>(sql, new { searchStr });
            List<SkuModel> modelList = new List<SkuModel>();
            return entityList;
        }

        public async Task<SkuListWithPagingViewModel> SelectListPage(BaseSearchModel model)
        {
            string sql = @"select ss.CATALOG2_ID Catalog2Id, ps.PRODUCT_NAME SkuName, ss.ID Id, ss.SKU_NO SkuNo,
                ss.SPU_ID SpuId, ss.BRAND Brand, ss.PRICE Price, ss.UNIT Unit,
                ss.TOTAL_COUNT TotalCount, ss.ALARM Alarm, ss.DESCRIPTION Description,
                ss.Type type, ss.STATUS Status, ss.OLD_PARTID OldPartId
                from SMS_SKU ss
                LEFT JOIN PMS_SPU ps on ps.ID = ss.SPU_ID
                where 1 = 1";
            SkuListWithPagingViewModel pageModel = new SkuListWithPagingViewModel();
            string countSql = "Select Count(1) from (" + sql + ") as temp";
            pageModel.TotalCount = await Repository.CountAsync(countSql);
            pageModel.Items = await Repository.GetPageAsync<SkuModel>(model.PageIndex, model.PageSize, sql, " order by ss.OCD Desc");
            return pageModel;
        }

        public async Task<SkuListWithPagingViewModel> SelectListPageBySearch(SkuListSearchModel model)
        {
            string sql = string.Format("select ss.CATALOG2_ID Catalog2Id, ps.PRODUCT_NAME SkuName, ss.ID Id, ss.SKU_NO SkuNo, " + 
                "ss.SPU_ID SpuId, ss.BRAND Brand, ss.PRICE Price, ss.UNIT Unit, " + 
                "ss.TOTAL_COUNT TotalCount, ss.ALARM Alarm, ss.DESCRIPTION Description, " +
                "ss.Type type, ss.STATUS Status, ss.OLD_PARTID OldPartId " +
                "from SMS_SKU ss " +
                "LEFT JOIN PMS_SPU ps on ps.ID = ss.SPU_ID " +
                "where (ps.PRODUCT_NAME like '%' + '{0}' + '%' or ss.BRAND like '%' + '{0}' + '%' " +
                   " or ss.DESCRIPTION like '%' + '{0}' + '%') " + 
                   (string.IsNullOrWhiteSpace(model.Catalog2Id)? "" : " AND ss.CATALOG2_ID = '{1}' "), model.SearchStr, model.Catalog2Id);
            SkuListWithPagingViewModel pageModel = new SkuListWithPagingViewModel();
            string countSql = "Select Count(1) from (" + sql + ") as temp";
            pageModel.TotalCount = await Repository.CountAsync(countSql);

            pageModel.Items = await Repository.GetPageAsync<SkuModel>(model.PageIndex, model.PageSize, sql, " order by ss.OCD Desc");
            return pageModel;
        }

        public async Task<bool> Update(SMS_SKU entity, IDbTransaction transaction = null)
        {
            string sql = @"update SMS_SKU 
                        set 
                            DESCRIPTION = @DESCRIPTION, 
							BRAND = @BRAND,
							PRICE = @PRICE,
							UNIT = @UNIT,
							TOTAL_COUNT = @TOTAL_COUNT,
							ALARM = @ALARM,
                            LUD = @LUD
                        where ID = @ID";
            return await Repository.ExecuteAsync(sql,
                entity, transaction) > 0 ? true : false;
        }

        public async Task<string> AddAttrValue(SMS_SKU_ATTR_VALUE sMS_SKU_ATTR_VALUE, IDbTransaction transaction)
        {
            return await Repository.InsertAsync<SMS_SKU_ATTR_VALUE>(sMS_SKU_ATTR_VALUE, transaction);
        }

        public async Task<string> AddAdress(SMS_SKU_ADDRESS sMS_SKU_ADDRESS, IDbTransaction transaction)
        {
            return await Repository.InsertAsync<SMS_SKU_ADDRESS>(sMS_SKU_ADDRESS, transaction);
        }

        public async Task<bool> DeleteSkuAttrValueBySkuId(string skuId, IDbTransaction transaction)
        {
            string sql = @"delete from SMS_SKU_ATTR_VALUE where ID in 
                        (select ssav.ID from SMS_SKU_ATTR_VALUE ssav 
                        LEFT JOIN SMS_SKU ss on ss.ID = ssav.SKU_ID 
                        where ss.ID = @skuId) ";
            return await Repository.ExecuteAsync(sql, new { skuId }, transaction) > 0 ? true : false;
        }

        public async Task<bool> DeleteSkuAddressBySkuId(string skuId, IDbTransaction transaction)
        {
            string sql = @"delete from SMS_SKU_ADDRESS where ID in 
                        (select ssav.ID from SMS_SKU_ADDRESS ssav 
                        LEFT JOIN SMS_SKU ss on ss.ID = ssav.SKU_ID 
                        where ss.ID = @skuId) ";
            return await Repository.ExecuteAsync(sql, new { skuId }, transaction) > 0 ? true : false;
        }

        public async Task<IEnumerable<SkuModel>> GetSameSku(SkuAddModel model)
        {
            string sql = @"select * from SMS_SKU
                            where SPU_ID = @SpuId 
                            and BRAND = @Brand
                            and UNIT = @Unit
                            and TOOL = @Tool
                            and STATUS = @Status";
            IEnumerable<SMS_SKU> entityList = await Repository.GetGroupAsync<SMS_SKU>(sql, model);
            return EntityListToModelList(entityList);
        }

        public SkuModel EntityToModel(SMS_SKU entity)
        {
            return new SkuModel
            {
                Id = entity?.ID,
                SkuNo = entity?.SKU_NO,
                SkuName = entity?.SKU_NAME,
                Brand = entity?.BRAND,
                Price = (int)entity?.PRICE,
                TotalCount = (int)entity?.TOTAL_COUNT,
                Alarm = (int)entity?.ALARM,
                Description = entity?.DESCRIPTION,
                Tool = (int)entity?.TOOL,
                Status = (int)entity?.STATUS,
                OldPartId = entity?.OLD_PARTID,
                Catalog2Id = entity?.CATALOG2_ID,
                OCD = (DateTime)entity?.OCD,
                LUD = (DateTime)entity?.LUD
            };
        }
        public IEnumerable<SkuModel> EntityListToModelList(IEnumerable<SMS_SKU> entityList)
        {
            List<SkuModel> modelList = new List<SkuModel>();
            foreach (var entity in entityList)
            {
                modelList.Add(EntityToModel(entity));
            }
            return modelList;
        }

        public async Task<IEnumerable<SkuAttrModel>> SelectAttrBySkuId(string skuId)
        {
            string sql = @"select ssav.ID Id, bca.ATTR_NAME AttrName, psav.VALUE Value, ssav.SPU_ATTR_VALUE_ID SpuAttrValueId
                    from SMS_SKU_ATTR_VALUE ssav
                    LEFT JOIN SMS_SKU ss on ss.ID = ssav.SKU_ID
                    LEFT JOIN PMS_SPU_ATTR_VALUE psav on ssav.SPU_ATTR_VALUE_ID = psav.ID
                    LEFT JOIN PMS_SPU_ATTR psa on psav.SPU_ATTR_ID = psa.ID
                    LEFT JOIN BMMS_CATALOG_ATTR bca on bca.ID = psa.ATTR_ID
                    where ss.ID = @skuId";
            return await Repository.GetGroupAsync<SkuAttrModel>(sql, new { skuId });
        }

        public async Task<IEnumerable<SkuAddressModel>> SelectAddressBySkuId(string skuId)
        {
            string sql = @"select s.ID Id, s.ROOM Room, s.SELF Self, s.QUANTITY Quantity 
                        from SMS_SKU_ADDRESS s
                        where SKU_ID = @skuId";
            return await Repository.GetGroupAsync<SkuAddressModel>(sql, new { skuId });
        }

        public async Task<SkuModel> GetSkuById(string skuId)
        {
            SMS_SKU entity = await Repository.GetByIdAsync<SMS_SKU>(skuId);
            return EntityToModel(entity);
        }

        public async Task<bool> UpdateSkuTotalCount(string SkuId, IDbTransaction transaction)
        {
            string sql = @"update SMS_SKU
                    set TOTAL_COUNT = (
	                    select SUM(ssa.QUANTITY) 
	                    from SMS_SKU_ADDRESS ssa
	                    where ssa.SKU_ID = @SkuId
                    )
                    where ID = @SkuId";
            return await Repository.ExecuteAsync(sql, new { SkuId }, transaction) > 1 ? true : false;
        }

        public async Task<SkuAddressModel> SelectAddressByAddressId(string AddressId)
        {
            string sql = @"select ID Id, SKU_ID SkuId, ROOM Room, SELF Self, QUANTITY Quantity
                        from SMS_SKU_ADDRESS where ID = @AddressId";
            IEnumerable<SkuAddressModel> addressList = await Repository.GetGroupAsync<SkuAddressModel>(sql, new { AddressId });
            if(addressList != null && addressList.Count() > 0)
            {
                return addressList.ElementAt(0);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateSkuTotalCountByAddressId(string addressId, IDbTransaction transaction)
        {
            string sql = @"update SMS_SKU
                    set TOTAL_COUNT = (
	                    select SUM(ssa.QUANTITY) 
	                    from SMS_SKU_ADDRESS ssa
	                    where ssa.SKU_ID = (
	                        select SKU_ID
	                        from SMS_SKU_ADDRESS 
	                        where ID = @addressId
                        )
                    )
                    where ID = (
	                    select SKU_ID
	                    from SMS_SKU_ADDRESS 
	                    where ID = @addressId
                    )";
            return await Repository.ExecuteAsync(sql, new { addressId }, transaction) > 1 ? true : false;
        }

        public async Task<SkuModel> GetSkuByAddressId(string addressId)
        {
            string sql = @"select * from SMS_SKU 
                    where ID = (
	                    select SKU_ID from SMS_SKU_ADDRESS
	                    where ID = @addressId
                    )";
            IEnumerable<SMS_SKU> entityList = await Repository.GetGroupAsync<SMS_SKU>(sql, new { addressId });
            return EntityToModel(entityList.First());
        }
    }
}
