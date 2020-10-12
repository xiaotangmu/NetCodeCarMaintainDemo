using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOI.SS.UserModel;

namespace Common.Office.Fomatter
{
    /// <summary>
    /// 从上往下填充的列表数据格式化器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TowardDownListFormatter<T> : ListFormatter<T>
    {
        public TowardDownListFormatter(List<T> source, params TemplateParameter<T>[] parameters) : base(source, parameters)
        {

        }

        protected override void CreateFillContainer(ISheet sheet)
        {
            if (_parameters == null)
            {
                return;
            }

            for (int num = 1; num < _dataSource.Count(); num++)
            {
                int templateRowIndex = _parameters.First().RowIndex;
                sheet.GetRow(templateRowIndex).CopyRowTo(num + templateRowIndex);
            }
        }

        protected override void AutoFill(ISheet sheet)
        {
            //行数增量，用于调整模板参数对象的RowIndex
            int rowIncrease = 0;
            foreach (T data in _dataSource)
            {
                foreach (TemplateParameter<T> param in _parameters)
                {
                    TemplateParameter<T> parameter = param.Clone() as TemplateParameter<T>;
                    parameter.RowIndex += rowIncrease;

                    CellFormatter<T> cellFormatter = new CellFormatter<T>(data, parameter);
                    cellFormatter.Format(sheet);
                }
                rowIncrease++;
            }
        }
    }
}