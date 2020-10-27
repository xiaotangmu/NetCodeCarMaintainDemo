using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Maintain
{
    public class AppointmentModel : AppointmentAddModel
    {
        public string Id { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public string OCU { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime OCD { get; set; }
        /// <summary>
        /// 最后更新用户
        /// </summary>
        public string LUC { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LUD { get; set; }

        /// <summary>
        /// 公司名
        /// </summary>
        public string CompanyName { get; set; }
    }
    public class AppointmentAddModel
    {
        public string AppointmentNo { get; set; }
        public string CompanyId { get; set; }
        public string CarLicense { get; set; }
        public string Description { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Type { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }
        // 是否取消，0未处理，1已处理，2取消
        public int Status { get; set; }
        public string Remark { get; set; }
    }
    public class AppointmentDeleteModel
    {
        public string Id { get; set; }
        public string AppointmentNo { get; set; }
    }
    public class AppointmentPageSearchModel : BaseSearchModel
    {
        /// <summary>
        /// 可以搜索：预约单号，公司名，车牌号，联系人，联系电话，描述 
        /// </summary>
        public string SearchStr { get; set; }
        // 是否取消，0未处理，1已处理，2取消, -1 不开启处理查询 -- Status
        public int Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
