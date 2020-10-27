using DAO.Maintain;
using DateModel.Maintain;
using Interface.Maintain;
using Supervisor.Maintain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.Maintain;

namespace BLL.Maintain
{
    public class AppointmentSupervisor: BaseBLL, IAppointmentSupervisor
    {
        private IAppointmentRepository _aDao;
        public AppointmentSupervisor(IAppointmentRepository aDao = null)
        {
            _aDao = InitDAO<AppointmentDao>(aDao) as IAppointmentRepository;
        }

        public async Task<string> Add(AppointmentAddModel model)
        {
            string CompanyId = model.CompanyId.PadLeft(3, '0'); // 不足补0至三位
            // 生成预约编号： 预约年月日+公司编号(最多后三位)+ 车牌后两位 + 当天该公司的维修次序（三位）
            model.AppointmentNo = string.Format("{0:yyyyMMdd}", model.AppointmentDate) + CompanyId.Substring((CompanyId.Length - 3), 3) + 
                model.CarLicense.Substring(model.CarLicense.Length - 2, 2);
            // 获取当天该公司的预约次数 + 1 = 该次次数
            int num = (await _aDao.GetCountByCompanyAndDate(model.CompanyId, model.AppointmentDate)) + 1;
            model.AppointmentNo += Convert.ToString(num).PadLeft(3, '0');
            // 是否存在 -- 不做处理 -- 可能存在同一天修两次？？

            // 添加
            return await _aDao.Insert(ModelToEntityNoId(model));
        }

        public async Task<bool> Delete(string id)
        {
            return await _aDao.Delete(id);
        }

        public async Task<bool> DeleteBatch(IEnumerable<AppointmentDeleteModel> modelList)
        {
            return await _aDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                foreach (var item in modelList)
                {
                    await _aDao.Delete(item.Id, transaction);
                }
                return true;
            });
        }

        public async Task<IEnumerable<AppointmentModel>> GetAll()
        {
            return await _aDao.SelectAll();
        }

        public async Task<PageModel<AppointmentModel>> GetListPageBySearch(AppointmentPageSearchModel model)
        {
            return await _aDao.SelectListPageBySearch(model);
        }

        public async Task<bool> Update(AppointmentModel model)
        {
            return await _aDao.Update(model);
        }

        public MMS_APPOINTMENT ModelToEntityNoId(AppointmentAddModel model = null)
        {
            return new MMS_APPOINTMENT
            {
                APPOINTMENT_NO = model?.AppointmentNo,
                COMPANY_ID = model?.CompanyId,
                CAR_LICENSE = model?.CarLicense,
                DESCRIPTION = model?.Description,
                APPOINTMENT_DATE = (DateTime)model?.AppointmentDate,
                TYPE = model?.Type,
                PHONE = model?.Phone,
                CONTACT = model?.Contact,
                STATUS = (int)model?.Status,
                REMARK = model?.Remark
            };
        }
        public MMS_APPOINTMENT ModelToEntity(AppointmentModel model)
        {
            MMS_APPOINTMENT entity = ModelToEntityNoId(model);
            entity.ID = model.Id;
            return entity;
        }
    }
}
