using System;
using System.Collections.Generic;
using System.Text;

namespace DateModel.Maintain
{
    public class MMS_MAINTAIN_OLDPART
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
        public MMS_MAINTAIN_OLDPART()
        {
            _id = Guid.NewGuid().ToString().Replace("-", "");
        }
        public static readonly string FIELD_MAINTAIN_ID = "maintain_id";
        public string MAINTAIN_ID { get; set; }
        public static readonly string FIELD_SKU_ID = "sku_id";
        public string SKU_ID { get; set; }
        public static readonly string FIELD_NUM = "num";
        public int NUM { get; set; }
        /// <summary>
        /// 入库单价
        /// </summary>
        public static readonly string FIELD_PRICE = "price";
        public string PRICE { get; set; }
        public static readonly string FIELD_STATUS = "status";
        public int STATUS { get; set; }
        public static readonly string FIELD_REMARK = "remark";
        public string REMARK { get; set; }
    }
}
