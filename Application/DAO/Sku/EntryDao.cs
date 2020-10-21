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

        public Task AddEntrySku(IEnumerable<EntrySkuModel> entrySkuList, string entryId, IDbTransaction transaction)
        {
            throw new NotImplementedException();
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
                    left join SMS_SKU_ENTRY sse on sn.ID = sse.ENTRY_ID
                    left join SMS_SKU ss on ss.ID = sse.SKU_ID
                    left join PMS_SPU ps on ss.SPU_ID = ps.ID
                    where ";
            strSql += (string.IsNullOrWhiteSpace(model.SearchStr)) ? " 1 = 1 " : " ss.OPERATOR like '%' + '{0}' + '%'" + 
                "Or ss.ENTRY_NO like '%' + '{0}' + '%' OR ps.PRODUCT_NAME like '%' + '{0}' + '%'" + 
                " Or ss.DESCRIPTION like '%' + '{0}' + '%'";    // 还可查供应商 待定 
            string sql = string.Format(strSql, model.SearchStr);
            EntryListWithPagingModel pageModel = new EntryListWithPagingModel();
            string countSql = "Select Count(1) from (" + sql + ") as temp";
            pageModel.TotalCount = await Repository.CountAsync(countSql);
            pageModel.Items = await Repository.GetPageAsync<EntryModel>(model.PageIndex, model.PageSize, sql, " order by ss.OCD Desc");
            return pageModel;
        }

        public async Task<IEnumerable<SkuModel>> GetListEntrySkuByEntryId(string id)
        {
            // 注意这里的Id 是EntrySku 的Id 不是Sku id
            string sql = @"select sse.ID Id, sse.QUANTITY Quantity,
                    sse.PRICE Price, sse.TOTAL_PRICE TotalPrice,
                    ps.PRODUCT_NAME SkuName, ss.BRAND Brand, ss.UNIT Unit,
                    sse.STATUS Status, sse.OLD_PARTID OldPartId, ss.CATALOG2_ID Catalog2Id
                    from SMS_SKU_ENTRY sse 
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
            string sql = "select Count(1) SMS_ENTRY where ENTRY_NO = @entryNo";
            return await Repository.CountAsync(sql, new { entryNo }) > 0 ? true : false ;
        }

        public async Task<bool> UpdateDescriptionByEntryId(string entryId, string description)
        {
            string sql = "Update SMS_ENTRY set DESCRIPTION = @description where entryId = @entryId";
            return await Repository.ExecuteAsync(sql, new { entryId, description }) > 0 ? true : false;
        }

        public Task UpdateSkuNum(EntrySkuAddModel model, IDbTransaction transaction)
        {
            foreach(var entrySku in entrySkuList)
            {

            }
        }
    }
}
