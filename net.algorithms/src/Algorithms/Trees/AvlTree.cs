using Algorithms.Comparers;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Algorithms.Tests")]
namespace Algorithms.Trees
{

    public interface IAVLTree<T> : IBinarySearchTree<T>
    {
        int Height { get; }
    }

    public class AVLTree<T> : IAVLTree<T>
    {
        AVLTree<T> _left = null;
        AVLTree<T> _right = null;

        public AVLTree(IDataComparer<T> comparer)
        {
            Comparer = comparer;
        }

        public T Value { get; private set; }
        public int Height { get; private set; }
        public bool HasValue { get; private set; }

        public IDataComparer<T> Comparer { get; private set; }
        public IBinarySearchTree<T> Left => _left;
        public IBinarySearchTree<T> Right => _right;

        public IBinarySearchTree<T> AddNode(T item)
        {
            return Add(this, item);
        }

        IBinarySearchTree<T> Add(AVLTree<T> node, T item)
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

        IBinarySearchTree<T> TryAddItem(ref AVLTree<T> node, T item)
        {
            if (node == null)
            {
                var newNode = new AVLTree<T>(Comparer);
                newNode.SetValue(item);
                node = newNode;
                return node;
            }
            return Add(node, item);
        }

        int GetHeight(AVLTree<T> node)
        {
            if (node == null) return 0;
            return node.Height;
        }

        int GetBalance(AVLTree<T> node)
        {
            if (node == null)
                return 0;
            return GetHeight(node._left) - GetHeight(node._right);
        }

        internal AVLTree<T> LeftRotate(AVLTree<T> node)
        {
            var right = node._right;
            var rightLeft = right._left;
            right._left = node;
            node._right = rightLeft;

            return right;
        }

        internal AVLTree<T> RightRotate(AVLTree<T> node)
        {
            var left = node._left;
            var leftRight = left._right;
            left._right = node;
            node._left = leftRight;
            return left;
        }

        internal AVLTree<T> LeftRightRotate(AVLTree<T> node)
        {
            var left = LeftRotate(node._left);
            node._left = left;
            return RightRotate(node);
        }

        internal AVLTree<T> RightLeftRotate(AVLTree<T> node)
        {
            var right = RightRotate(node._right);
            node._right = right;
            return LeftRotate(node);
        }

        void SetValue(T item)
        {
            Value = item;
            HasValue = true;
        }

        public IBinarySearchTree<T> CloneNode()
        {
            return new AVLTree<T>(Comparer)
            {
                Value = Value,
                HasValue = HasValue,
                _left = _left,
                _right = _right,
                Height = Height
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void RemoveNode(IBinarySearchTree<T> node)
        {
            throw new NotImplementedException();
        }
    }
}
