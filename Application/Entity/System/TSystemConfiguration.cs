using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateModel.System
{
	[Serializable]
	public class T_SYSTEM_CONFIGURATION : BaseEntity
    {
		public static readonly string FIELD_CONFIG_CODE = "config_code";
		/// <summary>
		/// </summary>
		public string CONFIG_CODE { get; set; }

		public static readonly string FIELD_CONFIG_VALUE = "config_value";
		/// <summary>
		/// </summary>
		public string CONFIG_VALUE { get; set; }
	}
}
