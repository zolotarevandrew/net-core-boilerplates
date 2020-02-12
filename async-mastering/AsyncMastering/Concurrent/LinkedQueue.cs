using System.Collections.Generic;

namespace Concurrent
{
    public class LinkedQueue<T> : IQueue<T>
    {
        LinkedItem<T> _head = null;
        LinkedItem<T> _tail = null;

        public LinkedQueue()
        {

        }

        public LinkedQueue(IEnumerable<T> items)
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
            var head = _head;
            var result = head.Value;

            var prev = head.Prev;
            _head = prev;

            Count--;

            if (IsEmpty)
            {
                _head = _tail;
            }

            val = result;
            return true;
        }

        public void Enqueue(T item)
        {
            if (IsEmpty)
            {
                _head = new LinkedItem<T>(item);
                _tail = _head;
            } else
            {
                var newTail = new LinkedItem<T>(item);
                var oldTail = _tail;
                oldTail.Prev = newTail;
                _tail = newTail;
            }
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (IsEmpty) yield break;
            var current = _head;
            while(current != null)
            {
               yield return current.Value;
               current = current.Prev;
            }
        }

        public void Clear()
        {
            _head = null;
            _tail = _head;
        }

        class LinkedItem<TItem>
        {
            public TItem Value { get; }
            public LinkedItem<TItem> Prev { get; set; }

            public LinkedItem(TItem val)
            {
                Value = val;
            }
        }
    }
}
