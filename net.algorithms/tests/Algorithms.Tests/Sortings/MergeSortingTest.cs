using Algorithms.Sortings;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithms.Tests.Sortings
{
    public class MergeSortingTest
    {
        [Fact]
        public void OneElement_MergeByMinElements_ShouldReturnCorrectData()
        {
            //Arrange
            var arr1 = new List<int>
            {
                3
            }.ToArray();

            //Act
            arr1.MergeByMinElements(0, 0, arr1.Length - 1, (it1, it2) => it1 > it2);

            //Assert
            Assert.Single(arr1);
            Assert.True(new List<int>
            {
               3
            }.SequenceEqual(arr1));
        }

        [Fact]
        public void TwoElements_MergeByMinElements_ShouldReturnCorrectData()
        {
            //Arrange
            var arr1 = new List<int>
            {
                3, 2
            }.ToArray();

            //Act
            arr1.MergeByMinElements(0, 0, arr1.Length - 1, (it1, it2) => it1 > it2);

            //Assert
            Assert.Equal(2, arr1.Length);
            Assert.True(new List<int>
            {
                2, 3
            }.SequenceEqual(arr1));
        }

        [Fact]
        public void FourElements_MergeByMinElements_ShouldReturnCorrectData()
        {
            //Arrange
            var arr1 = new List<int>
            {
                8, 9, 4, 5
            }.ToArray();

            //Act
            arr1.MergeByMinElements(0, 1, arr1.Length - 1, (it1, it2) => it1 > it2);

            //Assert
            Assert.Equal(4, arr1.Length);
            Assert.True(new List<int>
            {
                4, 5, 8, 9
            }.SequenceEqual(arr1));
        }


        [Fact]
        public void FiveElements_MergeByMinElements_ShouldReturnCorrectData()
        {
            //Arrange
            var arr1 = new List<int>
            {
                8, 9, 4, 5, 9
            }.ToArray();

            //Act
            arr1.MergeByMinElements(0, 1, arr1.Length - 1, (it1, it2) => it1 > it2);

            //Assert
            Assert.Equal(5, arr1.Length);
            Assert.True(new List<int>
            {
                4, 5, 8, 9, 9
            }.SequenceEqual(arr1));
        }

        [Fact]
        public void EightElements_MergeByMinElements_ShouldReturnCorrectData()
        {
            //Arrange
            var arr1 = new List<int>
            {
                5, 6, 7, 9,  1, 3, 4, 5
            }.ToArray();

            //Act
            arr1.MergeByMinElements(0, 3, arr1.Length - 1, (it1, it2) => it1 > it2);

            //Assert
            Assert.Equal(8, arr1.Length);
            Assert.True(new List<int>
            {
                1, 3, 4, 5, 5, 6, 7, 9
            }.SequenceEqual(arr1));
        }

        [Fact]
        public void NineElements_MergeByMinElements_ShouldReturnCorrectData()
        {
            //Arrange
            var arr1 = new List<int>
            {
                5, 6, 7, 9,  1, 3, 4, 9, 10
            }.ToArray();

            //Act
            arr1.MergeByMinElements(0, 3, arr1.Length - 1, (it1, it2) => it1 > it2);

            //Assert
            Assert.Equal(9, arr1.Length);
            Assert.True(new List<int>
            {
                1, 3, 4, 5, 6, 7, 9, 9, 10
            }.SequenceEqual(arr1));
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
                13, 3, 8, 1, 15, 2, 3, 7
            };

            //Act
            var res = data.SortByMerge((it1, it2) => it1 > it2);

            //Assert
            data.Sort();
            Assert.True(data.SequenceEqual(res));
        }
    }
}
