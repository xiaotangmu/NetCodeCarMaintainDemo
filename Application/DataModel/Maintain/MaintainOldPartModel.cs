using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using ViewModel.Sku;

namespace ViewModel.Maintain
{
    public class MaintainOldPartModel : MaintainOldPartUpdateModel
    {
        #region 用于返回方便看配件信息
        public string SkuName { get; set; }
        public string Brand { get; set; }
        public string Unit { get; set; }
        public IEnumerable<SkuAttrModel> AttrList { get; set; } = new List<SkuAttrModel>();
        #endregion
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
        public int DealNum { get; set; }
    }
    public class MaintainOldPartUpdateModel : MaintainOldPartAddModel
    {
        public string Id { get; set; }
    }
}
