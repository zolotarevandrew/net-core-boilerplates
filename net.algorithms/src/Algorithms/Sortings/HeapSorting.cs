using Algorithms.Comparers;
using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sortings
{
    public static class HeapSorting
    {
        public static IEnumerable<T> ApplyHeapSort<T>(this IEnumerable<T> source, IDataComparer<T> comparer)
        {
            return ApplyHeapSort(source.ToArray(), comparer);
        }

        public static T[] ApplyHeapSort<T>(this T[] source, IDataComparer<T> comparer)
        {
            int length = source.Length;

            var index = length / 2 - 1;
            while (index >= 0)
            {
                source.BubbleDown(length, index, comparer);
                index--;
            }

            var end = length - 1;

            while (end >= 0)
            {
                source.Swap(0, end);
                source.BubbleDown(end, 0, comparer);
                end--;
            }

            return source;
        }

        public static void BubbleDown<T>(this T[] source, int length, int index, IDataComparer<T> comparer)
        {
            int curIdx = index;
            while(curIdx < length)
            {
                int leftIndex = LeftIndex(curIdx);
                if (leftIndex >= length) return;

                int rightIndex = RightIndex(curIdx);
                int maxChildIdx = leftIndex;
                if (rightIndex < length && comparer.Compare(source[rightIndex], source[leftIndex]).IsFirstMore)
                {
                    maxChildIdx = rightIndex;
                }

                if (comparer.Compare(source[maxChildIdx], source[curIdx]).IsFirstMore)
                {
                    source.Swap(curIdx, maxChildIdx);
                    curIdx = maxChildIdx;
                    continue;
                }
                return;
            }
        }

        static int LeftIndex(int parent)
        {
            return 2 * parent + 1;
        }

        static int RightIndex(int parent)
        {
            return 2 * parent + 2;
        }
    }
}
