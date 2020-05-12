using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    class StringComparer : IObjectComparer<string>
    {
        public bool Compare(string a, string b)
        {
            if (a == null && b == null)
                return true;
            if(a.Equals(b))
            { return true; }
            return false;
        }
    }
}
