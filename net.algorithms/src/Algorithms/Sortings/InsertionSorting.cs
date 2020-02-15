using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sortings
{
    public static class InsertionSortingExtensions
    {
        public static IEnumerable<T> SortByInsertion<T>(this IEnumerable<T> source, Func<T, T, bool> moreThanComparer)
        {
            return SortByInsertion(source.ToArray(), moreThanComparer);
        }

        public static T[] SortByInsertion<T>(this T[] source, Func<T, T, bool> moreThanComparer)
        {
            for (int idx = 1; idx < source.Length; idx++)
            {
                T currentItem = source[idx];
                int prev = idx - 1;
                while(prev >= 0 && moreThanComparer(source[prev], currentItem))
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
