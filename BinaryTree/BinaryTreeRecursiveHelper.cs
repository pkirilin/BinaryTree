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

        /// <summary>
        /// Visits all tree nodes in direct order (from min to max node) and performs specified action for each node
        /// </summary>
        /// <param name="root">Starting node</param>
        /// <param name="action">Action to perform</param>
        public static void VisitNodesInOrder(BinaryTreeNode<T> root, Action<BinaryTreeNode<T>> action)
        {
            if (root != null)
            {
                VisitNodesInOrder(root.Left, action);
                action(root);
                VisitNodesInOrder(root.Right, action);
            }
        }

        /// <summary>
        /// Visits all tree nodes in reverse order (from max to min node) and performs specified action for each node
        /// </summary>
        /// <param name="root">Starting node</param>
        /// <param name="action">Action to perform</param>
        public static void VisitNodesInOrderReverse(BinaryTreeNode<T> root, Action<BinaryTreeNode<T>> action)
        {
            if (root != null)
            {
                VisitNodesInOrderReverse(root.Right, action);
                action(root);
                VisitNodesInOrderReverse(root.Left, action);
            }
        }

        /// <summary>
        /// Visits all tree nodes in pre order (from root to left and right, symmetric) and performs specified action for each node
        /// </summary>
        /// <param name="root">Starting node</param>
        /// <param name="action">Action to perform</param>
        public static void VisitNodesPreOrder(BinaryTreeNode<T> root, Action<BinaryTreeNode<T>> action)
        {
            if (root != null)
            {
                action(root);
                VisitNodesPreOrder(root.Left, action);
                VisitNodesPreOrder(root.Right, action);
            }
        }
    }
}
