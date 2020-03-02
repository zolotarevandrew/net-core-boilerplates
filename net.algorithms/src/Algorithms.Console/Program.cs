using Algorithms.Comparers;
using Algorithms.Extensions;
using Algorithms.Trees;
using System;

namespace Algorithms.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree<int>(DataComparers.NewByType<int>());
            tree.AddNode(50);
            tree.AddNode(30);
            tree.AddNode(60);
            tree.AddNode(20);
            tree.AddNode(40);
            tree.AddNode(55);

            var newTree = tree.Clone();
            System.Console.ReadLine();
        }
    }
}
