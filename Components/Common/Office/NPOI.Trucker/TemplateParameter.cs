using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Office
{
    public class TemplateParameter<T> : Parameter<T>
    {
        public Func<T, object> BindingTarget
        {
            get; set;
        }

        public TemplateParameter()
        {

        }

        public TemplateParameter(TemplateParameter<T> param) : base(param)
        {
            BindingTarget = new Func<T, object>(param.BindingTarget);
        }

        public override object Clone()
        {
            return new TemplateParameter<T>(this);
        }
    }
}