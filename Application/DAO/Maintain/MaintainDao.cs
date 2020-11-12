using DateModel.Maintain;
using Interface.Maintain;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.Maintain;
using ViewModel.Sku;

namespace DAO.Maintain
{
    public class MaintainDao : BaseDAO, IMaintainRepository
    {
        public MaintainDao() { }
        public MaintainDao(IDataRepository repository) : base(repository) { }

        public async Task<bool> Delete(string id, IDbTransaction transaction = null)
        {
            string sql = "delete from MMS_MAINTAIN where ID = @id";
            return await Repository.ExecuteAsync(sql, new { id }, transaction) > 0 ? true : false;
        }

        public async Task<bool> DeleteMaintainOutByMaintainId(string id, IDbTransaction transaction = null)
        {
            string sql = "delete from MMS_MAINTAIN_OUT where MAINTAIN_ID = @id";
            return await Repository.ExecuteAsync(sql, new { id }, transaction) > 0 ? true : false;
        }

        public async Task<bool> DeleteNoDealOldPartByMaintainId(string id, IDbTransaction transaction)
        {
            string sql = "delete from MMS_MAINTAIN_OLDPART where MAINTAIN_ID = @id and DEAL_NUM = 0 and STATUS = 0";
            return await Repository.ExecuteAsync(sql, new { id }, transaction) > 0 ? true : false;
        }

        public async Task<bool> DeleteNoDealToolByMaintainId(string id, IDbTransaction transaction)
        {
            string sql = "delete from MMS_MAINTAIN_TOOL where MAINTAIN_ID = @id and DEAL_NUM = 0 and STATUS = 0";
            return await Repository.ExecuteAsync(sql, new { id }, transaction) > 0 ? true : false;
        }

        public async Task<bool> DeleteOldPartByMaintainId(string id, IDbTransaction transaction = null)
        {
            string sql = "delete from MMS_MAINTAIN_OLDPART where MAINTAIN_ID = @id";
            return await Repository.ExecuteAsync(sql, new { id }, transaction) > 0 ? true : false;
        }

        public async Task<bool> DeleteToolByMaintainId(string id, IDbTransaction transaction = null)
        {
            string sql = "delete from MMS_MAINTAIN_TOOL where MAINTAIN_ID = @id";
            return await Repository.ExecuteAsync(sql, new { id }, transaction) > 0 ? true : false;
        }

        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }

        public async Task<IEnumerable<MaintainShowModel>> GetNoDealToolOrPartWithMaintain()
        {
            string sql = @"select DISTINCT mm.ID Id, mm.MAINTAIN_NO MaintainNo, mm.STAFF Staff,
                    mm.APPOINTMENT_ID AppointmentId, mm.START_DATE StartDate,
                    mm.STATUS Status, mm.RETURN_DATE ReturnDate, mm.OPERATOR Operator,
                    mm.OCU, mm.OCD, mm.LUC, mm.LUD , cc.COMPANY CompanyName, ma.TYPE Type,
                    ma.CONTACT Contact, ma.PHONE Phone, ma.CAR_LICENSE CarLicense
                    from MMS_MAINTAIN mm
                    left join MMS_APPOINTMENT ma on mm.APPOINTMENT_ID = ma.ID
                    left join CMS_CLIENT cc on cc.ID = ma.COMPANY_ID 
                    left join MMS_MAINTAIN_TOOL mmt on mm.ID = mmt.MAINTAIN_ID
                    left join MMS_MAINTAIN_OLDPART mmo on mmo.MAINTAIN_ID = mm.ID
                    where mmt.STATUS = 0 OR mmo.STATUS = 0
                     order by mm.OCD Desc";
            return await Repository.GetGroupAsync<MaintainShowModel>(sql);
        }

        public async Task<IEnumerable<MaintainOldPartModel>> GetOldPartsByMaintainId(string id)
        {
            string sql = @"select ss.SKU_NAME SkuName, ss.BRAND Brand, ss.UNIT Unit,
                        mmo.ID Id, mmo.MAINTAIN_ID MaintainId, mmo.NUM Num, mmo.DEAL_NUM DealNum,
                        mmo.PRICE Price, mmo.STATUS Status, mmo.SKU_ID SkuId, 
                        mmo.REMARK Remark
                        from MMS_MAINTAIN_OLDPART mmo
                        LEFT JOIN SMS_SKU ss on ss.ID = mmo.SKU_ID
                        where mmo.MAINTAIN_ID = @id";
            return await Repository.GetGroupAsync<MaintainOldPartModel>(sql, new { id });
        }

        public async Task<IEnumerable<SkuAttrModel>> GetOldPartTypeById(string id)
        {
            string sql = @"select bca.ATTR_NAME AttrName, psav.VALUE value, psav.ID SpuAttrValueId
                    from MMS_MAINTAIN_OLDPART mmo 
                    LEFT JOIN SMS_SKU ss on ss.ID = mmo.SKU_ID
                    LEFT JOIN SMS_SKU_ATTR_VALUE ssav on ssav.SKU_ID = ss.ID
                    left JOIN PMS_SPU_ATTR_VALUE psav on psav.ID = ssav.SPU_ATTR_VALUE_ID
                    LEFT JOIN PMS_SPU_ATTR psa on psa.ID = psav.SPU_ATTR_ID
                    LEFT JOIN BMMS_CATALOG_ATTR bca on bca.ID = psa.ATTR_ID
                    where mmo.ID = @id";
            return await Repository.GetGroupAsync<SkuAttrModel>(sql, new { id });
        }

        public async Task<IEnumerable<SkuModel>> GetSkusByMaintainId(string id)
        {
            string sql = @"select ss.SKU_NAME SkuName, ss.BRAND Brand, ss.UNIT Unit,
                    sos.PRICE Price, sos.QUANTITY TotalCount
                    from MMS_MAINTAIN_OUT mmo
                    LEFT JOIN SMS_OUT so on so.ID = mmo.OUT_ID
                    LEFT JOIN SMS_OUT_SKU sos on so.ID = sos.OUT_ID
                    Left join SMS_SKU_ADDRESS ssa on ssa.ID = sos.ADDRESS_ID 
                    left join SMS_SKU ss on ss.ID = ssa.SKU_ID
                    where mmo.MAINTAIN_ID = @id and sos.TOOL <> 1";
            return await Repository.GetGroupAsync<SkuModel>(sql, new { id });
        }

        public async Task<IEnumerable<MaintainToolModel>> GetToolsByMaintainId(string id)
        {
            string sql = @"select ss.SKU_NAME SkuName, ss.BRAND Brand, ss.UNIT Unit,
                    sos.PRICE Price, sos.QUANTITY TotalCount, mmt.STATUS Status, 
                    mmt.REMARK Remark, mmt.DEAL_NUM DealNum, mmt.NUM num, mmt.COMPENSATION Compensation,
                    mmt.ID Id, mmt.OUT_SKU_ID as OutSkuId, ss.ID as SkuId
                    from MMS_MAINTAIN_TOOL mmt 
                    LEFT JOIN SMS_OUT_SKU sos on sos.ID = mmt.OUT_SKU_ID
                    Left join SMS_SKU_ADDRESS ssa on ssa.ID = sos.ADDRESS_ID 
                    left join SMS_SKU ss on ss.ID = ssa.SKU_ID
                    where mmt.MAINTAIN_ID = @id";
            return await Repository.GetGroupAsync<MaintainToolModel>(sql, new { id });
        }

        public async Task<IEnumerable<SkuAttrModel>> GetToolTypeById(string id)
        {
            string sql = @"select bca.ATTR_NAME AttrName, psav.VALUE value, psav.ID SpuAttrValueId
                    from MMS_MAINTAIN_TOOL mmt 
                    LEFT JOIN SMS_OUT_SKU sos on sos.ID = mmt.OUT_SKU_ID
                    Left join SMS_SKU_ADDRESS ssa on ssa.ID = sos.ADDRESS_ID 
                    left join SMS_SKU ss on ss.ID = ssa.SKU_ID
                    LEFT JOIN SMS_SKU_ATTR_VALUE ssav on ssav.SKU_ID = ss.ID
                    left JOIN PMS_SPU_ATTR_VALUE psav on psav.ID = ssav.SPU_ATTR_VALUE_ID
                    LEFT JOIN PMS_SPU_ATTR psa on psa.ID = psav.SPU_ATTR_ID
                    LEFT JOIN BMMS_CATALOG_ATTR bca on bca.ID = psa.ATTR_ID
                    where mmt.ID = @id";
            return await Repository.GetGroupAsync<SkuAttrModel>(sql, new { id });
        }

        /// <summary>
        /// 有已经处理的OldPart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> HasDealOldPartByMaintainId(string id)
        {
            string sql = @"select Count(1) from MMS_MAINTAIN_OLDPART
                    where MAINTAIN_ID = '{0}' and (DEAL_NUM > 0 OR STATUS = 1)";
            sql = string.Format(sql, id);
            return await Repository.CountAsync(sql) > 0 ? true : false;
        }
        /// <summary>
        /// 有已经处理的Tool
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> HasDealToolByMaintainId(string id)
        {
            string sql = @"select Count(1) from MMS_MAINTAIN_TOOL
                    where MAINTAIN_ID = '{0}' and (DEAL_NUM > 0 OR STATUS = 1)";
            sql = string.Format(sql, id);
            return await Repository.CountAsync(sql) > 0 ? true : false;
        }

        public async Task<bool> HasNoDealOlPartByMaintainId(string id)
        {
            string sql = @"select Count(1) from MMS_MAINTAIN_OLDPART
                    where MAINTAIN_ID = '{0}' and STATUS = 0 and DEAL_NUM = 0";
            sql = string.Format(sql, id);
            return await Repository.CountAsync(sql) > 0 ? true : false;
        }

        public async Task<bool> HasNoDealToolByMaintainId(string id)
        {
            string sql = @"select Count(1) from MMS_MAINTAIN_TOOL
                    where MAINTAIN_ID = '{0}' and STATUS = 0 and DEAL_NUM = 0";
            sql = string.Format(sql, id);
            return await Repository.CountAsync(sql) > 0 ? true : false;
        }

        public async Task<string> Insert(MMS_MAINTAIN mMS_MAINTAIN, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync<MMS_MAINTAIN>(mMS_MAINTAIN, transaction);
        }

        public async Task<string> InsertMaintainOut(MMS_MAINTAIN_OUT mMS_MAINTAIN_OUT, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync<MMS_MAINTAIN_OUT>(mMS_MAINTAIN_OUT, transaction);
        }

        public async Task<string> InsertOldPart(MMS_MAINTAIN_OLDPART mMS_MAINTAIN_OLDPART, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync<MMS_MAINTAIN_OLDPART>(mMS_MAINTAIN_OLDPART, transaction);
        }

        public async Task<string> InsertTool(MMS_MAINTAIN_TOOL mMS_MAINTAIN_TOOL, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync<MMS_MAINTAIN_TOOL>(mMS_MAINTAIN_TOOL, transaction);
        }

        public async Task<int> IsExistByMaintainNo(string maintainNo)
        {
            string sql = @"select Count(1) from MMS_MAINTAIN
                    where MAINTAIN_NO = '{0}'";
            sql = string.Format(sql, maintainNo);
            return await Repository.CountAsync(sql);
        }

        /// <summary>
        /// 维修单没有签字或者取消
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsNoSignByMaintainId(string id)
        {
            string sql = @"select STATUS from MMS_MAINTAIN
                    where ID = '{0}'";
            sql = string.Format(sql, id);
            MMS_MAINTAIN obj =  await Repository.GetFirstAsync<MMS_MAINTAIN>(sql);
            if(obj == null)
            {
                throw new ViewModel.CustomException.MyServiceException("不存在该维修单");
            }
            if(obj.STATUS > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<IEnumerable<MaintainShowModel>> SelectAll()
        {
            string sql = @"select mm.ID Id, mm.MAINTAIN_NO MaintainNo, mm.STAFF Staff,
                    mm.APPOINTMENT_ID AppointmentId, mm.START_DATE StartDate,
                    mm.STATUS Status, mm.RETURN_DATE ReturnDate, mm.OPERATOR Operator,
                    mm.OCU, mm.OCD, mm.LUC, mm.LUD, cc.COMPANY CompanyName, ma.TYPE Type,
                    ma.CONTACT Contact, ma.PHONE Phone, ma.CAR_LICENSE CarLicense
                    from MMS_MAINTAIN mm
                    left join MMS_APPOINTMENT ma on mm.APPOINTMENT_ID = ma.ID
                    left join CMS_CLIENT cc on cc.ID = ma.COMPANY_ID 
                    where 1 = 1";
            return await Repository.GetGroupAsync<MaintainShowModel>(sql);
        }

        public async Task<PageModel<MaintainShowModel>> SelectListPageBySearch(MaintainPageSearchModel model)
        {
            string strSql = @"select DISTINCT mm.ID Id, mm.MAINTAIN_NO MaintainNo, mm.STAFF Staff,
                    mm.APPOINTMENT_ID AppointmentId, mm.START_DATE StartDate,
                    mm.STATUS Status, mm.RETURN_DATE ReturnDate, mm.OPERATOR Operator,
                    mm.OCU, mm.OCD, mm.LUC, mm.LUD , cc.COMPANY CompanyName, ma.TYPE Type,
                    ma.CONTACT Contact, ma.PHONE Phone, ma.CAR_LICENSE CarLicense
                    from MMS_MAINTAIN mm
                    left join MMS_APPOINTMENT ma on mm.APPOINTMENT_ID = ma.ID
                    left join CMS_CLIENT cc on cc.ID = ma.COMPANY_ID 
                    left join MMS_MAINTAIN_TOOL mmt on mm.ID = mmt.MAINTAIN_ID
                    left join MMS_MAINTAIN_OLDPART mmo on mmo.MAINTAIN_ID = mm.ID
                    where ";
            // 预约时间范围，联系人，联系电话，车牌号，公司名, 描述
            strSql += (string.IsNullOrWhiteSpace(model.SearchStr)) ? " 1 = 1 " : @" (mm.MAINTAIN_NO like '%' + '{0}' + '%' OR mm.STAFF like 
                    '%' + '{0}' + '%' OR mm.OPERATOR like '%' + '{0}' + '%' OR ma.CAR_LICENSE like
                    '%' + '{0}' + '%' OR cc.COMPANY like '%' + '{0}' + '%' OR ma.CONTACT
                    like '%' + '{0}' + '%' OR ma.PHONE like '%' + '{0}' + '%') ";    // 还可查供应商 待定 
            strSql += model?.StartTime.Year > 1900 ? " and mm.START_DATE >= '{1}' " : "";
            strSql += model?.EndTime.Year > 1900 ? " and '{2}' >= ma.START_DATE " : "";
            // 签字处理，0未处理，1已处理，2取消, -1 不开启处理查询 -- Status
            strSql += model?.Status == -1 ? "" : " and mm.STATUS = {3} ";
            strSql += model?.ToolStatus == -1 ? "" : model?.ToolStatus == 0 ? "and mmt.STATUS = {4}" : " and (mmt.STATUS = {4} OR mmt.DEAL_NUM > 0)";
            strSql += model?.OldPartStatus == -1 ? "" : model?.OldPartStatus == 0 ? "and mmo.STATUS = {5}" : " and (mmo.STATUS = {5} OR mmo.DEAL_NUM > 0)";
            string sql = string.Format(strSql, model.SearchStr, model.StartTime, model.EndTime, model.Status, 
                model.ToolStatus, model.OldPartStatus);
            string countSql = "Select Count(1) from (" + sql + ") as temp";

            PageModel<MaintainShowModel> pageModel = new PageModel<MaintainShowModel>();
            pageModel.TotalCount = await Repository.CountAsync(countSql);
            pageModel.Items = await Repository.GetPageAsync<MaintainShowModel>(model.PageIndex, model.PageSize, sql, " order by mm.OCD Desc");
            return pageModel;
        }

        public async Task<MaintainShowModel> SelectMaintainAllInfoById(string id)
        {
            string sql = @"select mm.ID Id, mm.MAINTAIN_NO MaintainNo, mm.STAFF Staff,
                    mm.APPOINTMENT_ID AppointmentId, mm.START_DATE StartDate,
                    mm.STATUS Status, mm.RETURN_DATE ReturnDate, mm.OPERATOR Operator,
                    mm.OCU, mm.OCD, mm.LUC, mm.LUD, cc.COMPANY CompanyName, ma.TYPE Type,
                    ma.CONTACT Contact, ma.PHONE Phone, ma.CAR_LICENSE CarLicense
                    from MMS_MAINTAIN mm
                    left join MMS_APPOINTMENT ma on mm.APPOINTMENT_ID = ma.ID
                    left join CMS_CLIENT cc on cc.ID = ma.COMPANY_ID 
                    where mm.ID = @id";
            return await Repository.GetFirstAsync<MaintainShowModel>(sql, new { id });
        }

        public async Task<MaintainEntryShowModel> SelectMaintainInfoById(string id)
        {
            string sql = @"select mm.MAINTAIN_NO MaintainNo, mm.START_DATE StartDate,
                    mm.RETURN_DATE ReturnDate, cc.COMPANY CompanyName, ma.TYPE Type,
                    ma.CONTACT Contact, ma.PHONE Phone, ma.CAR_LICENSE CarLicense
                    from MMS_MAINTAIN mm
                    left join MMS_APPOINTMENT ma on mm.APPOINTMENT_ID = ma.ID
                    left join CMS_CLIENT cc on cc.ID = ma.COMPANY_ID 
                    where mm.ID = @id";
            return (await Repository.GetGroupAsync<MaintainEntryShowModel>(sql, new { id })).First();
        }

        public async Task<bool> UpdateMaintainNoRelation(MaintainModel model, IDbTransaction transaction = null)
        {
            string sql = @"update MMS_MAINTAIN 
                        set STAFF = @Staff, 
                            START_DATE = @StartDate,
                            STATUS = @Status, 
                            RETURN_DATE = @ReturnDate, 
                            OPERATOR = @Operator,
                            LUD = CURRENT_TIMESTAMP
                        where ID = Id";
            return await Repository.ExecuteAsync(sql, model, transaction) > 0 ? true : false;
        }

        public async Task<bool> UpdateOldPart(MaintainOldPartUpdateModel model, IDbTransaction transaction = null)
        {
            string sql = @"update MMS_MAINTAIN_OLDPART
                        set MAINTAIN_ID = @MaintainId, 
                            SKU_ID = @SkuId,
                            NUM = @Num, 
                            PRICE = @Price, 
                            STATUS = @Status,
                            REMARK = @Remark
                        where ID = Id";
            return await Repository.ExecuteAsync(sql, model, transaction) > 0 ? true : false;
        }

        public async Task<bool> UpdateTool(MaintainToolUpdateModel model, IDbTransaction transaction = null)
        {
            string sql = @"update MMS_MAINTAIN_TOOL
                        set MAINTAIN_ID = @MaintainId, 
                            OUT_SKU_ID = @OutSkuId,
                            DEAL_NUM = @DealNum,  
                            STATUS = @Status,
                            REMARK = @Remark,
                            COMPENSATION = @Compensation
                        where ID = Id";
            return await Repository.ExecuteAsync(sql, model, transaction) > 0 ? true : false;
        }
    }
}
