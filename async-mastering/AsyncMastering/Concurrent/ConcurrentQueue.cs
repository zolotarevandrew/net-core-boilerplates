using System;
using System.Collections.Generic;
using System.Threading;

namespace Concurrent
{
    public class ConcurrentQueue<T> : IQueue<T>
    {
        object _lock;
        IQueue<T> _source;

        public int Count
        {
            get
            {
                lock(_lock)
                {
                    return _source.Count;
                }
            }
        }
        public bool IsEmpty => Count == 0;

        public ConcurrentQueue(IQueue<T> source)
        {
            _lock = new object();
            _source = source;
        }

        public void Clear()
        {
            lock (_lock)
            {
                _source.Clear();
            }
        }

        public void Enqueue(T item)
        {
            lock (_lock)
            {
                _source.Enqueue(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            lock (_lock)
            {
                return _source.GetEnumerator();
            }
        }

        public bool TryDequeue(out T value)
        {
            try
            {
                if (!Monitor.TryEnter(_lock, TimeSpan.FromMilliseconds(50)))
                {
                    value = default;
                    return false;
                }
                var result = _source.TryDequeue(out value);
                return result;
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
    }
}
