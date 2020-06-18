using System;
using System.Collections.Generic;

namespace BinaryTree
{
    /// <summary>
    /// Provides specific methods for binary search tree
    /// </summary>
    /// <typeparam name="T">Binary tree node data type</typeparam>
    public interface IBinaryTree<T>
    {
        /// <summary>
        /// Binary tree root node
        /// </summary>
        BinaryTreeNode<T> Root { get; }

        /// <summary>
        /// Gets all tree nodes count
        /// </summary>
        int CountNodes { get; }

        /// <summary>
        /// Gets count of nodes with no children
        /// </summary>
        int CountLeafNodes { get; }

        /// <summary>
        /// Gets count of nodes having only one child
        /// </summary>
        int CountNotFullNodes { get; }

        /// <summary>
        /// Gets count of nodes having two children
        /// </summary>
        int CountFullNodes { get; }

        /// <summary>
        /// Gets tree height
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Inserts new node to binary tree
        /// </summary>
        /// <param name="value">New node's value</param>
        /// <exception cref="ArgumentNullException"></exception>
        void Insert(T value);

        /// <summary>
        /// Visits all tree nodes in direct order (from min to max node) and performs specified action for each node
        /// </summary>
        /// <param name="action">Action to perform</param>
        void VisitNodesInOrder(Action<BinaryTreeNode<T>> action);

        /// <summary>
        /// Visits all tree nodes in reverse order (from max to min node) and performs specified action for each node
        /// </summary>
        /// <param name="action">Action to perform</param>
        void VisitNodesInOrderReverse(Action<BinaryTreeNode<T>> action);

        /// <summary>
        /// Visits all tree nodes in pre order (from root to left and right, symmetric) and performs specified action for each node
        /// </summary>
        /// <param name="action">Action to perform</param>
        void VisitNodesPreOrder(Action<BinaryTreeNode<T>> action);

        /// <summary>
        /// Visits all tree nodes in post order and performs specified action for each node
        /// </summary>
        /// <param name="action">Action to perform</param>
        void VisitNodesPostOrder(Action<BinaryTreeNode<T>> action);

        /// <summary>
        /// Checks if tree contains at least one node with specified value
        /// </summary>
        /// <param name="value">Node value</param>
        bool ContainsValue(T value);

        /// <summary>
        /// Gets first entry of node with specified value or null if it doesn't exist
        /// </summary>
        /// <param name="value">Node value</param>
        BinaryTreeNode<T> GetNode(T value);

        /// <summary>
        /// Gets first entry of node with specified value or null if it doesn't exist
        /// </summary>
        /// <param name="value">Node value</param>
        /// <param name="parent">Found node's parent (null for root node)</param>
        BinaryTreeNode<T> GetNodeWithParent(T value, out BinaryTreeNode<T> parent);

        /// <summary>
        /// Deletes node with specified value from binary search tree
        /// </summary>
        /// <param name="value">Node value for delete</param>
        void Delete(T value);

        /// <summary>
        /// Deletes all nodes from tree
        /// </summary>
        void Clear();

        /// <summary>
        /// Gets absolute path starting from root to node with specified value, including target node
        /// </summary>
        /// <param name="value">Specified value</param>
        /// <returns>A sequence of node values starting from root to node with specified value</returns>
        /// <exception cref="ArgumentException"></exception>
        IEnumerable<T> GetAbsolutePathToNode(T value);

        /// <summary>
        /// Converts binary tree to its array representation.
        /// In this representation, for node with index i its children can be found at indices
        /// 2 * i + 1 (left child) and 2 * i + 2 (right child), while its parent - at index (i - 1) / 2.
        /// The result array size is equal to 2^(h + 1) - 1, where h is tree height
        /// </summary>
        /// <returns>Node values array</returns>
        T[] ToArray();
    }
}
