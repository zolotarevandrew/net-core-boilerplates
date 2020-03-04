using Algorithms.Comparers;
using Algorithms.Trees;
using Xunit;

namespace Algorithms.Tests.Trees
{
    public class AVLTreeTest
    {
        /*
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
        */

        [Fact]
        public void LL_ShouldRightRotate()
        {
            //Arrange
            IBinarySearchTree<int> tree = new AVLTree<int>(DataComparers.NewByType<int>());
            tree = tree.AddNode(30);
            tree = tree.AddNode(20);
            tree = tree.AddNode(10);


            //Act
            Assert.Equal(20, tree.Value);
            Assert.Equal(2, tree.Height);
            Assert.Equal(10, tree.Left.Value);
            Assert.Equal(1, tree.Left.Height);
            Assert.Equal(30, tree.Right.Value);
            Assert.Equal(1, tree.Right.Height);
        }

        [Fact]
        public void LLWithSubtrees_ShouldRightRotate()
        {
            //Arrange
            IBinarySearchTree<int> tree = new AVLTree<int>(DataComparers.NewByType<int>());
            tree = tree.AddNode(30);
            tree = tree.AddNode(35);
            tree = tree.AddNode(20);
            tree = tree.AddNode(25);
            tree = tree.AddNode(10);
            tree = tree.AddNode(5);


            //Act
            Assert.Equal(20, tree.Value);
            Assert.Equal(3, tree.Height);

            Assert.Equal(10, tree.Left.Value);
            Assert.Equal(2, tree.Left.Height);

            Assert.Equal(5, tree.Left.Left.Value);
            Assert.Equal(1, tree.Left.Left.Height);

            Assert.Equal(30, tree.Right.Value);
            Assert.Equal(2, tree.Right.Height);

            Assert.Equal(25, tree.Right.Left.Value);
            Assert.Equal(1, tree.Right.Left.Height);

            Assert.Equal(35, tree.Right.Right.Value);
            Assert.Equal(1, tree.Right.Right.Height);
        }

        [Fact]
        public void RR_ShouldLeftRotate()
        {
            //Arrange
            IBinarySearchTree<int> tree = new AVLTree<int>(DataComparers.NewByType<int>());
            tree = tree.AddNode(10);
            tree = tree.AddNode(20);
            tree = tree.AddNode(30);

            //Act
            Assert.Equal(20, tree.Value);
            Assert.Equal(2, tree.Height);
            Assert.Equal(10, tree.Left.Value);
            Assert.Equal(1, tree.Left.Height);
            Assert.Equal(30, tree.Right.Value);
            Assert.Equal(1, tree.Right.Height);
        }

        [Fact]
        public void RRWithSubtrees_ShouldLeftRotate()
        {
            //Arrange
            IBinarySearchTree<int> tree = new AVLTree<int>(DataComparers.NewByType<int>());
            tree = tree.AddNode(10);
            tree = tree.AddNode(5);
            tree = tree.AddNode(20);
            tree = tree.AddNode(15);
            tree = tree.AddNode(30);
            tree = tree.AddNode(35);


            //Act
            Assert.Equal(20, tree.Value);
            Assert.Equal(3, tree.Height);

            Assert.Equal(10, tree.Left.Value);
            Assert.Equal(2, tree.Left.Height);

            Assert.Equal(15, tree.Left.Right.Value);
            Assert.Equal(1, tree.Left.Right.Height);

            Assert.Equal(5, tree.Left.Left.Value);
            Assert.Equal(1, tree.Left.Left.Height);

            Assert.Equal(30, tree.Right.Value);
            Assert.Equal(2, tree.Right.Height);

            Assert.Equal(35, tree.Right.Right.Value);
            Assert.Equal(1, tree.Right.Right.Height);
        }

        [Fact]
        public void LR_ShouldLeftRightRotate()
        {
            //Arrange
            IBinarySearchTree<int> tree = new AVLTree<int>(DataComparers.NewByType<int>());
            tree = tree.AddNode(30);
            tree = tree.AddNode(10);
            tree = tree.AddNode(20);

            //Act
            Assert.Equal(20, tree.Value);
            Assert.Equal(2, tree.Height);

            Assert.Equal(10, tree.Left.Value);
            Assert.Equal(1, tree.Left.Height);

            Assert.Equal(30, tree.Right.Value);
            Assert.Equal(1, tree.Right.Height);
        }

        [Fact]
        public void LRWithSubtrees_ShouldLeftRightRotate()
        {
            //Arrange
            IBinarySearchTree<int> tree = new AVLTree<int>(DataComparers.NewByType<int>());
            tree = tree.AddNode(30);
            tree = tree.AddNode(10);
            tree = tree.AddNode(20);
            tree = tree.AddNode(15);

            //Act
            Assert.Equal(20, tree.Value);
            Assert.Equal(3, tree.Height);

            Assert.Equal(10, tree.Left.Value);
            Assert.Equal(2, tree.Left.Height);

            Assert.Equal(15, tree.Left.Right.Value);
            Assert.Equal(1, tree.Left.Right.Height);

            Assert.Equal(30, tree.Right.Value);
            Assert.Equal(1, tree.Right.Height);
        }

        [Fact]
        public void LRWithSubtreesAtRight_ShouldLeftRightRotate()
        {
            //Arrange
            IBinarySearchTree<int> tree = new AVLTree<int>(DataComparers.NewByType<int>());
            tree = tree.AddNode(30);
            tree = tree.AddNode(10);
            tree = tree.AddNode(20);
            tree = tree.AddNode(15);
            tree = tree.AddNode(25);

            //Act
            Assert.Equal(20, tree.Value);
            Assert.Equal(3, tree.Height);

            Assert.Equal(10, tree.Left.Value);
            Assert.Equal(2, tree.Left.Height);

            Assert.Equal(15, tree.Left.Right.Value);
            Assert.Equal(1, tree.Left.Right.Height);

            Assert.Equal(30, tree.Right.Value);
            Assert.Equal(2, tree.Right.Height);

            Assert.Equal(25, tree.Right.Left.Value);
            Assert.Equal(1, tree.Right.Left.Height);

        }

        [Fact]
        public void RL_ShouldRightLeftRotate()
        {
            //Arrange
            IBinarySearchTree<int> tree = new AVLTree<int>(DataComparers.NewByType<int>());
            tree = tree.AddNode(10);
            tree = tree.AddNode(30);
            tree = tree.AddNode(20);

            //Act
            Assert.Equal(20, tree.Value);
            Assert.Equal(2, tree.Height);

            Assert.Equal(10, tree.Left.Value);
            Assert.Equal(1, tree.Left.Height);

            Assert.Equal(30, tree.Right.Value);
            Assert.Equal(1, tree.Right.Height);
        }

        [Fact]
        public void RLWithSubtrees_ShouldRightLeftRotate()
        {
            //Arrange
            IBinarySearchTree<int> tree = new AVLTree<int>(DataComparers.NewByType<int>());
            tree = tree.AddNode(10);
            tree = tree.AddNode(30);
            tree = tree.AddNode(20);

            //Act
            Assert.Equal(20, tree.Value);
            Assert.Equal(2, tree.Height);

            Assert.Equal(10, tree.Left.Value);
            Assert.Equal(1, tree.Left.Height);

            Assert.Equal(30, tree.Right.Value);
            Assert.Equal(1, tree.Right.Height);
        }

        [Fact]
        public void CustomData_ShouldReturnCorrectTree()
        {
            //Arrange
            IBinarySearchTree<int> tree = new AVLTree<int>(DataComparers.NewByType<int>());
            tree = tree.AddNode(40);
            tree = tree.AddNode(20);
            tree = tree.AddNode(10);
            tree = tree.AddNode(25);
            tree = tree.AddNode(30);
            tree = tree.AddNode(22);
            tree = tree.AddNode(50);

            //Act
            Assert.Equal(25, tree.Value);
            Assert.Equal(3, tree.Height);

            Assert.Equal(20, tree.Left.Value);
            Assert.Equal(2, tree.Left.Height);

            Assert.Equal(10, tree.Left.Left.Value);
            Assert.Equal(1, tree.Left.Left.Height);

            Assert.Equal(22, tree.Left.Right.Value);
            Assert.Equal(1, tree.Left.Right.Height);

            Assert.Equal(40, tree.Right.Value);
            Assert.Equal(2, tree.Right.Height);

            Assert.Equal(30, tree.Right.Left.Value);
            Assert.Equal(1, tree.Right.Left.Height);

            Assert.Equal(50, tree.Right.Right.Value);
            Assert.Equal(1, tree.Right.Right.Height);
        }
    }
}
