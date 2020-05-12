using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    class ObjComparer : IObjectComparer<object>
    {
        public bool Compare(object a, object b)
        {
            if (a == null && b == null)
                return true;

            if (a.GetType().Name == "List`1" && b.GetType().Name == "List`1")
            {
                IEnumerable<object> enumValue1, enumValue2;

                enumValue1 = ((IEnumerable)a).Cast<object>();
                enumValue2 = ((IEnumerable)b).Cast<object>();
                // if the items count are different return false
                if (enumValue1.Count() != enumValue2.Count())
                    return false;
                // if the count is same, compare individual item
                else
                {

                    foreach (var item in enumValue1)
                    {
                        bool matchfound = false;
                        foreach (var item2 in enumValue2)
                        {
                            matchfound = Compare(item, item2);
                            if (matchfound)
                                break;
                        }
                        if (!matchfound)
                            return false;
                    }

                }


            }
            else if(a.GetType().IsPrimitive || a.GetType().Name == "String")
            {
                if (a.Equals(b))
                    return true;
                return false;
            }
            else
            {
                foreach (var propa in a.GetType().GetProperties())
                {
                    var propb = b.GetType().GetProperty(propa.Name);
                    dynamic avalue = propa.GetValue(a);
                    dynamic bvalue = propb.GetValue(b);
                    var proptype = propa.PropertyType;
                    if (proptype.BaseType.Name == "Array")
                    {
                        if (avalue.Length == bvalue.Length)
                        {
                            foreach (var item in avalue)
                            {
                                bool matchValues = false;
                                for (int i = 0; i < avalue.Length; i++)
                                {
                                    if (bvalue[i].Equals(item))
                                    {
                                        matchValues = true;
                                        break;
                                    }
                                }
                                if (!matchValues)
                                {
                                    return false;
                                }

                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (proptype.Name == "List`1")
                    {
                        foreach (var item in avalue)
                        {
                            if (!bvalue.Contains(item))
                            {
                                return false;
                            }
                        }
                    }
                    else if (!avalue.Equals(bvalue))
                    { return false; }
                }
            }

            return true;
        }
    }
}
