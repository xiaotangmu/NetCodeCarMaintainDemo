using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Office.Fomatter
{
    public abstract class BaseFormatter<T>
    {
        public IEnumerable<Parameter<T>> _parameters
        {
            get; set;
        }

        public BaseFormatter(params Parameter<T>[] parameters)
        {
            _parameters = parameters;
        }

        public virtual void Format(ISheet sheet)
        {

        }
    }
}