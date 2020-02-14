using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sortings
{
    public static class BinaryInsertionSorting
    {
        public static IEnumerable<T> Apply<T>(IEnumerable<T> source, Func<T, T, bool> moreThanComparer)
        {
            return Apply(source.ToArray(), moreThanComparer);
        }

        public static T[] Apply<T>(T[] source, Func<T, T, bool> moreThanComparer)
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
