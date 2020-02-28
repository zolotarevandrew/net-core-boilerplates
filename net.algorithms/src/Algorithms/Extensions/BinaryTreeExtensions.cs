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
    }
}
