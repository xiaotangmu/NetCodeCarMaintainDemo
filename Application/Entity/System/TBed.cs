
using System;
using System.Threading.Tasks;
using Entity;
using Localization;

namespace Domain.DataModel
{
   [Serializable]
    public class T_BED : BaseEntity
    {
		public static readonly string FIELD_BED_CODE = "bed_code";
		/// <summary>
		/// </summary>
		public string BED_CODE { get; set; }

		public static readonly string FIELD_BED_STATE = "bed_state";
		/// <summary>
		/// </summary>
		public string BED_STATE { get; set; }

		public static readonly string FIELD_ROOM_INDEX = "room_index";
		/// <summary>
		/// </summary>
		public string ROOM_INDEX { get; set; }

		public static readonly string FIELD_IS_USE = "is_use";
		/// <summary>
		/// </summary>
		public string IS_USE { get; set; }
    }
}
	    
