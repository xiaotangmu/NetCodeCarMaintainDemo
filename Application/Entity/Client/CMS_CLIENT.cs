
using Entity;
using System;

namespace DateModel.Client
{
    /// <summary>
    /// 客户模块下的客户表
    /// </summary>
    [Serializable]
    public class CMS_CLIENT : BaseEntity
    {
        public static readonly string FIELD_COMPANY = "company";
        /// <summary>
        /// </summary>
        public string COMPANY { get; set; }

        public static readonly string FIELD_ADDRESS = "address";

        public string ADDRESS { get; set; }


        public static readonly string FIELD_PHONE = "phone";
        /// <summary>
        /// </summary>
        public string PHONE { get; set; }

        public static readonly string FIELD_CONTACT = "contact";
        /// <summary>
        /// </summary>
        public string CONTACT { get; set; }

        public static readonly string FIELD_EMAIL = "email";

        public string EMAIL { get; set; }

        public static readonly string FIELD_TYPE = "type";

        public string TYPE { get; set; }

        public static readonly string FIELD_DESCRIPTION = "description";

        public string DESCRIPTION { get; set; }

    }

}
