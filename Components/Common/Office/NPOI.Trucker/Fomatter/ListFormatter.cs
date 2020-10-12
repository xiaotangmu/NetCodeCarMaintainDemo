using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Office.Fomatter
{
    /// <summary>
    /// 抽象的列表数据格式化器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ListFormatter<T> : BaseFormatter<T>
    {
        public List<T> _dataSource
        {
            get; protected set;
        }

        public ListFormatter(List<T> source, params TemplateParameter<T>[] parameters) : base(parameters)
        {
            _dataSource = source;
        }

        public override void Format(ISheet sheet)
        {
            CreateFillContainer(sheet);
            AutoFill(sheet);
        }

        protected virtual void CreateFillContainer(ISheet sheet)
        {

        }

        protected virtual void AutoFill(ISheet sheet)
        {

        }
    }
}