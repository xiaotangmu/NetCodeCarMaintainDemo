using System;
using System.Collections.Generic;
using System.Text;
using Library.Utilities;

namespace BLL
{
    public class DateTimeConverter
    {
        private const string DEFAULT_FORMAT = "yyyy-MM-dd HH:mm:ss";

        public static string ConvertToString(DateTime? dateTime, string format = null)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(format))
            {
                format = DEFAULT_FORMAT;
            }
            if (dateTime == null)
            {
                return result;
            }
            return Convert.ToDateTime(dateTime).ToString(format);
        }

        public static DateTime? ConvertToDateTime(string dateTime)
        {
            if (string.IsNullOrEmpty(dateTime))
            {
                return null;
            }
            return Convert.ToDateTime(dateTime);
        }
    }
}
