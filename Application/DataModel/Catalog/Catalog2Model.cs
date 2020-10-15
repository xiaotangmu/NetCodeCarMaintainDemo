using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Catalog
{
    public class Catalog2Model : Catalog1AddModel
    {
        public string Id { get; set; }
    }

    public class Catalog2AddModel
    {
        public string CatalogName { get; set; }

        public string Catalog1Id { get; set; }
    }
}
