using DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Catalog;

namespace ViewModel.Spu
{
    public class SpuModel: SpuAddModel
    {
        public string Id { get; set; }
        public string LUC { get; set; }
        public DateTime LUD { get; set; }
    }
    public class SpuAddModel
    {
        public string Catalog2Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public IEnumerable<SpuAttrModel> SpuAttrModelList = new List<SpuAttrModel>();
    }

    public class SpuPageSearchModel: BaseSearchModel
    {
        public string Catalog2Id { get; set; }
        public string ProductName { get; set; }
    }

    public class SpuAttrModel
    {
        public string Id { get; set; }
        public string AttrId { get; set; }
        public string AttrName { get; set; }
        public IEnumerable<SpuAttrValueModel> ValueList = new List<SpuAttrValueModel>();
    }
    public class SpuAttrValueModel
    {
        public string Id;
        public string Value;
    }
}
