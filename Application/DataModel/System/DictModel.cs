using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.System
{
    public class DictBaseModel
    {
        public string DictTypeCode { get; set; }

        public string DictCode { get; set; }

        public string DictText { get; set; }

        public string Description { get; set; }
    }

    public class DictSearchPageModel : DictSearchModel
    {
    }

    public class DictSearchModel : BaseSearchModel
    {
        public string DictTypeCode { get; set; }

        public string DictCode { get; set; }

        public string DictText { get; set; }

        public string Description { get; set; }

        public string IsUse { get; set; }
    }

    public class DictPageModel
    {
        public long TotalCount { get; set; }

        public List<DictViewModel> Items { get; set; } = new List<DictViewModel>();
    }

    public class DictViewModel : DictBaseModel
    {
        public bool IsUse { get; set; }
    }

    public class AddDictModel : DictBaseModel
    {

    }

    public class DeleteDictModel
    {
        public string DictTypeCode { get; set; }

        public string DictCode { get; set; }
    }
}
