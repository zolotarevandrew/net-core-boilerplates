using Algorithms.Comparers;
using System;

namespace Algorithms.Trees
{
    public interface IBinarySearchTree<T> : IDisposable
    {
        T Value { get; }
        bool HasValue { get; }
        int Height { get; }
        IDataComparer<T> Comparer { get; }
        IBinarySearchTree<T> Left { get; }
        IBinarySearchTree<T> Right { get; }

        IBinarySearchTree<T> AddNode(T item);
        void RemoveNode(IBinarySearchTree<T> node);
        IBinarySearchTree<T> CloneNode();
    }
}
