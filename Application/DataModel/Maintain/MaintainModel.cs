using DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Sku;

namespace ViewModel.Maintain
{
    public class MaintainShowModel: MaintainModel
    {
        public string CompanyName { get; set; }
        public string Type { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
    }
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

        /// <summary>
        /// 维修车主要购买的配件
        /// </summary>
        public IEnumerable<SkuModel> SkuList { get; set; } = new List<SkuModel>();
    }
    public class MaintainAddModel
    {
        public string MaintainNo { get; set; }
        public string Staff { get; set; }
        public string AppointmentId { get; set; }
        public DateTime StartDate { get; set; }
        /// <summary>
        ///  是否已经签字完成，0没有，1处理完，2维修取消
        /// </summary>
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
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 维修单是否已经签字或者取消，0没有，1 签了，-1 不用理会
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 是否存在未处理的ToolStatus, 0 没全部处理完，1全部处理完，-1 不用理会
        /// </summary>
        public int ToolStatus { get; set; }
        /// <summary>
        /// 是否存在未处理的OldPartStatus, 0 没全部处理完，1全部处理完，-1 不用理会
        /// </summary>
        public int OldPartStatus { get; set; }
    }
    public class MaintainDeleteModel
    {
        public string Id { get; set; }
        public string MaintainNo { get; set; }
    }
    
}
