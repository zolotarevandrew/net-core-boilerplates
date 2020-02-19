using System.Collections.Generic;

namespace Algorithms
{
    public class StackQueue<T> : IQueue<T>
    {
        Stack<T> _head;
        Stack<T> _tail;

        public StackQueue()
        {
            _head = new Stack<T>();
            _tail = new Stack<T>();
        }

        public StackQueue(IEnumerable<T> items)
        {
            foreach (var item in items) 
                Enqueue(item);
        }

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public bool TryDequeue(out T val)
        {
            if (IsEmpty)
            {
                val = default;
                return false;
            }

            ReverseTailToHead();

            val = _head.Pop();
            Count--;
            return true;
        }

        private void ReverseTailToHead()
        {
            if (_head.Count == 0)
            {
                while (_tail.Count != 0)
                {
                    _head.Push(_tail.Pop());
                }
            }
        }

        public void Enqueue(T item)
        {
            _tail.Push(item);
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (IsEmpty) yield break;
            if (_head.Count > 0)
            {
                foreach (var item in _head)
                {
                    yield return item;
                }
            }
            else
            {
                ReverseTailToHead();
                foreach (var item in _head)
                {
                    yield return item;
                }
            }
        }

        public void Clear()
        {
            _head.Clear();
            _tail.Clear();
        }
    }
}
