using Algorithms.Comparers;
using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sortings
{
    public static class InsertionSortingExtensions
    {
        public static IEnumerable<T> ApplyInsertionSort<T>(this IEnumerable<T> source, IDataComparer<T> comparer)
        {
            return ApplyInsertionSort(source.ToArray(), comparer);
        }

        public static T[] ApplyInsertionSort<T>(this T[] source, IDataComparer<T> comparer)
        {
            for (int idx = 1; idx < source.Length; idx++)
            {
                T currentItem = source[idx];
                int prev = idx - 1;
                while(prev >= 0 && comparer.Compare(source[prev], currentItem).IsFirstMore)
                {
                    source[prev + 1] = source[prev];
                    prev--;
                }
                source[prev + 1] = currentItem;
            }
            return source;
        }
    }
}
