using System;
using System.Collections.Generic;
using System.Text;

namespace DateModel.Sku
{
    public class SMS_ENTRY_SKU
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
        public SMS_ENTRY_SKU()
        {
            _id = Guid.NewGuid().ToString().Replace("-", "");
        }

        public static readonly string FIELD_ENTRY_ID = "entry_id";
        public string ENTRY_ID { get; set; }
        public static readonly string FIELD_SKU_ID = "sku_id";
        public string SKU_ID { get; set; }
        public static readonly string FIELD_QUANTITY = "quantity";
        public int QUANTITY { get; set; }
        public static readonly string FIELD_PRICE = "price";
        public decimal PRICE { get; set; }
        public static readonly string FIELD_TOTAL_PRICE = "total_price";
        public decimal TOTAL_PRICE { get; set; }
        public static readonly string FIELD_STATUS = "status";
        public int STATUS { get; set; }
        public static readonly string FIELD_OLD_PARTID = "old_partid";
        public string OLD_PARTID { get; set; }
        public static readonly string FIELD_ADDRESS_ID = "address_id";
        public string ADDRESS_ID { get; set; }
    }
}
