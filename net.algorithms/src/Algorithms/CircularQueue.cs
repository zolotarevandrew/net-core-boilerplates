using System;

namespace Algorithms
{
    public interface ICircularQueue<T>
    {
        int Count { get; }
        int Head { get; }
        int Tail { get; }

        bool Enqueue(T item);
        bool TryDequeue(out T value);
        bool IsFull();
        void Clear();
    }

    public class CircularQueue<T> : ICircularQueue<T>
    {
        int _head, _tail;
        int _maxSize;
        T[] _queue;

        public CircularQueue(int size)
        {
            if (size < 1) throw new InvalidOperationException("Invalid size have passed");
            _maxSize = size;
            _queue = new T[size];
            Clear();
        }

        public int Count
        {
            get
            {
                if (IsEmpty()) return 0;

                if (_head <= _tail)
                {
                    return (_tail - _head) + 1;
                }
                return _maxSize - (_head - _tail) + 1;
            }
        }

        public int Head => _head;
        public int Tail => _tail;

        public bool Enqueue(T item)
        {
            if (IsFull())
            {
                return false;
            }

            if (_head == -1) _head = 0;
            _tail = IncrementIndex(_tail);
            _queue[_tail] = item;
            return true;
        }

        public bool TryDequeue(out T value)
        {
            if (IsEmpty())
            {
                value = default;
                return false;
            }
            value = _queue[_head];
            if (_head == _tail) Clear();
            else _head = IncrementIndex(_head);
            return true;
        }

        public bool IsFull()
        {
            bool isFullFromStart = _head == 0 && _tail == _maxSize - 1;
            bool isCircularFull = _head == _tail + 1;
            return isFullFromStart || isCircularFull;
        }

        public void Clear()
        {
            _head = -1;
            _tail = -1;
            _queue = new T[_maxSize];
        }

        bool IsEmpty()
        {
            return _head == -1;
        }

        int IncrementIndex(int idx)
        {
            return (idx + 1) % _maxSize;
        }
    }
}
