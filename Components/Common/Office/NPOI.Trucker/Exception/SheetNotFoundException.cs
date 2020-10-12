using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Office.Exception
{
    public class SheetNotFoundException : System.Exception
    {
        public SheetNotFoundException():base()
        {

        }

        public SheetNotFoundException(string message):base(message)
        {

        }
    }
}