using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Common.Office.Exception;

namespace Common.Office
{
    public class ExportHelper
    {
        public IWorkbook Workbook
        {
            get; set;
        }

        public ExportHelper(IWorkbook workbook)
        {
            Workbook = workbook;
        }

        public ExportHelper(string template) : this(File.OpenRead(template))
        {
        }

        public ExportHelper(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            using (stream)
            {
                Workbook = WorkbookFactory.Create(stream);
            }
        }

        public void Save(string targetFile, bool overwrite = false)
        {
            targetFile = AdjustExtension(targetFile, Workbook);
            if (!Directory.Exists(Path.GetDirectoryName(targetFile)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(targetFile));
            }
            try
            {
                Save(File.OpenWrite(targetFile));
            }
            catch
            {
                throw new FileLoadException();
            }

        }

        public void Save(Stream stream)
        {
            using (stream)
            {
                Workbook.Write(stream);
            }
        }

        public void Save<T>(string targetFile, IEnumerable<T> data)
        {
            if (Workbook == null)
            {
                throw new WorkbookNoFoundException();
            }

            ISheet firstSheet = GetSheet(0);
            if (firstSheet == null)
            {
                throw new SheetNotFoundException();
            }

            IRow firstRow = GetRow(firstSheet, 0);
            FillHeaderAtRow<T>(firstRow);
            FillAtRange<T>(firstSheet, data, new CellRangeAddress(1, data.Count(), 0, 6));

            Save(targetFile);
        }

        public void Save<T>(string targetFile)
        {
            Save(targetFile);
        }

        public void FillHeaderAtRow<T>(IRow row, int firstColumn = 0)
        {
            if (row == null)
            {
                throw new RowNotFoundException();
            }
            PropertyInfo[] properties = typeof(T).GetProperties();
            for (int index = 0; index < properties.Length; index++)
            {
                PropertyInfo property = properties[index];
                ICell cell = GetCell(row, index + firstColumn);

                cell.SetCellValue(property.Name);
            }
        }

        public void FillAtRange<T>(string sheetName, IEnumerable<T> data, CellRangeAddress range)
        {
            if (data == null || data.Count() == 0)
            {
                throw new InvalidDataException();
            }

            ISheet sheet = Workbook.GetSheet(sheetName);
            if (sheet == null)
            {
                throw new SheetNotFoundException();
            }
            FillSheetWithData(sheet, data, range);
        }

        public void FillAtRange<T>(int sheetIndex, IEnumerable<T> data, CellRangeAddress range)
        {
            if (data == null || data.Count() == 0)
            {
                throw new InvalidDataException();
            }

            ISheet sheet = GetSheet(sheetIndex);
            if (sheet == null)
            {
                throw new SheetNotFoundException();
            }
            FillSheetWithData(sheet, data, range);
        }

        public void FillAtRange<T>(ISheet sheet, IEnumerable<T> data, CellRangeAddress range)
        {
            if (data == null || data.Count() == 0)
            {
                throw new InvalidDataException();
            }
            if (sheet == null)
            {
                throw new SheetNotFoundException();
            }
            FillSheetWithData(sheet, data, range);
        }

        private PropertyInfo[] GetPropertyInfo<T>(T obj)
        {
            Type type = obj.GetType();
            return type.GetProperties();
        }

        private void FillSheetWithData<T>(ISheet sheet, IEnumerable<T> data, CellRangeAddress range)
        {
            for (int index = range.FirstRow; index < range.LastRow + 1; index++)
            {
                IRow row = GetRow(sheet, index);
                FillRowWithData(row, range.FirstColumn, range.LastColumn, data.ToArray()[index - range.FirstRow]);
            }
        }

        private void FillRowWithData<T>(IRow row, int firstColumn, int lastColumn, T obj)
        {
            PropertyInfo[] properties = GetPropertyInfo<T>(obj);
            for (int index = firstColumn; index < lastColumn + 1; index++)
            {
                ICell cell = GetCell(row, index);
                SetCellValue(cell, properties[index - firstColumn], obj);
            }
        }

        private void SetCellValue<T>(ICell cell, PropertyInfo property, T obj)
        {
            if (property == null || cell == null || obj == null)
            {
                return;
            }
            object value = property.GetValue(obj);
            cell.SetCellValue(value);
        }

        private IRow GetRow(ISheet sheet, int rowIndex)
        {
            IRow row = sheet.GetRow(rowIndex);
            if (row == null)
            {
                row = sheet.CreateRow(rowIndex);
            }

            return row;
        }

        private ICell GetCell(IRow row, int cellIndex)
        {
            ICell cell = row.GetCell(cellIndex);
            if (cell == null)
            {
                cell = row.CreateCell(cellIndex);
            }
            return cell;
        }

        private ISheet GetSheet(int sheetIndex)
        {
            if (Workbook == null)
            {
                throw new SheetNotFoundException();
            }
            ISheet sheet = Workbook.GetSheetAt(sheetIndex);
            if (sheet == null)
            {
                for (int index = Workbook.NumberOfSheets; index < sheetIndex + 1; index++)
                {
                    Workbook.CreateSheet();
                }
            }
            return Workbook.GetSheetAt(sheetIndex);
        }

        private string AdjustExtension(string targetFile, IWorkbook workbook)
        {
            if (workbook == null)
            {
                return targetFile;
            }

            if (Equals(workbook.GetType(), typeof(HSSFWorkbook)))
            {
                targetFile = Path.Combine(Path.GetDirectoryName(targetFile), Path.GetFileNameWithoutExtension(targetFile) + ".xls");
            }
            else if (Equals(workbook.GetType(), typeof(XSSFWorkbook)))
            {
                targetFile = Path.Combine(Path.GetDirectoryName(targetFile), Path.GetFileNameWithoutExtension(targetFile) + ".xlsx");
            }

            return targetFile;
        }
    }
}