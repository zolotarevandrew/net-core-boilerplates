using Algorithms.Comparers;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Algorithms.Tests")]
namespace Algorithms.Trees
{
    public class AVLTree<T> : IBinarySearchTree<T>
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

        AVLTree<T> Add(AVLTree<T> node, T item)
        {
            if (!node.HasValue)
            {
                node.Value = item;
                node.HasValue = true;
                SetHeight(node);
                return node;
            }

            var equality = Comparer.Compare(item, node.Value);
            if (equality.IsFirstLess)
            {
                node._left = Add(node._left ?? new AVLTree<T>(Comparer), item);
            }
            else if (equality.IsFirstMore)
            {
                node._right = Add(node._right ?? new AVLTree<T>(Comparer), item);
            }
            else return node;

            SetHeight(node);
            int balance = GetBalanceFactor(node);
            if (balance > 1 && IsLeftLeft(item, node))
                return RightRotate(node);

            if (balance < -1 && IsRightRight(item, node))
                return LeftRotate(node);

            if (balance > 1 && IsLeftRight(item, node))
                return LeftRightRotate(node);

            if (balance < -1 && IsRightLeft(item, node))
                return RightLeftRotate(node);

            return node;
        }

        bool IsLeftLeft(T item, AVLTree<T> node)
        {
            return Comparer.Compare(item, node._left.Value).IsFirstLess;
        }

        bool IsRightRight(T item, AVLTree<T> node)
        {
            return Comparer.Compare(item, node._right.Value).IsFirstMore;
        }

        bool IsLeftRight(T item, AVLTree<T> node)
        {
            return Comparer.Compare(item, node._left.Value).IsFirstMore;
        }

        bool IsRightLeft(T item, AVLTree<T> node)
        {
            return Comparer.Compare(item, node._right.Value).IsFirstLess;
        }

        void SetHeight(AVLTree<T> node)
        {
            node.Height = 1 + Math.Max(GetHeight(node._left), GetHeight(node._right));
        }

        int GetHeight(AVLTree<T> node)
        {
            if (node == null) return 0;
            return node.Height;
        }

        int GetBalanceFactor(AVLTree<T> node)
        {
            if (node == null)
                return 0;
            return GetHeight(node._left) - GetHeight(node._right);
        }

        AVLTree<T> LeftRotate(AVLTree<T> node)
        {
            var right = node._right;
            var rightLeft = right._left;
            right._left = node;
            node._right = rightLeft;
            SetHeight(node);
            SetHeight(right);
            return right;
        }

        AVLTree<T> RightRotate(AVLTree<T> node)
        {
            var left = node._left;
            var leftRight = left._right;
            left._right = node;
            node._left = leftRight;
            SetHeight(node);
            SetHeight(left);
            return left;
        }

        AVLTree<T> LeftRightRotate(AVLTree<T> node)
        {
            var left = LeftRotate(node._left);
            node._left = left;
            return RightRotate(node);
        }

        AVLTree<T> RightLeftRotate(AVLTree<T> node)
        {
            var right = RightRotate(node._right);
            node._right = right;
            return LeftRotate(node);
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
