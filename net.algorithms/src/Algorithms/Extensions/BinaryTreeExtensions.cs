using Algorithms.Trees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Extensions
{
    public static class BinaryTreeExtensions 
    {
        public static void InOrder<T>(this IBinarySearchTree<T> tree, Action<IBinarySearchTree<T>> action)
        {
            void InOrderInternal(IBinarySearchTree<T> node)
            {
                if (node != null)
                {
                    InOrderInternal(node.Left);
                    action(node);
                    InOrderInternal(node.Right);
                }
            }
            InOrderInternal(tree);
        }

        public static void PreOrder<T>(this IBinarySearchTree<T> tree, Action<IBinarySearchTree<T>> action)
        {
            void PreOrderInternal(IBinarySearchTree<T> node)
            {
                if (node != null)
                {
                    action(node);
                    PreOrderInternal(node.Left);
                    PreOrderInternal(node.Right);
                }
            }
            PreOrderInternal(tree);
        }

        public static void PostOrder<T>(this IBinarySearchTree<T> tree, Action<IBinarySearchTree<T>> action)
        {
            void PostOrderInternal(IBinarySearchTree<T> node)
            {
                if (node != null)
                {
                    PostOrderInternal(node.Left);
                    PostOrderInternal(node.Right);
                    action(node);
                }
            }
            PostOrderInternal(tree);
        }

        public static IBinarySearchTree<T> Clone<T>(this IBinarySearchTree<T> tree)
        {
            var newTree = tree.CloneNode();
            tree.PostOrder(v => v.CloneNode());
            return newTree;
        }

        public static IBinarySearchTree<T> Search<T>(this IBinarySearchTree<T> tree, T item)
        {
            IBinarySearchTree<T> Search(IBinarySearchTree<T> node, T it)
            {
                if (node == null) return null;

                var equality = tree.Comparer.Compare(it, node.Value);

                if (equality.IsEqual) return node;
                if (equality.IsFirstLess) return Search(node.Left, it);
                if (equality.IsFirstMore) return Search(node.Right, it);
                return null;
            }
            return Search(tree, item);
        }
    }
}
