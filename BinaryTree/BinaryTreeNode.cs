using System;

namespace BinaryTree
{
    /// <summary>
    /// Represents a binary tree node
    /// </summary>
    /// <typeparam name="T">Binary tree node data type</typeparam>
    public class BinaryTreeNode<T>
    {
        /// <summary>
        /// Node data
        /// </summary>
        public T Value { get; internal set; }

        /// <summary>
        /// Reference to the left child node
        /// </summary>
        public BinaryTreeNode<T> Left { get; internal set; }

        /// <summary>
        /// Reference to the right child node
        /// </summary>
        public BinaryTreeNode<T> Right { get; internal set; }

        /// <summary>
        /// Node status based on its children
        /// </summary>
        public BinaryTreeNodeStatus Status
        {
            get
            {
                if (Left == null && Right == null)
                    return BinaryTreeNodeStatus.NodeWithZeroChildren;
                if (Left != null && Right == null)
                    return BinaryTreeNodeStatus.NodeWithLeftChild;
                if (Left == null && Right != null)
                    return BinaryTreeNodeStatus.NodeWithRightChild;

                return BinaryTreeNodeStatus.NodeWithTwoChildren;
            }
        }

        public BinaryTreeNode()
        {
            Value = default;
        }

        public BinaryTreeNode(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Value = value;
        }
    }
}
