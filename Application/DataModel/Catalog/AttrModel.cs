using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Catalog
{
    public class AttrModel: AttrAddModel
    {
        public string Id { get; set; }
    }

    public class AttrAddModel
    {
        public string AttrName { get; set; }
        public string CatalogId { get; set; }
    }
}
