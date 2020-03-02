using Algorithms.Comparers;
using Algorithms.Extensions;
using Algorithms.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithms.Tests.Trees
{
    public class BinarySearchTreeTest
    {
        [Fact]
        public void OneElement_SearchExistingElement()
        {
            //Arrange
            var tree = new BinarySearchTree<int>(DataComparers.NewByType<int>());
            tree.AddNode(50);

            //Act
            Assert.True(tree.Search(50) != null);
        }

        [Fact]
        public void SearchExistingElement()
        {
            //Arrange
            var tree = new BinarySearchTree<int>(DataComparers.NewByType<int>());
            var item = tree.AddNode(50);
            item = tree.AddNode(20);
            item = tree.AddNode(60);
            item = tree.AddNode(30);
            item = tree.AddNode(40);
            item = tree.AddNode(55);


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
            var tree = new BinarySearchTree<int>(DataComparers.NewByType<int>());
            tree.AddNode(50);
            tree.AddNode(20);
            tree.AddNode(60);
            tree.AddNode(30);
            tree.AddNode(40);
            tree.AddNode(55);


            //Act
            var inorder = new List<int>();
            tree.InOrder((v) => inorder.Add(v.Value));
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
            var tree = new BinarySearchTree<int>(DataComparers.NewByType<int>());
            tree.AddNode(50);
            tree.AddNode(20);
            tree.AddNode(60);
            tree.AddNode(30);
            tree.AddNode(40);
            tree.AddNode(55);


            //Act
            Assert.True(tree.Search(255) == null);
        }
    }
}
