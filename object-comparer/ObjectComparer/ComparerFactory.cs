using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
     public class ComparerFactory
    {
        public static IObjectComparer<T> CreateComparerObject<T>()
        {
            
            Type type = typeof(T);
          
            if (type == typeof(string))
                return (IObjectComparer<T>)new StringComparer();
            if(type == typeof(int))
            return (IObjectComparer<T>)new IntComparer();          
           
            if (type.BaseType.Name == "Object")
            {
                var objtype = new ObjComparer();
                return (IObjectComparer<T>)objtype;
            }
            return null;
        }

        
    }
}
