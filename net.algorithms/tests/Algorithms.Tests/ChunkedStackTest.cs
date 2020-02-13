using System;
using Xunit;

namespace Algorithms.Tests
{
    public class ChunkedStackTest
    {
        [Fact]
        public void Push_MoreThanCapacity_ShouldNotThrowException()
        {
            //Arrange
            var stack = new ChunkedStack<int>(2);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);

            //Act
            Assert.Equal(6, stack.Count);
            stack.Push(6);
            stack.Push(7);
            stack.Push(8);
            Assert.Equal(9, stack.Count);
        }

        [Fact]
        public void Pop_EmptyStack_ShouldThrowException()
        {
            //Arrange
            var stack = new ChunkedStack<int>(5);

            //Act
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void PushPop_ShouldReturnCorrectData()
        {
            //Arrange
            var stack = new ChunkedStack<int>(2);

            //Act
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Assert.Equal(5, stack.Count);

            Assert.Equal(5, stack.Pop());
            Assert.Equal(4, stack.Pop());
            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());

            Assert.Equal(0, stack.Count);
        }
    }
}
