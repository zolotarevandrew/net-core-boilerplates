using Algorithms.Comparers;
using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sortings
{
    public static class QuickSortingExtensions
    {
        public static IEnumerable<T> ApplyQuickSort<T>(this IEnumerable<T> source, IDataComparer<T> comparer)
        {
            return ApplyQuickSort(source.ToArray(), comparer);
        }

        public static T[] ApplyQuickSort<T>(this T[] source, IDataComparer<T> comparer)
        {
            source.ApplyQuickSort(0, source.Length - 1, comparer);
            return source;
        }

        public static void ApplyQuickSort<T>(this T[] source, int left, int right, IDataComparer<T> comparer)
        {
            if (left >= right) return;

            T pivot = source[(left + right) / 2];
            int splitIdx = source.Partition(left, right, pivot, comparer);

            source.ApplyQuickSort(left, splitIdx - 1, comparer);
            source.ApplyQuickSort(splitIdx, right, comparer);
        }

        public static int Partition<T>(this T[] source, int left, int right, T pivot, IDataComparer<T> comparer)
        {
            while (left <= right)
            {
                while(comparer.Compare(source[left],pivot).IsFirstLess)
                {
                    left++;
                }

                while (comparer.Compare(source[right],pivot).IsFirstMore)
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
