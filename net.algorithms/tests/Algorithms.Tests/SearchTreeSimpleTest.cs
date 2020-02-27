using Algorithms.Extensions;
using System;
using System.Linq;
using Xunit;

namespace Algorithms.Tests
{
    public class SearchTreeSimpleTest
    {
        [Fact]
        public void OneElement_SearchExistingElement()
        {
            //Arrange
            Func<int, int, EqualityKind> comparer = (t, t1) =>
            {
                if (t == t1) return EqualityKind.Equal;
                if (t > t1) return EqualityKind.Less;
                return EqualityKind.More;
            };
            var tree = new SearchTreeSimple<int>(comparer);
            tree.Add(50);


            //Act
            Assert.True(tree.Search(50) != null);
        }

        [Fact]
        public void SearchExistingElement()
        {
            //Arrange
            Func<int, int, EqualityKind> comparer = (t, t1) =>
            {
                if (t == t1) return EqualityKind.Equal;
                if (t > t1) return EqualityKind.Less;
                return EqualityKind.More;
            };
            var tree = new SearchTreeSimple<int>(comparer);
            var item = tree.Add(50);
            item = tree.Add(20);
            item = tree.Add(60);
            item = tree.Add(30);
            item = tree.Add(40);
            item = tree.Add(55);


            //Act
            var res = tree.Search(50);
            Assert.True(res != null);
            res = tree.Search(20);
            Assert.True(res != null);
            res = tree.Search(60);
            Assert.True(res != null);
            res = tree.Search(30);
            Assert.True(res != null);
            res = tree.Search(40);
            Assert.True(res != null);
            res = tree.Search(55);
            Assert.True(res != null);
        }

        [Fact]
        public void InOrder()
        {
            //Arrange
            Func<int, int, EqualityKind> comparer = (t, t1) =>
            {
                if (t == t1) return EqualityKind.Equal;
                if (t > t1) return EqualityKind.Less;
                return EqualityKind.More;
            };
            var tree = new SearchTreeSimple<int>(comparer);
            tree.Add(50);
            tree.Add(20);
            tree.Add(60);
            tree.Add(30);
            tree.Add(40);
            tree.Add(55);


            //Act
            var inorder = tree.InOrder().ToList();
            Assert.Equal(6, inorder.Count);
            Assert.Equal(20, inorder[0]);
            Assert.Equal(30, inorder[1]);
            Assert.Equal(40, inorder[2]);
            Assert.Equal(50, inorder[3]);
            Assert.Equal(55, inorder[4]);
            Assert.Equal(60, inorder[5]);
        }

        [Fact]
        public void SearchNotExistingElement()
        {
            //Arrange
            Func<int, int, EqualityKind> comparer = (t, t1) =>
            {
                if (t == t1) return EqualityKind.Equal;
                if (t > t1) return EqualityKind.Less;
                return EqualityKind.More;
            };
            var tree = new SearchTreeSimple<int>(comparer);
            tree.Add(50);
            tree.Add(20);
            tree.Add(60);
            tree.Add(30);
            tree.Add(40);
            tree.Add(55);


            //Act
            Assert.True(tree.Search(255) == null);
        }
    }
}
