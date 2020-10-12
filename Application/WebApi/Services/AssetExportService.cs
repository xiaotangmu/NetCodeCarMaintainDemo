using Microsoft.AspNetCore.Http;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Common.Office;

namespace WebApi.Services
{
    /// <summary>
    /// 导出服务
    /// </summary>
    public class ExportService
    {
        /// <summary>
        /// 保存成Excel文件到服务器
        /// </summary>
        /// <typeparam name="T">导出数据类型</typeparam>
        /// <param name="fileName">文件名</param>
        /// <param name="data">导出数据</param>
        /// <param name="columns">导出数据的列集合，列编码必须与数据的列对应</param>
        public static Stream SaveExcel<T>(string fileName, List<T> data, List<TableColumnModel> columns)
        {
            IWorkbook book = ExcelWorkbookFactory.Singleton.Create(ExcelType.Excel2003);
            ExportHelper helper = new ExportHelper(book);

            //填充数据
            int sheetCount = data.Count / 65530 + 1;
            for (int i = 0; i < sheetCount; i++)
            {
                ISheet sheet = book.GetSheetAt(i);
                if (sheet == null)
                {
                    sheet = book.CreateSheet();
                }
                IRow headerRow = sheet.CreateRow(0);
                BuildHeaderRow(headerRow, columns);
                FillData(data, columns, sheet);
            }
            helper.Save(fileName);

            return new FileStream(fileName, FileMode.Open);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="httpContext">请求上下文</param>
        /// <param name="serverPath">服务器路径</param>
        /// <param name="fileName">文件名</param>
        /// <param name="data">导出的数据</param>
        /// <param name="columns">导出数据的列集合</param>
        public static async Task Export<T>(HttpContext httpContext, string fileName, string serverPath, List<T> data, List<TableColumnModel> columns)
        {
            string fileFullName = Path.Combine(serverPath, fileName);
            if (File.Exists(fileFullName))
            {
                //先清理
                File.Delete(fileFullName);
            }
            SaveExcel(fileName, data, columns);
            if (!File.Exists(fileFullName))
            {
                throw new Exception(await Localization.Localizer.GetValueAsync("ExportFailed"));
            }
        }

        /// <summary>
        /// 构建Excel2003文件名
        /// </summary>
        /// <returns></returns>
        public static string BuildExcel2003FileName()
        {
            string fileName = Guid.NewGuid().ToString().Replace("-", "");
            return Path.ChangeExtension(fileName, ".xls");
        }

        /// <summary>
        /// 构建PDF文件名
        /// </summary>
        /// <returns></returns>
        public static string BuildPDFFileName()
        {
            string fileName = Guid.NewGuid().ToString().Replace("-", "");
            return Path.ChangeExtension(fileName, ".pdf");
        }
        public static void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        /// <summary>
        /// 填充数据，默认从第2行开始填充
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="columns"></param>
        /// <param name="sheet"></param>
        private static void FillData<T>(List<T> data, List<TableColumnModel> columns, ISheet sheet)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            for (int cellIndex = 0; cellIndex < columns.Count; cellIndex++)
            {
                for (int rowIndex = 1; rowIndex < data.Count + 1; rowIndex++)
                {
                    IRow row = GetRow(sheet, rowIndex);
                    ICell cell = GetCell(row, cellIndex);
                    if (properties.Any(property => property.Name.Trim() == columns[cellIndex].Code.Trim()))
                    {
                        PropertyInfo property = properties.FirstOrDefault(pro => pro.Name.Trim() == columns[cellIndex].Code.Trim());
                        object value = property.GetValue(data[rowIndex - 1]);
                        SetCellValue(cell, value, property.PropertyType);
                    }
                }
            }
        }

        private static void SetCellValue(ICell cell, object value, Type propertyType)
        {
            if (value == null)
            {
                return;
            }
            if (propertyType == typeof(string))
            {
                cell.SetCellType(CellType.String);
                cell.SetCellValue(value.ToString());
            }
            else if (propertyType == typeof(int) || propertyType == typeof(float) ||
                propertyType == typeof(double) || propertyType == typeof(decimal) || propertyType == typeof(long))
            {
                cell.SetCellType(CellType.Numeric);
                cell.SetCellValue(double.Parse(value.ToString()));
            }
            else if (propertyType == typeof(bool))
            {
                cell.SetCellType(CellType.Boolean);
                cell.SetCellValue((bool)value);
            }
        }

        private static IRow GetRow(ISheet sheet, int rowIndex)
        {
            IRow row = sheet.GetRow(rowIndex);
            if (row == null)
            {
                row = sheet.CreateRow(rowIndex);
            }
            return row;
        }

        private static ICell GetCell(IRow row, int cellIndex)
        {
            ICell cell = row.GetCell(cellIndex);
            if (cell == null)
            {
                cell = row.CreateCell(cellIndex);
            }
            return cell;
        }

        private static void BuildHeaderRow(IRow headerRow, List<TableColumnModel> columns)
        {
            //设置列头
            for (int i = 0; i < columns.Count; i++)
            {
                ICell cell = GetCell(headerRow, i);
                cell.SetCellValue(columns[i].Name);
            }
        }
    }

    /// <summary>
    /// 表格的列模型
    /// </summary>
    public class TableColumnModel
    {
        public string Code { get; set; }

        public string Name { get; set; }

    }
}
