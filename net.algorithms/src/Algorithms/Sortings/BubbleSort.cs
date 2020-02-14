using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sortings
{
    public class BubbleSort
    {
        public static IEnumerable<T> Apply<T>(IEnumerable<T> source, Func<T, T, bool> moreThanComparer)
        {
            return Apply(source.ToArray(), moreThanComparer);
        }

        public static T[] Apply<T>(T[] source, Func<T,T, bool> moreThanComparer)
        {
            bool isSorted = false;
            int lastUnsorted = source.Length - 1;
            while(!isSorted)
            {
                isSorted = true;
                for (int idx = 0; idx < lastUnsorted; idx++)
                {
                    var item1 = source[idx];
                    var item2 = source[idx + 1];
                    if (moreThanComparer(item1, item2))
                    {
                        source.Swap(idx, idx+1);
                        isSorted = false;
                    }
                }
                lastUnsorted--;
            }
            return source;
        }
    }
}
