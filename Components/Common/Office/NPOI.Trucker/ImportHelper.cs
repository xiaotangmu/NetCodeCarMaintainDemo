using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Common.Office
{
    public class ImportHelper
    {
        public IWorkbook Workbook { get; set; }

        public ImportHelper(string file)
        {
            Workbook = WorkbookFactory.Create(file);
        }

        public void BindEntity<T>(T container, params Parameter<T>[] parameters)
        {
            if (Workbook == null)
            {
                return;
            }
            foreach (Parameter<T> param in parameters)
            {
                PropertyInfo property = container.GetType().GetProperty(param.BindingName);
                if (property == null)
                {
                    continue;
                }
                ICell cell = Workbook.GetSheetAt(0).GetRow(param.RowIndex).GetCell(param.ColumnIndex);
                property.SetValue(container, TypeConverter.Convert(TypeConverter.GetCellValue(cell), property.PropertyType));
            }
        }

        public List<T> BindCollection<T>(ISheet sheet, int headerRowIndex, CellRangeAddress dataRange, List<T> containers = null) where T : new()
        {
            if (containers == null)
            {
                containers = new List<T>();
            }
            if (Workbook == null)
            {
                return containers;
            }

            IRow headerRow = sheet.GetRow(headerRowIndex);
            for (int row = dataRange.FirstRow; row < dataRange.LastRow + 1; row++)
            {
                T obj = new T();
                foreach (ICell cell in headerRow.Cells)
                {
                    PropertyInfo property = obj.GetType().GetProperty(cell.StringCellValue);
                    if (property == null)
                    {
                        continue;
                    }
                    ICell currentCell = sheet.GetRow(row).GetCell(cell.ColumnIndex);
                    if (currentCell == null)
                    {
                        continue;
                    }
                    property.SetValue(obj, TypeConverter.Convert(TypeConverter.GetCellValue(currentCell), property.PropertyType));
                }
                containers.Add(obj);
            }
            return containers;
        }
    }
}