using System;

namespace BinaryTree
{
    /// <summary>
    /// Represents a generic binary search tree
    /// </summary>
    /// <typeparam name="T">Binary tree node data type</typeparam>
    public class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
    {
        public BinaryTree()
        {
            Root = null;
            CountNodes = 0;
        }

        public BinaryTreeNode<T> Root { get; private set; }

        public int CountNodes { get; private set; }

        public void Insert(BinaryTreeNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            var currentRoot = Root;
            BinaryTreeRecursiveHelper<T>.InsertNode(ref currentRoot, node);
            Root = currentRoot;
            CountNodes++;
        }
    }
}
