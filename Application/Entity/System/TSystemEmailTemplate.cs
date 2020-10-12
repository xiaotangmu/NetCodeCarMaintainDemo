using Entity;
using System;

namespace DateModel.System
{
	[Serializable]
	public class T_EMAIL_TEMPLATE : BaseEntity
	{
		public static readonly string FIELD_CODE = "code";
		/// <summary>
		/// </summary>
		public string CODE { get; set; }

		public static readonly string FIELD_NAME = "name";
		/// <summary>
		/// </summary>
		public string NAME { get; set; }

		public static readonly string FIELD_TO_NAME = "to_name";
		/// <summary>
		/// </summary>
		public string TO_NAME { get; set; }

		public static readonly string FIELD_CC_NAME = "cc_name";
		/// <summary>
		/// </summary>
		public string CC_NAME { get; set; }

		public static readonly string FIELD_BCC_NAME = "bcc_name";
		/// <summary>
		/// </summary>
		public string BCC_NAME { get; set; }

		public static readonly string FIELD_SUBJECT = "subject";
		/// <summary>
		/// </summary>
		public string SUBJECT { get; set; }

		public static readonly string FIELD_CONTENT = "content";
		/// <summary>
		/// </summary>
		public string CONTENT { get; set; }

	}
}
