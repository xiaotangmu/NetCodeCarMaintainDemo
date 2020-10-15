using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Catalog
{
    public class Catalog1Model: Catalog1AddModel
    {
        public string Id { get; set; }
    }
    public class Catalog1AddModel
    {
        public string CatalogName { get; set; }
    }
}
