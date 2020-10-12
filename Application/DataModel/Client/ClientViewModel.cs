using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Client
{
    public class ClientViewModel
    {
        public string company { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string type { get; set; }
        public string description { get; set; }
    }

    public class ClientListWithPagingViewModel
    {
        public int TotalCount { get; set; }

        public IEnumerable<ClientViewModel> Items { get; set; } = new List<ClientViewModel>();
    }

    public class ClientListSearchViewModel : BaseSearchModel
    {
        public ClientListSearchViewModel() :  base()
        {
        }
    }
}
