using Algorithms.Comparers;
using Algorithms.Extensions;
using Algorithms.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithms.Tests.Trees
{
    public class AVLTreeTest
    {

        [Fact]
        public void RightRotate()
        {
            //Arrange
            var tree = new AVLTree<int>(DataComparers.NewByType<int>());
            tree.AddNode(30);
            tree.AddNode(20);
            tree.AddNode(10);


            //Act
            var res = tree.RightRotate(tree);
            Assert.True(res.Value == 20);
            Assert.True(res.Left.Value == 10);
            Assert.True(res.Right.Value == 30);
        }

        [Fact]
        public void RightRotate_LeftHasRightSubtree()
        {
            //Arrange
            var tree = new AVLTree<int>(DataComparers.NewByType<int>());
            tree.AddNode(30);
            tree.AddNode(20);
            tree.AddNode(25);
            tree.AddNode(10);


            //Act
            var res = tree.RightRotate(tree);
            Assert.True(res.Value == 20);
            Assert.True(res.Left.Value == 10);
            Assert.True(res.Right.Value == 30);
            Assert.True(res.Right.Left.Value == 25);
        }

        [Fact]
        public void LeftRotate()
        {
            //Arrange
            var tree = new AVLTree<int>(DataComparers.NewByType<int>());
            tree.AddNode(10);
            tree.AddNode(20);
            tree.AddNode(30);


            //Act
            var res = tree.LeftRotate(tree);
            Assert.True(res.Value == 20);
            Assert.True(res.Left.Value == 10);
            Assert.True(res.Right.Value == 30);
        }

        [Fact]
        public void LeftRotate_RightHasLeftSubtree()
        {
            //Arrange
            var tree = new AVLTree<int>(DataComparers.NewByType<int>());
            tree.AddNode(10);
            tree.AddNode(20);
            tree.AddNode(15);
            tree.AddNode(30);


            //Act
            var res = tree.LeftRotate(tree);
            Assert.True(res.Value == 20);
            Assert.True(res.Left.Value == 10);
            Assert.True(res.Left.Right.Value == 15);
            Assert.True(res.Right.Value == 30);
        }

        [Fact]
        public void LeftRightRotate()
        {
            //Arrange
            var tree = new AVLTree<int>(DataComparers.NewByType<int>());
            tree.AddNode(30);
            tree.AddNode(10);
            tree.AddNode(20);
            tree.AddNode(15);
            tree.AddNode(25);

            //Act
            var res = tree.LeftRightRotate(tree);
            Assert.True(res.Value == 20);
            Assert.True(res.Right.Value == 30);
            Assert.True(res.Right.Left.Value == 25);

            Assert.True(res.Left.Value == 10);
            Assert.True(res.Left.Right.Value == 15);
        }

        [Fact]
        public void RightLeftRotate()
        {
            //Arrange
            var tree = new AVLTree<int>(DataComparers.NewByType<int>());
            tree.AddNode(10);
            tree.AddNode(30);
            tree.AddNode(20);
            tree.AddNode(15);
            tree.AddNode(35);

            //Act
            var res = tree.RightLeftRotate(tree);
            Assert.True(res.Value == 20);
            Assert.True(res.Left.Value == 10);
            Assert.True(res.Left.Right.Value == 15);
            Assert.True(res.Right.Value == 30);
            Assert.True(res.Right.Right.Value == 35);
        }
    }
}
