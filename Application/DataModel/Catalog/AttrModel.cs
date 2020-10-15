using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Catalog
{
    public class AttrModel: AttrAddModel
    {
        public string Id;
    }

    public class AttrAddModel
    {
        public string AttrName;
        public string CatalogId;
    }
}
