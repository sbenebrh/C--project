using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public static class Toolstring
    {
        public static string ToStringProperties<T>(this T entity) where T : new()
        {
            string result = "";
            foreach (PropertyInfo item in entity.GetType().GetProperties())
                result += String.Format(" {0,-15} :  {1} ", item.Name, item.GetValue(entity, null));
            return result;
        }
    }
    
}
