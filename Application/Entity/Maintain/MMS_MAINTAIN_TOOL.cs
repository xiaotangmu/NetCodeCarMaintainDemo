using System;
using System.Collections.Generic;
using System.Text;

namespace DateModel.Maintain
{
    public class MMS_MAINTAIN_TOOL
    {
        /// <summary>
        /// 表ID
        /// </summary>
        private string _id;

        /// <summary>
        /// 表ID
        /// </summary>
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public MMS_MAINTAIN_TOOL()
        {
            _id = Guid.NewGuid().ToString().Replace("-", "");
        }
        public static readonly string FIELD_MAINTAIN_ID = "maintain_id";
        public string MAINTAIN_ID { get; set; }
        public static readonly string FIELD_OUT_SKU_ID = "out_sku_id";
        public string OUT_SKU_ID { get; set; }
        public static readonly string FIELD_DEAL_NUM = "deal_num";
        public int DEAL_NUM { get; set; }
        public static readonly string FIELD_NUM = "deal_num";
        public int NUM { get; set; }
        /// <summary>
        /// 状态，0没有解决，1已经解决
        /// </summary>
        public static readonly string FIELD_STATUS = "status";
        public int STATUS { get; set; }
        public static readonly string FIELD_REMARK = "remark";
        public string REMARK { get; set; }
        /// <summary>
        /// 赔偿金
        /// </summary>
        public static readonly string FIELD_COMPENSATION = "compensation";
        public decimal COMPENSATION { get; set; }
    }
}
