
using System;
using System.Threading.Tasks;
using Entity;
using Localization;

namespace Domain.DataModel
{
	[Serializable]
	public class T_ROOM : BaseEntity
	{

		public static readonly string FIELD_ROOM_INDEX = "room_index";
		/// <summary>
		/// </summary>
		public string ROOM_INDEX { get; set; }

		public static readonly string FIELD_ROOM_TYPE = "room_type";
		/// <summary>
		/// </summary>
		public string ROOM_TYPE { get; set; }

		public static readonly string FIELD_ROOM_STATE = "room_state";
		/// <summary>
		/// </summary>
		public string ROOM_STATE { get; set; }

		public static readonly string FIELD_FLOOR_CODE = "floor_code";
		/// <summary>
		/// </summary>
		public string FLOOR_CODE { get; set; }

		public static readonly string FIELD_IS_USE = "is_use";
		/// <summary>
		/// </summary>
		public string IS_USE { get; set; }
	}
}
	    
