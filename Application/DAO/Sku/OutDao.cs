using DateModel.Sku;
using Interface.Sku;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Sku;

namespace DAO.Sku
{
    public class OutDao : BaseDAO, IOutRepository
    {
        public OutDao() { }
        public OutDao(IDataRepository repository) : base(repository) { }

        public async Task<string> AddOutSku(SMS_OUT_SKU entity, IDbTransaction transaction)
        {
            return await Repository.InsertAsync<SMS_OUT_SKU>(entity, transaction);
        }

        public async Task<bool> CheckSkuIsEnough(OutSkuAddModel outSku)
        {
            string sql = string.Format("select (QUANTITY - {0}) from SMS_SKU_ADDRESS where ID = '{1}'", outSku.Quantity, outSku.AddressId);
            return await Repository.CountAsync(sql) < 0 ? false : true;
        }

        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }

        public async Task<IEnumerable<OutModel>> GetAll()
        {
            string sql = @"select so.ID Id, so.OPERATOR Operator, so.OUT_NO OutNo, so.TOTAL_PRICE TotalPrice,
                    so.OUT_DATE OutDate, so.BATCH Batch, so.CLIENT_ID ClientId,
                    so.DESCRIPTION Description, so.OCD, so.LUD, so.OCU, so.LUC
                    from SMS_OUT so
                    where 1 = 1";
            return await Repository.GetGroupAsync<OutModel>(sql);
        }

        public async Task<IEnumerable<SkuEntryOrOutModel>> GetListOutSkuByOutId(string id)
        {
            // 注意这里的输出的Id 是OutSku 的Id 不是Sku id
            string sql = @"select sse.ID Id, sse.QUANTITY TotalCount,
                    sse.PRICE Price, sse.TOTAL_PRICE TotalPrice,
                    ps.PRODUCT_NAME SkuName, ss.BRAND Brand, ss.UNIT Unit,
                    ss.STATUS Status, ss.OLD_PARTID OldPartId, ss.CATALOG2_ID Catalog2Id,
                    sse.ADDRESS_ID AddressId, sse.SKU_ID SkuId
                    from SMS_OUT_SKU sse 
                    left join SMS_SKU ss on ss.ID = sse.SKU_ID
                    left join PMS_SPU ps on ss.SPU_ID = ps.ID
                    where sse.OUT_ID = @id";
            return await Repository.GetGroupAsync<SkuEntryOrOutModel>(sql, new { id });
        }

        public async Task<OutListWithPagingModel> GetOutPageBySearch(OutPageSearchModel model)
        {
            string strSql = @"select DISTINCT sn.ID Id, sn.OPERATOR Operartor, sn.TOTAL_PRICE TotalPrice,
                    sn.OUT_DATE OutDate, sn.BATCH Batch, sn.CLIENT_ID ClientId,
                    sn.DESCRIPTION Description, sn.OUT_NO OutNo
                    from SMS_OUT sn
                    left join SMS_OUT_SKU sos on sn.ID = sos.OUT_ID
                    left join SMS_SKU ss on ss.ID = sos.SKU_ID
                    left join PMS_SPU ps on ss.SPU_ID = ps.ID
                    where ";
            strSql += (string.IsNullOrWhiteSpace(model.SearchStr)) ? " 1 = 1 " : " (sn.OPERATOR like '%' + '{0}' + '%'" +
                "Or sn.OUT_NO like '%' + '{0}' + '%' OR ps.PRODUCT_NAME like '%' + '{0}' + '%'" +
                " Or sn.DESCRIPTION like '%' + '{0}' + '%') ";    // 还可查供应商 待定 
            strSql += model?.StartTime.Year > 1900 ? " and sn.OUT_DATE >= '{1}'" : "";
            strSql += model?.EndTime.Year > 1900 ? " and '{2}' >= sn.OUT_DATE" : "";
            string sql = string.Format(strSql, model.SearchStr, model.StartTime, model.EndTime);
            OutListWithPagingModel pageModel = new OutListWithPagingModel();
            string countSql = "Select Count(1) from (" + sql + ") as temp";
            pageModel.TotalCount = await Repository.CountAsync(countSql);
            pageModel.Items = await Repository.GetPageAsync<OutModel>(model.PageIndex, model.PageSize, sql, "order by sn.OUT_DATE Desc");
            return pageModel;
        }

        public async Task<string> Insert(SMS_OUT sMS_OUT, IDbTransaction transaction)
        {
            return await Repository.InsertAsync<SMS_OUT>(sMS_OUT, transaction);
        }

        public async Task<bool> IsExistByOutNo(string outNo)
        {
            string sql = string.Format("select Count(1) from SMS_OUT where OUT_NO = '{0}'", outNo);
            return await Repository.CountAsync(sql) > 0 ? true : false;
        }

        public async Task<bool> UpdateAddressSkuNumByAddressId(OutSkuAddModel model, IDbTransaction transaction)
        {
            // 更新具体地址数量
            string sql = @"update SMS_SKU_ADDRESS
                    set QUANTITY = (QUANTITY - @Quantity)
                    where ID = @AddressId";
            return await Repository.ExecuteAsync(sql, model, transaction) > 1 ? true : false;
        }

        public async Task<bool> UpdateDescriptionByOutId(string outId, string description)
        {
            string sql = "Update SMS_OUT set DESCRIPTION = @description where ID = @outId";
            return await Repository.ExecuteAsync(sql, new { outId, description }) > 0 ? true : false;
        }

        public async Task<bool> DeleteOutSkuByOutId(string outId, IDbTransaction transaction = null)
        {
            string sql = "delete from SMS_OUT_SKU where OUT_ID = @outId";
            return await Repository.ExecuteAsync(sql, new { outId }, transaction) > 0 ? true : false;
        }

        public async Task<bool> DeleteOutById(string Id, IDbTransaction transaction = null)
        {
            string sql = "delete from SMS_OUT where ID = @Id";
            return await Repository.ExecuteAsync(sql, new { Id }, transaction) > 0 ? true : false;
        }

        public async Task<bool> UpdateOut(OutUpdateModel model, IDbTransaction transaction)
        {
            string sql = @"Update SMS_OUT 
                set OPERATOR = @Operator, 
                    OUT_DATE = @OutDate,
                    TOTAL_PRICE = @TotalPrice,
                    BATCH = @Batch,
                    CLIENT_ID = @ClientId,
                    DESCRIPTION = @Description,
                    LUD = CURRENT_TIMESTAMP
                where ID = @Id";
            return await Repository.ExecuteAsync(sql, model, transaction) > 0 ? true : false;
        }

        public async Task<IEnumerable<SkuModel>> GetListOutSkuToolByOutId(string Id)
        {
            // 注意这里的输出的Id 是OutSku 的Id 不是Sku id
            string sql = @"select sse.ID Id, sse.QUANTITY TotalCount,
                    sse.PRICE Price, sse.TOTAL_PRICE TotalPrice,
                    ps.PRODUCT_NAME SkuName, ss.BRAND Brand, ss.UNIT Unit,
                    ss.STATUS Status, ss.OLD_PARTID OldPartId, ss.CATALOG2_ID Catalog2Id,
                    sse.ADDRESS_ID AddressId
                    from SMS_OUT_SKU sse 
                    left join SMS_SKU ss on ss.ID = sse.SKU_ID
                    left join PMS_SPU ps on ss.SPU_ID = ps.ID
                    where sse.OUT_ID = @Id and sse.TOOL = 1";
            return await Repository.GetGroupAsync<SkuModel>(sql, new { Id });
        }
    }
}
