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
        public T Value { get; set; }

        /// <summary>
        /// Reference to the left child node
        /// </summary>
        public BinaryTreeNode<T> Left { get; set; }

        /// <summary>
        /// Reference to the right child node
        /// </summary>
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode()
        {
            Value = default;
        }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }
    }
}
