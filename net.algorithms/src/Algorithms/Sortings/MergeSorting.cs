using Algorithms.Comparers;
using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Algorithms.Sortings
{
    public static class MergeSortingExtensions
    {
        public static IEnumerable<T> ApplyMergeSort<T>(this IEnumerable<T> source, IDataComparer<T> comparer)
        {
            return ApplyMergeSort(source.ToArray(), comparer);
        }

        public static T[] ApplyMergeSort<T>(this T[] source, IDataComparer<T> comparer)
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
                        comparer
                    );
                    startIdx += newLength;
                }

                divideLength = newLength;
            }
            return source;
        }
        
        public static void MergeByMinElements<T>(this T[] arr, int start, int split, int end, IDataComparer<T> comparer)
        {
            var buffer = new T[end - start + 1];
            var firstIdx = start;
            var secondIdx = split + 1;
            int resIdx = 0;

            while (firstIdx <= split && secondIdx <= end)
            {
                if (comparer.Compare(arr[firstIdx], arr[secondIdx]).IsFirstMore)
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
