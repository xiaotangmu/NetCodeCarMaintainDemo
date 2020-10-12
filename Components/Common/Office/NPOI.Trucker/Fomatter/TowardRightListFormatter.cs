using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Office.Fomatter
{
    /// <summary>
    /// 从左往右填充的列表数据格式化器，其模板列应为最左边
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TowardRightListFormatter<T> : ListFormatter<T>
    {
        public TowardRightListFormatter(List<T> source, params TemplateParameter<T>[] parameters) : base(source, parameters)
        {

        }

        protected override void CreateFillContainer(ISheet sheet)
        {
            if (_parameters == null)
            {
                return;
            }
            foreach (TemplateParameter<T> parameter in _parameters)
            {
                IRow row = sheet.GetRow(parameter.RowIndex);
                for (int colIndex = 1; colIndex < _dataSource.Count; colIndex++)
                {
                    row.CopyCell(parameter.ColumnIndex, colIndex + parameter.ColumnIndex);
                }
            }
        }

        protected override void AutoFill(ISheet sheet)
        {
            foreach (TemplateParameter<T> param in _parameters)
            {
                int columnIncrease = 0;
                foreach (T data in _dataSource)
                {
                    TemplateParameter<T> parameter = param.Clone() as TemplateParameter<T>;
                    parameter.ColumnIndex += columnIncrease;

                    CellFormatter<T> cellFormatter = new CellFormatter<T>(data, parameter);
                    cellFormatter.Format(sheet);

                    columnIncrease++;
                }
            }
        }
    }
}