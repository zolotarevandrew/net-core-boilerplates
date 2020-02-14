using System.Collections.Generic;
using Xunit;
using Algorithms.Extensions;
using Algorithms.Sortings;

namespace Algorithms.Tests.Extensions
{
    public class ArrayExtensionsTest
    {
        [Fact]
        public void SortedArray_BinarySearch_ShouldFindElement()
        {
            //Arrange
            var data = new List<int>
            {
                5, 6, 7, 8, 9, 10, 11, 12, 10, 9, 5
            };

            //Act
            var sorted = BubbleSort.Apply(data, (it1, it2) => it1 > it2);
            var res = sorted.BinarySearch(7, (it1, it2) =>
            {
                if (it1 == it2) return EqualityKind.Equal;
                if (it1 < it2) return EqualityKind.Less;
                return EqualityKind.More;
            });

            //Assert
            Assert.True(res);
        }
    }
}
