using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sortings
{
    public static class MergeSortingExtensions
    {
        public static IEnumerable<T> SortByMerge<T>(this IEnumerable<T> source, Func<T, T, bool> moreThanComparer)
        {
            return SortByMerge(source.ToArray(), moreThanComparer);
        }

        public static T[] SortByMerge<T>(this T[] source, Func<T, T, bool> moreThanComparer)
        {
            return source;
        }

        public static T[] MergeByMinElements<T>(this T[] arr1, T[] arr2, Func<T, T, bool> moreThanComparer)
        {
            int size = Math.Max(arr1.Length, arr2.Length);

            var result = new T[size];
            for(int idx = 0; idx < size; idx++)
            {
                var arr1ItemExists = arr1.IndexExists(idx);
                var arr2ItemExists = arr2.IndexExists(idx);
                if (!arr1ItemExists && arr2ItemExists)
                {
                    result[idx] = arr2[idx];
                    continue;
                }
                if (!arr2ItemExists && arr1ItemExists)
                {
                    result[idx] = arr1[idx];
                    continue;
                }
                result[idx] = moreThanComparer(arr1[idx], arr2[idx])
                       ? arr2[idx]
                       : arr1[idx];
            }
            return result;
        }

        public static IEnumerable<T> MergeByMinElements<T>(this IEnumerable<T> arr1, IEnumerable<T> arr2, Func<T, T, bool> moreThanComparer)
        {
            return arr1.ToArray().MergeByMinElements(arr2.ToArray(), moreThanComparer);
        }
    }
}
