using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    class IntComparer : IObjectComparer<int>
    {
        public bool Compare(int a, int b)
        {
            if (a == b)
                return true;
            return false;
        }
    }
}
