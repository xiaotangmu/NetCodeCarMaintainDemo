using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Maintain
{
    public class MaintainToolModel : MaintainToolAddModel
    {
        public string Id { get; set; }
    }
    public class MaintainToolAddModel
    {
        public string MaintainId { get; set; }
        public string Remark { get; set; }
        public string OutSkuId { get; set; }
        /// <summary>
        /// 归还数量
        /// </summary>
        public int ReturnNum { get; set; }
        /// <summary>
        /// 状态，0没有解决/归还，1解决
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 赔偿金
        /// </summary>
        public decimal Compensation { get; set; }
    }
}
