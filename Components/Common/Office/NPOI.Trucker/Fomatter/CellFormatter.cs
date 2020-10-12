using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Common.Office.Fomatter
{
    /// <summary>
    /// 最小单位的格式化器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CellFormatter<T> : BaseFormatter<T>
    {
        public T Source { get; set; }

        public CellFormatter(T source, params TemplateParameter<T>[] parameters) : base(parameters)
        {
            Source = source;
        }

        public override void Format(ISheet sheet)
        {
            if (_parameters == null)
            {
                return;
            }
            if (_parameters.Count() == 0)
            {
                return;
            }
            foreach (TemplateParameter<T> parameter in _parameters)
            {
                ICell targetCell = sheet.GetRow(parameter.RowIndex).GetCell(parameter.ColumnIndex);
                targetCell.CellStyle = parameter.TargetType;
                if (targetCell == null)
                {
                    return;
                }
                if (!targetCell.StringCellValue.Contains(string.Format("$[{0}]", parameter.BindingName)))
                {
                    return;
                }
                targetCell.SetCellValue(targetCell.StringCellValue.Replace(string.Format("$[{0}]", parameter.BindingName), parameter.BindingTarget(Source).Convert<string>()));
                //targetCell.SetCellType(parameter.BindingTarget(Source).GetType());

            }
        }
    }
}