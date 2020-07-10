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
        public static void TraversalInOrder(BinaryTreeNode<T> root, Action<BinaryTreeNode<T>> action)
        {
            if (root != null)
            {
                TraversalInOrder(root.Left, action);
                action(root);
                TraversalInOrder(root.Right, action);
            }
        }

        /// <summary>
        /// Visits all tree nodes in reverse order (from max to min node) and performs specified action for each node
        /// </summary>
        /// <param name="root">Starting node</param>
        /// <param name="action">Action to perform</param>
        public static void TraversalInOrderReverse(BinaryTreeNode<T> root, Action<BinaryTreeNode<T>> action)
        {
            if (root != null)
            {
                TraversalInOrderReverse(root.Right, action);
                action(root);
                TraversalInOrderReverse(root.Left, action);
            }
        }

        /// <summary>
        /// Visits all tree nodes in pre order (from root to left and right, symmetric) and performs specified action for each node
        /// </summary>
        /// <param name="root">Starting node</param>
        /// <param name="action">Action to perform</param>
        public static void TraversalPreOrder(BinaryTreeNode<T> root, Action<BinaryTreeNode<T>> action)
        {
            if (root != null)
            {
                action(root);
                TraversalPreOrder(root.Left, action);
                TraversalPreOrder(root.Right, action);
            }
        }

        /// <summary>
        /// Visits all tree nodes in post order and performs specified action for each node
        /// </summary>
        /// <param name="root">Starting node</param>
        /// <param name="action">Action to perform</param>
        public static void TraversalPostOrder(BinaryTreeNode<T> root, Action<BinaryTreeNode<T>> action)
        {
            if (root != null)
            {
                TraversalPostOrder(root.Left, action);
                TraversalPostOrder(root.Right, action);
                action(root);
            }
        }

        /// <summary>
        /// Gets max tree depth
        /// </summary>
        /// <param name="root">Starting node</param>
        /// <param name="curLevelIndex">Index of current node's level</param>
        /// <param name="maxDepth">Calculated max depth</param>
        public static void GetMaxDepth(BinaryTreeNode<T> root, int curLevelIndex, ref int maxDepth)
        {
            if (root != null)
            {
                if (curLevelIndex > 0 && curLevelIndex > maxDepth)
                    maxDepth = curLevelIndex;

                GetMaxDepth(root.Left, curLevelIndex + 1, ref maxDepth);
                GetMaxDepth(root.Right, curLevelIndex + 1, ref maxDepth);
            }
        }

        /// <summary>
        /// Fills an array representation of binary tree with node values
        /// </summary>
        /// <param name="root">Starting node</param>
        /// <param name="array">Array representation of binary tree</param>
        /// <param name="index">Current array index</param>
        public static void ToArray(BinaryTreeNode<T> root, T[] array, int index)
        {
            if (root != null)
            {
                array[index] = root.Value;
                ToArray(root.Left, array, 2 * index + 1);
                ToArray(root.Right, array, 2 * index + 2);
            }
        }
    }
}
