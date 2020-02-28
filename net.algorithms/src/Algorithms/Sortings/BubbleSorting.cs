using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Comparers;

namespace Algorithms.Sortings
{
    public static class BubbleSortingExtensions
    {
        public static IEnumerable<T> ApplyBubbleSort<T>(this IEnumerable<T> source, IDataComparer<T> comparer)
        {
            return ApplyBubbleSort(source.ToArray(), comparer);
        }

        public static T[] ApplyBubbleSort<T>(this T[] source, IDataComparer<T> comparer)
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
                    if (comparer.Compare(item1, item2).IsFirstMore)
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
