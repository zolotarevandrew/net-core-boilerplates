using Algorithms.Comparers;

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

        public IDataComparer<T> Comparer { get; }
        public IBinarySearchTree<T> Left => _left;
        public IBinarySearchTree<T> Right => _right;

        public IBinarySearchTree<T> Add(T item)
        {
            return Add(this, item);
        }

        public IBinarySearchTree<T> Search(T item)
        {
            IBinarySearchTree<T> Search(IBinarySearchTree<T> node, T it)
            {
                if (node == null) return null;

                var equality = Comparer.Compare(it, node.Value);

                if (equality.IsEqual) return node;
                if (equality.IsFirstLess) return Search(node.Left, it);
                if (equality.IsFirstMore) return Search(node.Right, it);
                return null;
            }
            return Search(this, item);
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
    }
}
