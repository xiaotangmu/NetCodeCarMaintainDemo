using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.System
{
    public class UpdateModel
    {
        /// <summary>
        /// 更新集合，string对应数据库字段，object为更新值
        /// </summary>
        public Dictionary<string, object> SetCollection { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 约束集合，string对应数据库字段，object为值
        /// </summary>
        public Dictionary<string, object> WhereCollection { get; set; } = new Dictionary<string, object>();
    }
}
