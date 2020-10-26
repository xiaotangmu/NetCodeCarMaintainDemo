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
    public class EntryDao : BaseDAO, IEntryRepository
    {
        public EntryDao() { }

        public EntryDao(IDataRepository repository) : base(repository) { }

        public async Task<string> AddEntrySku(SMS_ENTRY_SKU entity, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync<SMS_ENTRY_SKU>(entity, transaction);
        }

        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }

        public async Task<IEnumerable<EntryModel>> GetAll()
        {
            string sql = @"select sn.ID Id, sn.OPERATOR Operartor, sn.TOTAL_PRICE TotalPrice,
                    sn.ENTRY_DATE EntryDate, sn.BATCH Batch, sn.SUPPLIER_ID SupplierId,
                    sn.DESCRIPTION Description, sn.ENTRY_NO EntryNo
                    from SMS_ENTRY sn where 1 = 1";
            IEnumerable<EntryModel> entityList = await Repository.GetGroupAsync<EntryModel>(sql);
            return entityList;
        }

        public async Task<EntryListWithPagingModel> GetEntryPageBySearch(EntryPageSearchModel model)
        {
            string strSql = @"select DISTINCT sn.ID Id, sn.OPERATOR Operartor, sn.TOTAL_PRICE TotalPrice,
                    sn.ENTRY_DATE EntryDate, sn.BATCH Batch, sn.SUPPLIER_ID SupplierId,
                    sn.DESCRIPTION Description, sn.ENTRY_NO EntryNo
                    from SMS_ENTRY sn
                    left join SMS_ENTRY_SKU sse on sn.ID = sse.ENTRY_ID
                    left join SMS_SKU ss on ss.ID = sse.SKU_ID
                    left join PMS_SPU ps on ss.SPU_ID = ps.ID
                    where ";
            strSql += (string.IsNullOrWhiteSpace(model.SearchStr)) ? " 1 = 1 " : " (sn.OPERATOR like '%' + '{0}' + '%'" + 
                "Or sn.ENTRY_NO like '%' + '{0}' + '%' OR ps.PRODUCT_NAME like '%' + '{0}' + '%'" +
                " Or sn.DESCRIPTION like '%' + '{0}' + '%') ";    // 还可查供应商 待定 
            strSql += model?.StartTime.Year > 1900 ? " and sn.ENTRY_DATE >= '{1}'": ""; 
            strSql += model?.EndTime.Year > 1900 ? " and '{2}' >= sn.ENTRY_DATE" : ""; 
            string sql = string.Format(strSql, model.SearchStr, model.StartTime, model.EndTime);
            EntryListWithPagingModel pageModel = new EntryListWithPagingModel();
            string countSql = "Select Count(1) from (" + sql + ") as temp";
            pageModel.TotalCount = await Repository.CountAsync(countSql);
            pageModel.Items = await Repository.GetPageAsync<EntryModel>(model.PageIndex, model.PageSize, sql, "order by sn.ENTRY_DATE Desc");
            return pageModel;
        }

        public async Task<IEnumerable<SkuModel>> GetListEntrySkuByEntryId(string id)
        {
            // 注意这里输出的Id 是EntrySku 的Id 不是Sku id
            string sql = @"select sse.ID Id, sse.QUANTITY TotalCount,
                    sse.PRICE Price, sse.TOTAL_PRICE TotalPrice,
                    ps.PRODUCT_NAME SkuName, ss.BRAND Brand, ss.UNIT Unit,
                    sse.STATUS Status, sse.OLD_PARTID OldPartId, ss.CATALOG2_ID Catalog2Id,
                    sse.ADDRESS_ID AddressId
                    from SMS_ENTRY_SKU sse 
                    left join SMS_SKU ss on ss.ID = sse.SKU_ID
                    left join PMS_SPU ps on ss.SPU_ID = ps.ID
                    where sse.ENTRY_ID = @id";
            return await Repository.GetGroupAsync<SkuModel>(sql, new { id });
        }

        public async Task<string> Insert(SMS_ENTRY sMS_ENTRY, IDbTransaction transaction)
        {
            return await Repository.InsertAsync<SMS_ENTRY>(sMS_ENTRY, transaction);
        }

        public async Task<bool> IsExistByEntryNo(string entryNo)
        {
            string sql = string.Format("select Count(1) from SMS_ENTRY where ENTRY_NO = '{0}'", entryNo);
            return await Repository.CountAsync(sql) > 0 ? true : false ;
        }

        public async Task<bool> UpdateDescriptionByEntryId(string entryId, string description)
        {
            string sql = "Update SMS_ENTRY set DESCRIPTION = @description where ID = @entryId";
            return await Repository.ExecuteAsync(sql, new { entryId, description }) > 0 ? true : false;
        }

        public async Task<bool> UpdateAddressSkuNumByAddressId(EntrySkuAddModel model, IDbTransaction transaction)
        {
            // 更新具体地址数量
            string sql = @"update SMS_SKU_ADDRESS
                    set QUANTITY = (QUANTITY + @Quantity)
                    where ID = @AddressId";
            return await Repository.ExecuteAsync(sql, new { Quantity = model.Quantity, AddressId = model.AddressId }, transaction) > 1 ? true : false;
        }
        public async Task<bool> DeleteEntrySkuByEntryId(string entryId, IDbTransaction transaction = null)
        {
            string sql = "delete from SMS_ENTRY_SKU where ENTRY_ID = @entryId";
            return await Repository.ExecuteAsync(sql, new { entryId }, transaction) > 0 ? true : false;
        }

        public async Task<bool> DeleteEntryById(string Id, IDbTransaction transaction = null)
        {
            string sql = "delete from SMS_ENTRY where ID = @Id";
            return await Repository.ExecuteAsync(sql, new { Id }, transaction) > 0 ? true : false;
        }
        public async Task<bool> UpdateEntry(EntryUpdateModel model, IDbTransaction transaction)
        {
            string sql = @"Update SMS_ENTRY 
                set OPERATOR = @Operator, 
                    ENTRY_DATE = @EntryDate,
                    TOTAL_PRICE = @TotalPrice,
                    BATCH = @Batch,
                    SUPPLIER_ID = @SupplierId,
                    DESCRIPTION = @Description,
                    LUD = CURRENT_TIMESTAMP
                where ID = @Id";
            return await Repository.ExecuteAsync(sql, model, transaction) > 0 ? true : false;
        }
    }
}
