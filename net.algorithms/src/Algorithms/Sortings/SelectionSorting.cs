using Algorithms.Comparers;
using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sortings
{
    public static class SelectionSortingExtensions
    {
        public static IEnumerable<T> ApplySelectionSort<T>(this IEnumerable<T> source, IDataComparer<T> comparer)
        {
            return ApplySelectionSort(source.ToArray(), comparer);
        }

        public static T[] ApplySelectionSort<T>(this T[] source, IDataComparer<T> comparer)
        {
            for(int swapIdx = 0; swapIdx < source.Length - 1; swapIdx++)
            {
                int minIdx = swapIdx;
                for (int idx = swapIdx + 1; idx < source.Length; idx++)
                {
                    var item1 = source[minIdx];
                    var item2 = source[idx];
                    if (comparer.Compare(item1, item2).IsFirstMore)
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
