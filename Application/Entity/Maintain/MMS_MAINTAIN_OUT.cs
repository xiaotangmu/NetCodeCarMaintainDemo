using System;
using System.Collections.Generic;
using System.Text;

namespace DateModel.Maintain
{
    public class MMS_MAINTAIN_OUT
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
        public MMS_MAINTAIN_OUT()
        {
            _id = Guid.NewGuid().ToString().Replace("-", "");
        }
        public static readonly string FIELD_MAINTAIN_ID = "maintain_id";
        public string MAINTAIN_ID { get; set; }
        public static readonly string FIELD_OUT_ID = "out_id";
        public string OUT_ID { get; set; }
    }
}
