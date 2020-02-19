using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            int size = source.Length;
            int maxLength = size - 1;
            int divideLength = 1;
            while (divideLength < size)
            {
                int startIdx = 0;
                bool isStopped = false;
                var newLength = divideLength * 2;

                while(!isStopped)
                {
                    var start = startIdx;
                    var end = startIdx + newLength - 1;
                    var split = (end - start) / 2 + start;

                    if (!source.IndexExists(split)) split = maxLength;
                    if (!source.IndexExists(end)) end = maxLength;

                    isStopped = end == maxLength;
                    source.MergeByMinElements(
                        start,
                        split,
                        end, 
                        moreThanComparer
                    );
                    startIdx += newLength;
                }

                divideLength = newLength;
            }
            return source;
        }
        
        public static void MergeByMinElements<T>(this T[] arr, int start, int split, int end, Func<T, T, bool> moreThanComparer)
        {
            var buffer = new T[end - start + 1];
            var firstIdx = start;
            var secondIdx = split + 1;
            int resIdx = 0;

            while (firstIdx <= split && secondIdx <= end)
            {
                if (moreThanComparer(arr[firstIdx], arr[secondIdx]))
                {
                    buffer[resIdx] = arr[secondIdx];
                    secondIdx++;
                }
                else
                {
                    buffer[resIdx] = arr[firstIdx];
                    firstIdx++;
                }
                resIdx++;
            }

            while (firstIdx <= split)
            {
                buffer[resIdx] = arr[firstIdx];
                firstIdx++;
                resIdx++;
            }

            while (secondIdx <= end)
            {
                buffer[resIdx] = arr[secondIdx];
                secondIdx++;
                resIdx++;
            }

            buffer.CopyTo(arr, start);
        }
    }
}
