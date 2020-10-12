using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Office
{
    public class FillRegion : CellRangeAddress
    {
        public int RowsCount
        {
            get;set;
        }

        public int ColumnsCount
        {
            get;set;
        }


        public FillRegion(int firstRow, int lastRow, int firstColumn, int lastColumn) : base(firstRow, lastRow, firstColumn, lastColumn)
        {
        }
    }
}