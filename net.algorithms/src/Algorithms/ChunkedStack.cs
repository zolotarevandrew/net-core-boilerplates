using System;

namespace Algorithms
{
    public interface IChunkedStack<T>
    {
        int Count { get; }
        void Push(T item);
        T Pop();
    }

    public class ChunkedStack<T> : IChunkedStack<T>
    {
        const int CHUNK_DEFAULT_CAPACITY = 100;
        int _count = 0;
        int _chunkCapacity = 0;

        Chunk<T> _top;

        public ChunkedStack()
        {
            Init(CHUNK_DEFAULT_CAPACITY);
        }

        public ChunkedStack(int chunkCapacity)
        {
            if (chunkCapacity <= 0) throw new InvalidOperationException("Too little chunk capacity have passed");
            Init(chunkCapacity);
        }

        void Init(int chunkCapacity)
        {
            _chunkCapacity = chunkCapacity;
            _top = new Chunk<T>(_chunkCapacity);
        }

        public int Count => _count;

        public T Pop()
        {
            T item = _top.Pop();
            if (_top.IsEmpty)
            {
                var next = _top.Prev;
                if (next != null) _top = next;
            }
            _count--;
            return item;
        }

        public void Push(T item)
        {
            if (_top.IsFull)
            {
                var newTop = new Chunk<T>(_chunkCapacity)
                {
                    Prev = _top
                };
                _top = newTop;
            }

            _top.Push(item);
            _count++;
        }

        class Chunk<TItem>
        {
            int _size;
            int _count;
            public Chunk(int size)
            {
                _size = size;
                _count = 0;
                Data = new TItem[size];
            }

            public TItem[] Data { get; }
            public Chunk<TItem> Prev { get; set; }
            public bool IsFull => _count == _size;
            public bool IsEmpty => _count == 0;

            public void Push(TItem item)
            {
                int top = _count;
                Data[top] = item;
                _count++;
            }

            public TItem Pop()
            {
                if (IsEmpty) throw new InvalidOperationException("Stack is empty");
                TItem item = Data[_count - 1];
                Data[_count - 1] = default;
                _count--;
                return item;
            }
        }
    }
}
