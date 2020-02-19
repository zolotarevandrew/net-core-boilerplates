using Algorithms.Extensions;
using Algorithms.Sortings;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithms.Tests.Sortings
{
    public class QuickSortingTest
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
            var res = data.QuickSort((it1, it2) =>
            {
                if (it1 == it2) return EqualityKind.Equal;
                if (it1 < it2) return EqualityKind.Less;
                return EqualityKind.More;
            });

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
            var res = data.QuickSort((it1, it2) =>
            {
                if (it1 == it2) return EqualityKind.Equal;
                if (it1 < it2) return EqualityKind.Less;
                return EqualityKind.More;
            });

            //Assert
            data.Sort();
            Assert.True(data.SequenceEqual(res));
        }
    }
}
