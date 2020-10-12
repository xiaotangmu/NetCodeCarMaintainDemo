using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.System
{
    public class AccountLoginModel
    {
        public string IdentitytCode { get; set; }
    }

    public class QuickLoginModel
    {
        public string ApplicationCode { get; set; }

        public string IdCard { get; set; }
    }

    public class VisitorLoginModel
    {
        public string Telephone { get; set; }
    }
}
