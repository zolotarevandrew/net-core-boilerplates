using Algorithms.Trees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Extensions
{
    public static class BinaryTreeExtensions 
    {
        public static IEnumerable<T> InOrder<T>(this IBinarySearchTree<T> tree)
        {
            IEnumerable<T> InOrder(IBinarySearchTree<T> node)
            {
                if (node != null)
                {
                    foreach (var it in InOrder(node.Left)) yield return it;
                    yield return node.Value;
                    foreach (var it in InOrder(node.Right)) yield return it;
                }
            }
            return InOrder(tree);
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
