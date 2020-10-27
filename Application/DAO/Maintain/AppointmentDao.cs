using DateModel.Maintain;
using Interface.Maintain;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.Maintain;

namespace DAO.Maintain
{
    public class AppointmentDao : BaseDAO, IAppointmentRepository
    {
        public AppointmentDao() { }
        public AppointmentDao(IDataRepository repository) : base(repository) { }

        public async Task<bool> Delete(string id, IDbTransaction transaction = null)
        {
            string sql = "delete from MMS_APPOINTMENT where ID = @Id";
            return await Repository.ExecuteAsync(sql, new { Id = id }, transaction) > 0 ? true : false;
        }

        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }

        public async Task<int> GetCountByCompanyAndDate(string companyId, DateTime appointmentDate)
        {
            string sql = @"select Count(1) from MMS_APPOINTMENT
                    where COMPANY_ID = '{0}' And APPOINTMENT_DATE = '{1}'";
            //return await Repository.CountAsync(sql, new { companyId, appointmentDate });    // 直接用@ 传参失败
            sql = string.Format(sql, companyId, appointmentDate);
            return await Repository.CountAsync(sql);
        }

        public async Task<string> Insert(MMS_APPOINTMENT mMS_APPOINTMENT)
        {
            return await Repository.InsertAsync<MMS_APPOINTMENT>(mMS_APPOINTMENT);
        }

        public async Task<IEnumerable<AppointmentModel>> SelectAll()
        {
            string sql = @"select ma.ID Id, ma.APPOINTMENT_NO AppointmentNo, ma.COMPANY_ID CompanyId,
                ma.CAR_LICENSE CarLicense, ma.DESCRIPTION Description, ma.APPOINTMENT_DATE AppointmentDate,
                ma.TYPE Type, ma.PHONE Phone, ma.CONTACT Contact, ma.STATUS Status, ma.REMARK Remark,
                ma.OCD, ma.OCU, ma.LUC, ma.LUD, cc.COMPANY CompanyName
                from MMS_APPOINTMENT ma
				LEFT JOIN CMS_CLIENT cc on cc.ID = ma.COMPANY_ID
                where 1 = 1";
            return await Repository.GetGroupAsync<AppointmentModel>(sql);
        }

        public async Task<PageModel<AppointmentModel>> SelectListPageBySearch(AppointmentPageSearchModel model)
        {
            string strSql = @"select ma.ID Id, ma.APPOINTMENT_NO AppointmentNo, ma.COMPANY_ID CompanyId,
                ma.CAR_LICENSE CarLicense, ma.DESCRIPTION Description, ma.APPOINTMENT_DATE AppointmentDate,
                ma.TYPE Type, ma.PHONE Phone, ma.CONTACT Contact, ma.STATUS Status, ma.REMARK Remark,
                ma.OCD, ma.OCU, ma.LUC, ma.LUD, cc.COMPANY CompanyName
                from MMS_APPOINTMENT ma
				LEFT JOIN CMS_CLIENT cc on cc.ID = ma.COMPANY_ID
                where ";
            // 预约时间范围，联系人，联系电话，车牌号，公司名, 描述
            strSql += (string.IsNullOrWhiteSpace(model.SearchStr)) ? " 1 = 1 " : " (ma.CONTACT like '%' + '{0}' + '%' " +
                "Or ma.PHONE like '%' + '{0}' + '%' OR ma.CAR_LICENSE like '%' + '{0}' + '%' " +
                " Or cc.COMPANY like '%' + '{0}' + '%' OR ma.DESCRIPTION like '%' + '{0}' + '%') ";    // 还可查供应商 待定 
            strSql += model?.StartTime.Year > 1900 ? " and ma.APPOINTMENT_DATE >= '{1}' " : "";
            strSql += model?.EndTime.Year > 1900 ? " and '{2}' >= ma.APPOINTMENT_DATE " : "";
            // 处理查询，0未处理，1已处理，2取消, -1 不开启处理查询 -- Status
            strSql += model?.Status == -1 ? "" : " and ma.Status = '{3}' ";
            string sql = string.Format(strSql, model.SearchStr, model.StartTime, model.EndTime, model.Status);
            string countSql = "Select Count(1) from (" + sql + ") as temp";

            PageModel<AppointmentModel> pageModel = new PageModel<AppointmentModel>();
            pageModel.TotalCount = await Repository.CountAsync(countSql);
            pageModel.Items = await Repository.GetPageAsync<AppointmentModel>(model.PageIndex, model.PageSize, sql, " order by ma.OCD Desc");
            return pageModel;            
        }

        public async Task<bool> Update(AppointmentModel model, IDbTransaction transaction = null)
        {
            string sql = @"Update MMS_APPOINTMENT 
                set COMPANY_ID = @CompanyId, 
                    CAR_LICENSE = @CarLicense,
                    DESCRIPTION = @Description,
                    APPOINTMENT_DATE = @AppointmentDate,
                    TYPE = @Type,
                    PHONE = @Phone,
					CONTACT = @Contact,
					STATUS = @Status,
					REMARK = @Remark,
                    LUD = CURRENT_TIMESTAMP
                where ID = @Id";
            return await Repository.ExecuteAsync(sql, model, transaction) > 0 ? true : false;
        }
    }
}
