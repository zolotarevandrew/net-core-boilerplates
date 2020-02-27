using System;
using Xunit;

namespace Algorithms.Tests
{
    public class CircularQueueTest
    {
        [Fact]
        public void TryDequeueEmpty_ShouldReturnFalse()
        {
            //Arrange
            var queue = new CircularQueue<int>(3);

            //Act
            int result;
            Assert.False(queue.TryDequeue(out result));
            Assert.Equal(-1, queue.Tail);
            Assert.Equal(-1, queue.Head);
            Assert.Equal(0, result);
            Assert.Equal(0, queue.Count);
        }

        [Fact]
        public void EnqueueIntoFull_ShouldReturnFalse()
        {
            //Arrange
            var queue = new CircularQueue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            //Act
            Assert.False(queue.Enqueue(4));
            Assert.Equal(2, queue.Tail);
            Assert.Equal(0, queue.Head);
            Assert.Equal(3, queue.Count);
        }

        [Fact]
        public void EnqueueDequeue_HeadMoreThanTail()
        {
            //Arrange
            var queue = new CircularQueue<int>(3);

            //Act
            Assert.True(queue.Enqueue(1));
            Assert.True(queue.Enqueue(2));
            Assert.True(queue.Enqueue(3));
            Assert.False(queue.Enqueue(4));

            int res;
            Assert.True(queue.TryDequeue(out res));
            Assert.Equal(1, res);
            Assert.Equal(1, queue.Head);
            Assert.Equal(2, queue.Tail);

            Assert.True(queue.Enqueue(3));
            Assert.Equal(1, queue.Head);
            Assert.Equal(0, queue.Tail);
            Assert.Equal(3, queue.Count);

        }
    }
}
