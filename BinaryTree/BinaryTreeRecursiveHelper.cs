using System;

namespace BinaryTree
{
    /// <summary>
    /// Provides additional recursive methods for processing binary tree
    /// </summary>
    /// <typeparam name="T">Binary tree node data type</typeparam>
    static class BinaryTreeRecursiveHelper<T> where T : IComparable<T>
    {
        /// <summary>
        /// Recursively inserts node to binary tree into the right position, staring from specified root
        /// </summary>
        /// <param name="root">Starting (root) node for insertion</param>
        /// <param name="node">Node for insertion</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void InsertNode(ref BinaryTreeNode<T> root, BinaryTreeNode<T> node)
        {
            if (root == null)
                root = node;
            else
            {
                if (root.Value == null)
                    throw new ArgumentNullException(nameof(root.Value));
                if (node.Value == null)
                    throw new ArgumentNullException(nameof(node.Value));

                BinaryTreeNode<T> nextNode;

                if (root.Value.CompareTo(node.Value) < 0)
                {
                    nextNode = root.Right;
                    InsertNode(ref nextNode, node);
                    root.Right = nextNode;
                }
                else
                {
                    nextNode = root.Left;
                    InsertNode(ref nextNode, node);
                    root.Left = nextNode;
                }
            }
        }
    }
}
