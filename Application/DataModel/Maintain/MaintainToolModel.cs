using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Sku;

namespace ViewModel.Maintain
{
    public class MaintainToolModel : MaintainToolUpdateModel
    {
        #region 用于返回方便看工具信息
        public string SkuName { get; set; }
        public string Brand { get; set; }
        public string Unit { get; set; }
        public IEnumerable<SkuAttrModel> AttrList { get; set; } = new List<SkuAttrModel>();
        #endregion
    }
    public class MaintainToolAddModel
    {
        public string MaintainId { get; set; }
        public string Remark { get; set; }
        public string OutSkuId { get; set; }
        public int Num { get; set; }
        /// <summary>
        /// 归还数量
        /// </summary>
        public int DealNum { get; set; }
        /// <summary>
        /// 状态，0没有解决/归还，1解决
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 赔偿金
        /// </summary>
        public decimal Compensation { get; set; }
    }
    public class MaintainToolUpdateModel : MaintainToolAddModel
    {
        public string Id { get; set; }
    }
}
