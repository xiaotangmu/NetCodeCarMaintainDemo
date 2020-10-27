using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Maintain
{
    public class MaintainOldPartModel : MaintainOldPartAddModel
    {
        public string Id { get;set; }
    }
    public class MaintainOldPartAddModel
    {
        public string MaintainId { get; set; }
        public string SkuId { get; set; }
        public int Num { get; set; }
        /// <summary>
        /// 入库单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 是否已经入库，0没有，1已经入库
        /// </summary>
        public int Status { get; set; }
        public string Remark { get; set; }
    }
}
