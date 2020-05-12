using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public interface IObjectComparer<in T>
    {
        bool Compare(T a, T b);
    }
}
