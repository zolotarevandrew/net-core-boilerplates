using Algorithms.Extensions;
using Algorithms.Sortings;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithms.Tests.Sortings
{
    public class HeapSortingTest
    {
        [Fact]
        public void SortedData_Apply_ShouldReturnSortedData()
        {
            //Arrange
            var data = new List<int>
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };

            //Act
            var res = data.HeapSort((it1, it2) => it1 > it2);

            //Assert
            Assert.True(data.SequenceEqual(res));
        }

        [Fact]
        public void UnsortedData_Apply_ShouldReturnSortedData()
        {
            //Arrange
            var data = new List<int>
            {
                13, 3, 8, 1, 15, 2, 3, 7
            };

            //Act
            var res = data.HeapSort((it1, it2) => it1 > it2);

            //Assert
            data.Sort();
            Assert.True(data.SequenceEqual(res));
        }
    }
}
