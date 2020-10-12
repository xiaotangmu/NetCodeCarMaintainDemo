using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOI.SS.UserModel;

namespace Common.Office.Fomatter
{


    public class ParterFormatter<T> : BaseFormatter<T>
    {
        public override void Format(ISheet sheet)
        {
            base.Format(sheet);
        }
    }
}