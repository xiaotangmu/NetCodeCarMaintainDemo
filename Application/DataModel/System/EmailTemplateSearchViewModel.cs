using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.System
{
    public class EmailTemplateSearchViewModel : BaseSearchModel
    {
        public string TemplateCode { get; set; }

        public string TemplateName { get; set; }
    }
}
