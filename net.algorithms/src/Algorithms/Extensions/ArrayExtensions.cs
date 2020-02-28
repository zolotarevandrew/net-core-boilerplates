using Algorithms.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Extensions
{
    public static class ArrayExtensions
    {
        public static void Swap<T>(this T[] arr, int i1, int i2)
        {
            T t = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = t;
        }

        public static bool IndexExists<T>(this T[] arr, int idx) 
        {
            if (arr.Length == 0) return false;

            return idx < arr.Length;
        }

        public static bool BinarySearch<T>(this T[] arr, T item, IDataComparer<T> comparer)
        {
            int left = 0;
            int right = arr.Length - 1;
            while(left <= right)
            {
                int middle = (right - left) / 2 + left;
                var compareResult = comparer.Compare(item, arr[middle]);
                if (compareResult.IsEqual) {
                    return true;
                }
                if (compareResult.IsFirstLess)
                {
                    right = middle - 1;
                }
                if (compareResult.IsFirstMore)
                {
                    left = middle + 1;
                }
            }
            return false;
        }

        public static bool BinarySearch<T>(this IEnumerable<T> arr, T item, IDataComparer<T> comparer)
        {
            return arr.ToArray().BinarySearch(item, comparer);
        }
    }
}
