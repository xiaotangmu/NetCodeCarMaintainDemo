using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Maintain
{
    public class MaintainModel: MaintainAddModel
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
    }
    public class MaintainAddModel
    {
        public string MaintainNo { get; set; }
        public string Staff { get; set; }
        public string AppointmentId { get; set; }
        public DateTime StartDate { get; set; }
        public int Status { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Operator { get; set; }

        public IEnumerable<MaintainToolModel> ToolList { get; set; } = new List<MaintainToolModel>();
        public IEnumerable<MaintainOldPartModel> OldPartList { get; set; } = new List<MaintainOldPartModel>();
        /// <summary>
        /// 关联多个出库单
        /// </summary>
        public IEnumerable<string> OutIdList { get; set; } = new List<string>();
    }
    public class MaintainPageSearchModel: BaseSearchModel
    {
        public string SearchStr { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public int Status { get; set; }
    }
}
