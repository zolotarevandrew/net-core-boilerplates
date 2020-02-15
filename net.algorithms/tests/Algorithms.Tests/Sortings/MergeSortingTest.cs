using Algorithms.Sortings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Algorithms.Tests.Sortings
{
    public class MergeSortingTest
    {
        [Fact]
        public void EqualArrayLengths_MergeByMinElements_ShouldReturnCorrectData()
        {
            //Arrange
            var arr1 = new List<int>
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };
            var arr2 = new List<int>
            {
                5, 9, 8, 5, 1, 2, 11, 5, 1
            };

            //Act
            var res = arr1.MergeByMinElements(arr2, (it1, it2) => it1 > it2);

            //Assert
            Assert.Equal(arr1.Count, res.Count());
            Assert.True(new List<int>
            {
                1, 2, 3, 4, 1, 2, 7, 5, 1
            }.SequenceEqual(res));
        }

        [Fact]
        public void FirstEmptyAndSecondNotEmpty_MergeByMinElements_ShouldReturnCorrectData()
        {
            //Arrange
            var arr1 = new List<int>
            {
                
            };
            var arr2 = new List<int>
            {
                5, 9, 8, 5, 1, 2, 11, 5, 1
            };

            //Act
            var res = arr1.MergeByMinElements(arr2, (it1, it2) => it1 > it2);

            //Assert
            Assert.Equal(arr2.Count, res.Count());
            Assert.True(arr2.SequenceEqual(res));
        }

        [Fact]
        public void SecondEmptyAndFirstNotEmpty_MergeByMinElements_ShouldReturnCorrectData()
        {
            //Arrange
            var arr1 = new List<int>
            {

            };
            var arr2 = new List<int>
            {
                5, 9, 8, 5, 1, 2, 11, 5, 1
            };

            //Act
            var res = arr2.MergeByMinElements(arr1, (it1, it2) => it1 > it2);

            //Assert
            Assert.Equal(arr2.Count, res.Count());
            Assert.True(arr2.SequenceEqual(res));
        }

        [Fact]
        public void FirstLengthMoreThanSecond_MergeByMinElements_ShouldReturnCorrectData()
        {
            //Arrange
            var arr1 = new List<int>
            {
                5, 9, 8, 5, 1, 2, 11, 5, 1
            };
            var arr2 = new List<int>
            {
                1, 2, 3
            };

            //Act
            var res = arr1.MergeByMinElements(arr2, (it1, it2) => it1 > it2);

            //Assert
            Assert.Equal(arr1.Count, res.Count());
            Assert.True(new List<int>
            {
                1, 2, 3, 5, 1, 2, 11, 5, 1
            }.SequenceEqual(res));
        }

        [Fact]
        public void SecondLengthMoreThanFirst_MergeByMinElements_ShouldReturnCorrectData()
        {
            //Arrange
            var arr1 = new List<int>
            {
                5, 9, 8, 5, 1, 2, 11, 6
            };
            var arr2 = new List<int>
            {
                1, 2, 3
            };

            //Act
            var res = arr2.MergeByMinElements(arr1, (it1, it2) => it1 > it2);

            //Assert
            Assert.Equal(arr1.Count, res.Count());
            Assert.True(new List<int>
            {
                1, 2, 3, 5, 1, 2, 11, 6
            }.SequenceEqual(res));
        }

        [Fact]
        public void SortedData_Apply_ShouldReturnSortedData()
        {
            //Arrange
            var data = new List<int>
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };

            //Act
            var res = data.SortByMerge((it1, it2) => it1 > it2);

            //Assert
            Assert.True(data.SequenceEqual(res));
        }

        [Fact]
        public void UnsortedData_Apply_ShouldReturnSortedData()
        {
            //Arrange
            var data = new List<int>
            {
                5, 6, 7, 8, 9, 10, 11, 12, 10, 9, 5
            };

            //Act
            var res = data.SortByMerge((it1, it2) => it1 > it2);

            //Assert
            data.Sort();
            Assert.True(data.SequenceEqual(res));
        }
    }
}
