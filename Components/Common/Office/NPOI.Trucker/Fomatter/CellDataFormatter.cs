using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Office.Fomatter
{
    public class CellDataFormatter
    {
        public static ICellStyle CreateCellStyle(IWorkbook workbook, string dataFormat)
        {
            if (workbook == null)
            {
                throw new ArgumentNullException(nameof(workbook));
            }
            if (string.IsNullOrWhiteSpace(dataFormat))
            {
                throw new ArgumentException($"Parameter '{nameof(dataFormat)}' cannot be null or white string.");
            }

            var style = workbook.CreateCellStyle();
            style.DataFormat = workbook.CreateDataFormat().GetFormat(dataFormat);

            return style;
        }

        public static ICellStyle CreateCellStyle(IWorkbook workbook, short dataFormat)
        {
            if (workbook == null) throw new ArgumentNullException(nameof(workbook));
            if (dataFormat == 0) return null;

            var style = workbook.CreateCellStyle();
            style.DataFormat = dataFormat;

            return style;
        }

    }
}