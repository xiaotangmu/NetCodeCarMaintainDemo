using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Common
{
    public class PageModel<T>
    {
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; } = new List<T>();
    }
}
