using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DataModel
{
    public class ObjectAttributeCopier
    {
        public static void CopyAttributes(Object FromObject, Object ToObject)
        {
            if (FromObject == null || ToObject == null)
            {
                return;
            }
            PropertyInfo[] fromProperties = FromObject.GetType().GetProperties();
            PropertyInfo[] toProperties = ToObject.GetType().GetProperties();
            foreach (PropertyInfo fromProperty in fromProperties)
            {
                foreach (PropertyInfo toProperty in toProperties)
                {
                    if (toProperty.Name.Equals(fromProperty.Name))
                    {
                        toProperty.SetValue(ToObject, fromProperty.GetValue(FromObject));
                    }
                }
            }
        }
    }
}
