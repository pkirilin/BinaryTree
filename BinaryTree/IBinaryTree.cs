using System;

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
        /// Inserts new node to binary tree
        /// </summary>
        /// <param name="node">New node</param>
        /// <exception cref="ArgumentNullException"></exception>
        void Insert(BinaryTreeNode<T> node);
    }
}
