using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Office.Fomatter;

namespace Common.Office
{
    public class SheetTrucker<T>
    {
        private IEnumerable<BaseFormatter<T>> _formatters
        {
            get; set;
        }

        public SheetTrucker(params BaseFormatter<T>[] formatters)
        {
            _formatters = formatters;
        }

        public void Fill(ISheet sheet)
        {
            if (sheet == null)
            {
                return;
            }
            if (_formatters == null)
            {
                FillWithOutFormatter(sheet);
            }
            else
            {
                FillWithFormatter(sheet);
            }
        }

        private void FillWithFormatter(ISheet sheet)
        {
            foreach (BaseFormatter<T> formatter in _formatters)
            {
                formatter.Format(sheet);
            }
        }

        private void FillWithOutFormatter(ISheet sheet)
        {

        }
    }
}