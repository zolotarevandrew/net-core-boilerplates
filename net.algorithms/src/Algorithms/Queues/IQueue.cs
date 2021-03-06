﻿using System.Collections.Generic;

namespace Algorithms
{
    public interface IQueue<T>
    {
        int Count { get; }
        bool IsEmpty { get; }

        IEnumerator<T> GetEnumerator();
        void Enqueue(T item);
        bool TryDequeue(out T value);
        void Clear();
    }
}
