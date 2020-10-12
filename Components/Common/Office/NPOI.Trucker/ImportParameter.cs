using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Office
{
    public class ImportParameter<T> : Parameter<T>
    {
        public int EndRowIndex { get; set; }

        public ImportParameter(ImportParameter<T> param) : base(param)
        {
            EndRowIndex = param.EndRowIndex;
        }
    }
}