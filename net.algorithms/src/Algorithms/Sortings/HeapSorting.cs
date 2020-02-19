using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sortings
{
    public static class HeapSorting
    {
        public static IEnumerable<T> HeapSort<T>(this IEnumerable<T> source, Func<T, T, bool> moreThanComparer)
        {
            return HeapSort(source.ToArray(), moreThanComparer);
        }

        public static T[] HeapSort<T>(this T[] source, Func<T, T, bool> moreThanComparer)
        {
            int length = source.Length;

            var index = length / 2 - 1;
            while (index >= 0)
            {
                source.BubbleDown(length, index, moreThanComparer);
                index--;
            }

            var end = length - 1;

            while (end >= 0)
            {
                source.Swap(0, end);
                source.BubbleDown(end, 0, moreThanComparer);
                end--;
            }

            return source;
        }

        public static void BubbleDown<T>(this T[] source, int length, int index, Func<T, T, bool> moreThanComparer)
        {
            int curIdx = index;
            while(curIdx < length)
            {
                int leftIndex = LeftIndex(curIdx);
                if (leftIndex >= length) return;

                int rightIndex = RightIndex(curIdx);
                int maxChildIdx = leftIndex;
                if (rightIndex < length && moreThanComparer(source[rightIndex], source[leftIndex]))
                {
                    maxChildIdx = rightIndex;
                }

                if (moreThanComparer(source[maxChildIdx], source[curIdx]))
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
