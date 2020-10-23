using DateModel.Sku;
using Interface;
using Interface.Sku;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.Sku;

namespace DAO.Sku
{
    public class CheckDao : BaseDAO, ICheckRepository
    {
        public CheckDao() { }
        public CheckDao(IDataRepository repository) : base(repository) { }

        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }
        public async Task<PageModel<CheckModel>> GetCheckPageBySearch(CheckPageSearchModel model)
        {
            string strSql = @"select sc.ID Id, sc.CHECK_NO CheckNo, sc.OPERATOR Operator, 
            sc.ACCOUNT_PRICE AccountPrice, sc.CHECK_PRICE CheckPrice, sc.DIFFERENCE_PRICE DifferencePrice, 
            sc.DESCRIPTION Description, sc.STATUS Status, sc.OCU, sc.OCD, sc.LUC, sc.LUD, sc.CHECK_DATE CheckDate
            from SMS_CHECK sc 
            where ";
            // 模糊查询：操作员，盘点单号，备注
            strSql += (string.IsNullOrWhiteSpace(model.SearchStr)) ? " 1 = 1 " : " (sc.OPERATOR like '%' + '{0}' + '%' " +
                "Or sc.CHECK_NO like '%' + '{0}' + '%' " +
                " Or sc.DESCRIPTION like '%' + '{0}' + '%') "; 
            // 时间范围
            strSql += model?.StartTime.Year > 1900 ? " and sc.CHECK_DATE >= '{1}'" : "";
            strSql += model?.EndTime.Year > 1900 ? " and '{2}' >= sc.CHECK_DATE" : "";
            // 是否有差错: 0不开启,1差,2无差 
            strSql += model?.Difference == 1 ? " and sc.DIFFERENCE_PRICE <> 0 " : ""; // 有差
            strSql += model?.Difference == 2 ? " and sc.DIFFERENCE_PRICE = 0 " : ""; // 无差
            // 状态 0 未处理，1 处理    -- 只在有差的情况作用
            if(model?.Difference == 1)
            {
                strSql += model?.Status < 0 ? "" : " and sc.STATUS = {3} "; //
            }
            string sql = string.Format(strSql, model.SearchStr, model.StartTime, model.EndTime, model.Status);
            PageModel<CheckModel> pageModel = new PageModel<CheckModel>();
            string countSql = "Select Count(1) from (" + sql + ") as temp";
            pageModel.TotalCount = await Repository.CountAsync(countSql);
            pageModel.Items = await Repository.GetPageAsync<CheckModel>(model.PageIndex, model.PageSize, sql, "order by sc.CHECK_DATE Desc");
            return pageModel;
        }

        public async Task<bool> HasCheckSkuToDealByCheckSkuId(string CheckSkuId, IDbTransaction transaction = null)
        {
            IDbCommand command = Repository.DbSession.Connection.CreateCommand();
            command.Connection = Repository.DbSession.Connection;
            command.Transaction = (IDbTransaction)transaction;

            string sql = @"select Count(1) from SMS_CHECK_SKU scs2
                where scs2.STATUS = 1 and scs2.CHECK_ID = (
                select sc.ID from SMS_CHECK_SKU scs
                left join SMS_CHECK sc on sc.ID = scs.CHECK_ID
                where scs.ID = '{0}')";

            command.CommandText = sql;
            return (int)command.ExecuteScalar() > 0 ? true : false;
            
            //sql = string.Format(sql, CheckSkuId);
            //return await Repository.CountAsync(sql) > 0 ? true : false;
        }

        public async Task<string> Insert(SMS_CHECK sMS_CHECK, IDbTransaction transaction)
        {
            return await Repository.InsertAsync<SMS_CHECK>(sMS_CHECK, transaction);
        }

        public async Task<string> InsertCheckSku(SMS_CHECK_SKU sMS_CHECK_SKU, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync<SMS_CHECK_SKU>(sMS_CHECK_SKU, transaction);
        }

        public async Task<bool> IsExistByCheckNo(string checkNo)
        {
            string sql = string.Format("select Count(1) from SMS_CHECK where CHECK_NO = '{0}'", checkNo);
            return await Repository.CountAsync(sql) > 0 ? true : false;
        }

        public async Task<IEnumerable<CheckModel>> SelectAll()
        {
            string sql = @"select sc.ID Id, sc.CHECK_NO CheckNo, sc.OPERATOR Operator, 
                sc.ACCOUNT_PRICE AccountPrice, sc.CHECK_PRICE CheckPrice, sc.DIFFERENCE_PRICE DifferencePrice, 
                sc.DESCRIPTION Description, sc.STATUS Status, sc.OCU, sc.OCD, sc.LUC, sc.LUD, sc.CHECK_DATE CheckDate
                from SMS_CHECK sc 
                where  1 = 1";
            return await Repository.GetGroupAsync<CheckModel>(sql);
        }

        public async Task<IEnumerable<CheckSkuModel>> SelectCheckSkuByCheckId(string id)
        {
            string sql = @"select scs.ID Id, scs.CHECK_ID CheckId, scs.ADDRESS_ID AdressId, scs.CHECK_NUM CheckNum, 
                scs.CHECK_PRICE CheckPrice, scs.PRICE Price, scs.ACCOUNT_NUM AccountNum, scs.ACCOUNT_PRICE AccountPrice,
                scs.DIFFERENCE_NUM DifferenceNum, scs.DESCRIPTION Description,
                scs.STATUS Status, scs.SKU_ID SkuId, scs.DIFFERENCE_PRICE DifferencPrice
                from SMS_CHECK_SKU scs
                where scs.CHECK_ID = @id";
            return await Repository.GetGroupAsync<CheckSkuModel>(sql, new { id });
        }

        public async Task<bool> UpdateCheckSkuStatus(CheckUpdateModel model, IDbTransaction transaction = null)
        {
            string sql = "Update SMS_CHECK_SKU set DESCRIPTION = @Description, STATUS = 1 where ID = @Id";
            return await Repository.ExecuteAsync(sql, model, transaction) > 0 ? true : false;
        }

        public async Task<bool> UpdateCheckSkuStatusByCheckId(string id, IDbTransaction transaction = null)
        {
            string sql = "Update SMS_CHECK_SKU set STATUS = 1 where CHECK_ID = @id";
            return await Repository.ExecuteAsync(sql, new { id }, transaction) > 0 ? true : false;
        }

        public async Task<bool> UpdateCheckStatusByCheckSkuId(string id, IDbTransaction transaction = null)
        {
            string sql = @"Update SMS_CHECK
                set STATUS = 1
                where ID = (
                select sc.ID from SMS_CHECK_SKU scs
                left join SMS_CHECK sc on sc.ID = scs.CHECK_ID
                where scs.ID = @id)";
            return await Repository.ExecuteAsync(sql, new { id }, transaction) > 0 ? true : false;
        }

        public async Task<bool> UpdateCheckStatusById(CheckUpdateModel model, IDbTransaction transaction)
        {
            string sql = @"Update SMS_CHECK
                set STATUS = 1,
                    DESCRIPTION = @Description
                where ID = @Id";
            return await Repository.ExecuteAsync(sql, model, transaction) > 0 ? true : false;
        }
    }
}
