using Algorithms.Comparers;
using Algorithms.Extensions;

namespace Algorithms.Trees
{
    public class BinarySearchTree<T> : IBinarySearchTree<T>
    {
        BinarySearchTree<T> _left = null;
        BinarySearchTree<T> _right = null;

        public BinarySearchTree(IDataComparer<T> comparer)
        {
            Comparer = comparer;
        }

        public T Value { get; private set; }
        public bool HasValue { get; private set; }

        public IDataComparer<T> Comparer { get; private set; }
        public IBinarySearchTree<T> Left => _left;
        public IBinarySearchTree<T> Right => _right;
        public int Height { get; private set; }

        public IBinarySearchTree<T> AddNode(T item)
        {
            return Add(this, item);
        }

        IBinarySearchTree<T> Add(BinarySearchTree<T> node, T item)
        {
            if (!node.HasValue)
            {
                SetValue(item);
                return node;
            }

            var equality = Comparer.Compare(item, node.Value);

            if (equality.IsFirstLess)
            {
                return TryAddItem(ref node._left, item);
            }
            if (equality.IsFirstMore)
            {
                return TryAddItem(ref node._right, item);
            }
            return node;
        }

        IBinarySearchTree<T> TryAddItem(ref BinarySearchTree<T> node, T item)
        {
            if (node == null)
            {
                var newNode = new BinarySearchTree<T>(Comparer);
                newNode.SetValue(item);
                node = newNode;
                return node;
            }
            return Add(node, item);
        }

        void SetValue(T item)
        {
            Value = item;
            HasValue = true;
        }

        public void Dispose()
        {
            this.PostOrder(v => RemoveNode(v));
        }

        public void RemoveNode(IBinarySearchTree<T> nd)
        {
            var node = nd as BinarySearchTree<T>;
            if (node == null) return;
            node.Value = default;
            node.HasValue = false;
            node._left = null;
            node._right = null;
            node.Comparer = null;
        }

        public IBinarySearchTree<T> CloneNode()
        {
            return new BinarySearchTree<T>(Comparer)
            {
                Value = Value,
                HasValue = HasValue,
                _left = _left,
                _right = _right,
            };
        }

    }
}
