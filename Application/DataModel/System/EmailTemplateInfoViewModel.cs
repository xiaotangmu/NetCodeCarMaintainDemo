using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.System
{
    public class EmailTemplateInfoViewModel
    {
        public string TemplateCode { get; set; }

        public string TemplateName { get; set; }

        public string ToUser { get; set; }

        public string CCUser { get; set; }

        public string BCCUser { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}
