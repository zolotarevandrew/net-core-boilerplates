using System.Collections.Generic;
using Xunit;
using Algorithms.Extensions;
using Algorithms.Sortings;
using Algorithms.Comparers;

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
            var sorted = data.ApplyBubbleSort(DataComparers.Int);
            var res = sorted.BinarySearch(7, DataComparers.Int);

            //Assert
            Assert.True(res);
        }
    }
}
