using Algorithms.Comparers;

namespace Algorithms.Trees
{
    public interface IBinarySearchTree<T>
    {
        T Value { get; }
        bool HasValue { get; }
        IDataComparer<T> Comparer { get; }
        IBinarySearchTree<T> Left { get; }
        IBinarySearchTree<T> Right { get; }

        IBinarySearchTree<T> Add(T item);
    }
}
