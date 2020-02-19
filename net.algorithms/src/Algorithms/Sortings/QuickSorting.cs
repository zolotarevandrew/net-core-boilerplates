using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sortings
{
    public static class QuickSortingExtensions
    {
        public static IEnumerable<T> QuickSort<T>(this IEnumerable<T> source, Func<T, T, EqualityKind> comparer)
        {
            return QuickSort(source.ToArray(), comparer);
        }

        public static T[] QuickSort<T>(this T[] source, Func<T, T, EqualityKind> comparer)
        {
            source.QuickSort(0, source.Length - 1, comparer);
            return source;
        }

        public static void QuickSort<T>(this T[] source, int left, int right, Func<T, T, EqualityKind> comparer)
        {
            if (left >= right) return;

            T pivot = source[(left + right) / 2];
            int splitIdx = source.Partition(left, right, pivot, comparer);

            source.QuickSort(left, splitIdx - 1, comparer);
            source.QuickSort(splitIdx, right, comparer);
        }

        public static int Partition<T>(this T[] source, int left, int right, T pivot, Func<T, T, EqualityKind> comparer)
        {
            while (left <= right)
            {
                while(comparer(source[left],pivot) == EqualityKind.Less)
                {
                    left++;
                }

                while (comparer(source[right],pivot) == EqualityKind.More)
                {
                    right--;
                }

                if (left <= right)
                {
                    source.Swap(left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }
    }
}
