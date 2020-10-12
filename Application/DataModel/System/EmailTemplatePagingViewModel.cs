using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.System
{
    public class EmailTemplatePagingViewModel
    {
        public int TotalCount { get; set; }

        public IEnumerable<EmailTemplateInfoViewModel> Group { get; set; } = new List<EmailTemplateInfoViewModel>();
    }
}
