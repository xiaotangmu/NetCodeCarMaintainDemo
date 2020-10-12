
using System;
using System.Threading.Tasks;
using Entity;
using Localization;

namespace Domain.DataModel
{
    [Serializable]
    public class T_FLOOR : BaseEntity
    {

        public static readonly string FIELD_FLOOR_CODE = "floor_code";
        /// <summary>
        /// </summary>
        public string FLOOR_CODE { get; set; }

        public static readonly string FIELD_FLOOR_DISPLAY = "floor_display";
        /// <summary>
        /// </summary>
        public string FLOOR_DISPLAY { get; set; }

        public static readonly string FIELD_SORT = "sort";
        /// <summary>
        /// </summary>
        public string SORT { get; set; }
    }
}

