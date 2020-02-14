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

        public static bool BinarySearch<T>(this T[] arr, T item, Func<T,T, EqualityKind> equalityComparer)
        {
            int left = 0;
            int right = arr.Length - 1;
            while(left <= right)
            {
                int middle = (right - left) / 2 + left;
                var compareResult = equalityComparer(item, arr[middle]);
                if (compareResult == EqualityKind.Equal) {
                    return true;
                }
                if (compareResult == EqualityKind.Less)
                {
                    right = middle - 1;
                }
                if (compareResult == EqualityKind.More)
                {
                    left = middle + 1;
                }
            }
            return false;
        }

        public static bool BinarySearch<T>(this IEnumerable<T> arr, T item, Func<T, T, EqualityKind> equalityComparer)
        {
            return arr.ToArray().BinarySearch(item, equalityComparer);
        }
    }
}
