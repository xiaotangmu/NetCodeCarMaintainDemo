using NPOI.HSSF.UserModel;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Office
{
    public class ExcelWorkbookFactory
    {
        public static ExcelWorkbookFactory Singleton
        {
            get
            {
                return new ExcelWorkbookFactory();
            }
        }

        public IWorkbook Create(ExcelType type)
        {
            IWorkbook workbook = null;

            if (type == ExcelType.Excel2003)
            {
                workbook = CreateExcel2003();
            }
            else if (type == ExcelType.Excel2010)
            {
                workbook = CreateExcel2010();
            }

            if(workbook !=null)
            {
                workbook.CreateSheet();
            }

            return workbook;
        }

        private IWorkbook CreateExcel2003()
        {
            return new HSSFWorkbook();
        }

        private IWorkbook CreateExcel2010()
        {
            return new XSSFWorkbook();
        }
    }

    public enum ExcelType
    {
        Excel2003, Excel2010
    }
}