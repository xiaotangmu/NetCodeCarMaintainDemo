﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common.Office
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreAttribute : Attribute
    {

    }
}