using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.SysFrame.CustomAttribute
{
    /// <summary>
    /// 对于Api，可穿透权限防御层（即不受权限约束）
    /// </summary>
    public class ImmuneApiAttribute : Attribute
    {
        public ImmuneApiAttribute()
        {

        }
    }
}
