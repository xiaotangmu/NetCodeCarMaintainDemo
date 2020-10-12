using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Common.Office
{
    public static class TypeConverter
    {
        public static object Convert(this object value, Type targetType)
        {
            if (value.IsNull())
            {
                return null;
            }
            if (targetType.IsNullableType())
            {
                targetType = targetType.GetUnderlyingType();
            }
            if (targetType.IsEnum)
            {
                return Enum.Parse(targetType, value.ToString());
            }
            if (targetType == typeof(Guid))
            {
                return Guid.Parse(value.ToString());
            }
            try
            {
                value = System.Convert.ChangeType(value, targetType);
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            return value;
        }

        public static T Convert<T>(this object value)
        {
            object result = Convert(value, typeof(T));
            return (T)result;
        }

        public static object GetCellValue(ICell cell)
        {
            object returnValue = "";
            switch (cell.CellType)
            {
                case CellType.Blank:
                    returnValue = "";
                    break;
                case CellType.Numeric:
                    short format = cell.CellStyle.DataFormat;
                    //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理***
                    if (format == 14 || format == 31 || format == 57 || format == 58 || format == 20)
                    {
                        returnValue = cell.DateCellValue.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        returnValue = cell.NumericCellValue;
                    }
                    break;
                case CellType.String:
                    returnValue = cell.StringCellValue;
                    break;
            }
            return returnValue;
        }

        public static void SetCellValue(this ICell cell, object value)
        {
            if (value == null)
            {
                return;
            }
            cell.SetCellValue(value.Convert(value.GetType()));
        }

        public static void SetCellType(this ICell cell, Type type)
        {
            if (Equals(type, typeof(Boolean)))
            {
                cell.SetCellType(CellType.Boolean);
            }
            else if (Equals(type, typeof(int))
                || Equals(type, typeof(float))
                || Equals(type, typeof(double))
                || Equals(type, typeof(DateTime)))
            {
                cell.SetCellType(CellType.Numeric);
            }
            else if (Equals(type, typeof(String)))
            {
                cell.SetCellType(CellType.String);
            }
        }

        private static bool IsNull(this object value)
        {
            return null == value;
        }

        private static bool IsNullableType(this Type type)
        {
            return ((type != null) && type.IsGenericType) && (type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        private static Type GetUnderlyingType(this Type type)
        {
            if (IsNullableType(type))
            {
                var nullableConverter = new NullableConverter(type);
                return nullableConverter.UnderlyingType;
            }
            return type;
        }
    }
}