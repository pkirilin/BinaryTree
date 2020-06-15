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

        /// <summary>
        /// Visits all tree nodes in post order and performs specified action for each node
        /// </summary>
        /// <param name="root">Starting node</param>
        /// <param name="action">Action to perform</param>
        public static void VisitNodesPostOrder(BinaryTreeNode<T> root, Action<BinaryTreeNode<T>> action)
        {
            if (root != null)
            {
                VisitNodesPostOrder(root.Left, action);
                VisitNodesPostOrder(root.Right, action);
                action(root);
            }
        }
    }
}
