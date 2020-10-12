using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Workflow
{
    public enum WorkflowType
    {
        /// <summary>
        /// 工程维修
        /// </summary>
        MAINTENANCE = 1,
        /// <summary>
        /// 物料领用
        /// </summary>
        MATERIAL_RECIPIENT = 2,
        /// <summary>
        /// 物料退库
        /// </summary>
        MATERIAL_RETURN = 3
    }
}
