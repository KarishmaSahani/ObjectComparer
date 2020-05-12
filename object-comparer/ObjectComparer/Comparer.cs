using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public static class Comparer
    {
        public static bool AreSimilar<T>(T first, T second )
        {
            IObjectComparer<T> objComparer;

            objComparer = ComparerFactory.CreateComparerObject<T>();
            bool areSimilar = objComparer.Compare(first, second);
           
            return areSimilar;
        }
    }
}
