using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Office
{
    public class Parameter<T> : ICloneable
    {
        public int RowIndex
        {
            set; get;
        }

        public int ColumnIndex
        {
            set; get;
        }

        public ICellStyle TargetType
        {
            get; set;
        }

        public string BindingName
        {
            set; get;
        }

        public Parameter()
        {

        }

        public Parameter(Parameter<T> param)
        {
            RowIndex = param.RowIndex;
            ColumnIndex = param.ColumnIndex;
            TargetType = param.TargetType;
            BindingName = param.BindingName;
        }

        public virtual object Clone()
        {
            return new Parameter<T>(this);
        }
    }
}