using Algorithms.Comparers;

namespace Algorithms.Trees
{
    public class AVLTree<T> : IBinarySearchTree<T>
    {
        byte _height;
        AVLTree<T> _left;
        AVLTree<T> _right;

        public AVLTree(IDataComparer<T> comparer)
        {
            Comparer = comparer;
        }

        public T Value { get; private set; }
        public bool HasValue { get; private set; }
        public IDataComparer<T> Comparer { get; }
        public IBinarySearchTree<T> Left => _left;
        public IBinarySearchTree<T> Right => _right;

        public IBinarySearchTree<T> Add(T item)
        {
            return this;
        }

        byte BalanceFactor(AVLTree<T> node)
        {
            
        }
    }
}
