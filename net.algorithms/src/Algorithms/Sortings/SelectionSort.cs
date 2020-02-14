using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sortings
{
    public static class SelectionSort
    {
        public static IEnumerable<T> Apply<T>(IEnumerable<T> source, Func<T, T, bool> moreThanComparer)
        {
            return Apply(source.ToArray(), moreThanComparer);
        }

        public static T[] Apply<T>(T[] source, Func<T, T, bool> moreThanComparer)
        {
            for(int swapIdx = 0; swapIdx < source.Length - 1; swapIdx++)
            {
                int minIdx = swapIdx;
                for (int idx = swapIdx + 1; idx < source.Length; idx++)
                {
                    var item1 = source[minIdx];
                    var item2 = source[idx];
                    if (moreThanComparer(item1, item2))
                    {
                        minIdx = idx;
                    }
                }

                source.Swap(swapIdx, minIdx);
            }
            return source;
        }
    }
}
