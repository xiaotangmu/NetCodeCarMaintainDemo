using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Office.Fomatter
{
    /// <summary>
    /// 从下往上填充的列表数据格式化器，其模板列应为最下边，暂未有业务场景，未实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TowardUpListFormatter<T> : ListFormatter<T>
    {
        public TowardUpListFormatter(List<T> source, params TemplateParameter<T>[] parameters) : base(source, parameters)
        {

        }

        protected override void CreateFillContainer(ISheet sheet)
        {
        }

        protected override void AutoFill(ISheet sheet)
        {

        }
    }
}