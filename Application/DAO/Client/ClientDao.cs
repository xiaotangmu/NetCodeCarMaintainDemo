using DapperExtensions;
using DateModel;
using DateModel.Client;
using Interface.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Client;

namespace DAO.Client
{
    public class ClientDao : BaseDAO, IClientRepository
    {
        public ClientDao() : base() { }

        public async Task<string> AddAsync(CMS_CLIENT application, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync(application, transaction);
        }

        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }

        public Task<bool> DeleteAsync(string addressCode, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditAsync(CMS_CLIENT application, IDbTransaction transaction = null)
        {
            return await Repository.UpdateAsync(application, transaction);
        }

        public async Task<bool> EditAsync(Dictionary<string, object> setting, Dictionary<string, object> where, IDbTransaction transaction = null)
        {
            return await Repository.UpdateAsync<CMS_CLIENT>(setting, where, transaction);
        }

        public async Task<ClientListWithPagingViewModel> GetClientGroupWithPaging(ClientListSearchViewModel searchModel)
        {
            string sql = @"SELECT newStudent.PRE_ROOM_INDEX as RoomIndex,room.ROOM_TYPE as RoomType,room.ROOM_STATE as RoomState,newStudent.PRE_BED as Bed,bed.BED_STATE as BedState,
                                student.MOBILE_NO as ContactMobile,
                                student.FULL_NAME as FullName,student.CHINESE_NAME as ChineseName,
                                student.STUDENT_CODE as StudentCode,student.APPLICATION_CODE as ApplicationCode,student.SPECIAL_TYPE as StudentSpecialType,
								newStudent.GENDER as Gender,newStudent.SPECIAL_REQUIREMENT as OtherRequirement,newStudent.ROOM_TYPE as RoomTypeRequirement,
								newStudent.ROOMMATE_TYPE as RoomMateRequirement,newStudent.FIRST_NAME as FirstName,newStudent.LAST_NAME as LastName,
                                newStudent.NATION_CODE as NationCode,newStudent.MOBILE as Mobile,newStudent.EMAIL as Email,newStudent.ORIGINAL_SCHOOL as OriginalSchool,
                                newStudent.ARRIVAL_DATE as ArrivalDate,newStudent.ARRIVAL_DATE as ArrivalDate,newStudent.MEET_ADDRESS as MeetAddress,newStudent.MEET_SERVICE as MeetService,
                                newStudent.PLAN_ARRIVAL_TIME as PlanArrivalTime,newStudent.ROOMMATE_TYPE as SelectedRoomMateType,newStudent.ROOM_TYPE as SelectedRoomType,newStudent.DEPARTURE_PORT as DeparturePort,
                                newStudent.DEPARTURE_DATE as DepartureDate,newStudent.DEPARTURE_TIME as DepartureTime,newStudent.FLIGHT_NUMBER as FlightNumber,
                                newStudent.update_time as ApplyTime
                                    FROM
								(SELECT * FROM t_new_student_application WHERE IS_OVER='0' {0}) as newStudent
									JOIN
								(SELECT HOSTEL_ROOM,HOSTEL_BED,FULL_NAME,CHINESE_NAME,GENDER,STUDENT_CODE,APPLICATION_CODE,MOBILE_NO,SPECIAL_TYPE FROM T_STUDENT WHERE 1=1 ) as student
									ON newStudent.APPLICATION_CODE=student.APPLICATION_CODE
                                    LEFT JOIN 
                                (SELECT ROOM_INDEX,ROOM_TYPE,ROOM_STATE FROM T_ROOM WHERE IS_USE='1') as room
                                    ON room.ROOM_INDEX = newStudent.PRE_ROOM_INDEX
								    LEFT JOIN
								(SELECT BED_CODE,BED_STATE,ROOM_INDEX FROM T_BED WHERE IS_USE='1') as bed
								    ON newStudent.PRE_ROOM_INDEX=bed.ROOM_INDEX AND newStudent.PRE_BED=bed.BED_CODE";
            string studentWhere = BuildStudentWhere(searchModel);
            return await Repository.GetPageAsync<ClientViewModel>(searchModel.PageIndex, searchModel.PageSize, string.Format(sql, studentWhere), " ORDER BY ApplyTime");

        }

        public async Task<int> GetCountAsync(ClientListSearchViewModel searchModel)
        {
            string sql = @"SELECT COUNT(*)
                                    FROM CMS_CLIENT";
            string studentWhere = BuildStudentWhere(searchModel);
            return await Repository.CountAsync(string.Format(sql, studentWhere));
        }

        private string BuildStudentWhere(ClientListSearchViewModel searchModel)
        {
            StringBuilder studentWhere = new StringBuilder();
            //if (!string.IsNullOrEmpty(searchModel.Name))
            //{
            //    studentWhere.AppendFormat(" AND full_name like '%{0}%'", searchModel.Name);
            //    studentWhere.AppendFormat(" OR chinese_name like '%{0}%'", searchModel.Name);
            //}
            //if (!string.IsNullOrEmpty(searchModel.ApplicationCode))
            //{
            //    studentWhere.AppendFormat(" AND application_code like '%{0}%'", searchModel.ApplicationCode);
            //}
            //if (!string.IsNullOrEmpty(searchModel.RoomIndex))
            //{
            //    studentWhere.AppendFormat(" AND pre_room_index like '%{0}%'", searchModel.RoomIndex);
            //}
            //if (!string.IsNullOrEmpty(searchModel.ContactMobile))
            //{
            //    studentWhere.AppendFormat(" AND mobile like '%{0}%'", searchModel.ContactMobile);
            //}
            return studentWhere.ToString();
        }

        public async Task<IEnumerable<CMS_CLIENT>> GetGroupAsync()
        {
            return await Repository.GetListAsync<CMS_CLIENT>();
        }

        public async Task<bool> IsExist(CMS_CLIENT application)
        {
            var predicateApplicationCode = Predicates.Field<CMS_CLIENT>(exp => exp.COMPANY, Operator.Eq, application.COMPANY);
            return await Repository.CountAsync<CMS_CLIENT>(predicateApplicationCode) > 0 ? true : false;
        }
    }
}
