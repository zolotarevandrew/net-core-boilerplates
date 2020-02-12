using Xunit;

namespace Concurrent.Tests
{
    public class StackQueueTest
    {
        IQueue<int> _queue = new StackQueue<int>();

        [Fact]
        public void EnqueueFiveItems_ShouldHaveFiveItems()
        {
            //Arrange
            _queue.Clear();
            _queue.Enqueue(1);
            _queue.Enqueue(2);
            _queue.Enqueue(3);
            _queue.Enqueue(4);
            _queue.Enqueue(5);

            //Assert
            Assert.Equal(5, _queue.Count);
            Assert.False(_queue.IsEmpty);

            var res = -1;
            var isDequeued = _queue.TryDequeue(out res);
            Assert.True(isDequeued);
            Assert.Equal(1, res);

            isDequeued = _queue.TryDequeue(out res);
            Assert.True(isDequeued);
            Assert.Equal(2, res);

            isDequeued = _queue.TryDequeue(out res);
            Assert.True(isDequeued);
            Assert.Equal(3, res);

            isDequeued = _queue.TryDequeue(out res);
            Assert.True(isDequeued);
            Assert.Equal(4, res);

            isDequeued = _queue.TryDequeue(out res);
            Assert.True(isDequeued);
            Assert.Equal(5, res);

            isDequeued = _queue.TryDequeue(out res);
            Assert.False(isDequeued);
        }

        [Fact]
        public void EnqueueFiveItems_ShouldCorrectIterate()
        {
            //Arrange
            _queue.Clear();
            _queue.Enqueue(1);
            var a = 0;
            _queue.Enqueue(2);
            _queue.Enqueue(3);
            _queue.Enqueue(4);
            _queue.Enqueue(5);

            _queue.TryDequeue(out a);
            _queue.TryDequeue(out a);

            _queue.Enqueue(6);

            //Assert
            var curItem = 3;
            foreach (var item in _queue)
            {
                Assert.Equal(curItem, item);
                curItem++;
            }
        }

        [Fact]
        public void DequeueEmpty_ShouldReturnFalse()
        {
            //Arrange
            _queue.Clear();

            //Assert
            Assert.Equal(0, _queue.Count);
            Assert.True(_queue.IsEmpty);

            var res = -1;
            var isDequeued = _queue.TryDequeue(out res);
            Assert.False(isDequeued);
        }

        [Fact]
        public void EnqueueAndDequeue_ShouldBeEmpty()
        {
            //Arrange
            _queue.Clear();

            //Assert
            _queue.Enqueue(1);
            var res = -1;
            var isDequeued = _queue.TryDequeue(out res);
            Assert.True(isDequeued);
            Assert.Equal(1, res);

            Assert.True(_queue.IsEmpty);
            Assert.Equal(0, _queue.Count);
        }
    }
}
