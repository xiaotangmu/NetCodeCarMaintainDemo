using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class BaseSearchModel
    {
        /// <summary>
        /// 分页序号为负数时，则取全部数据，默认值为-1
        /// </summary>
        public int PageIndex { get; set; } = -1;

        public int PageSize { get; set; } = 10;
    }

    public class BaseDeleteModel
    {
        public string Code { get; set; }
    }
}
