﻿using System;

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
        BinaryTreeNode<T> Root { get; set; }

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
    }
}
