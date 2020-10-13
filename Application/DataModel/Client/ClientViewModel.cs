using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Client
{
    public class ClientAddModel
    {
        public string Company { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }

    public class ClientViewModel : ClientAddModel
    {
        public string id { get; set; }

        public ClientViewModel(): base()
        {

        }
    }

    public class ClientListWithPagingViewModel
    {
        public int TotalCount { get; set; }

        public IEnumerable<ClientViewModel> Items { get; set; } = new List<ClientViewModel>();
    }

    public class ClientListSearchViewModel : BaseSearchModel
    {

    }

    public class DeleteClientModel
    {
        public string id;
        public string Company;
    }
}
