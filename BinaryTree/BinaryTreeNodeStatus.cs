namespace BinaryTree
{
    /// <summary>
    /// Binary search tree node statuses based on node subtrees
    /// </summary>
    public enum BinaryTreeNodeStatus
    {
        /// <summary>
        /// Node with left and right subtrees set to null (tree leaf)
        /// </summary>
        NodeWithZeroChildren,

        /// <summary>
        /// Node with not null left and null right subtrees
        /// </summary>
        NodeWithLeftChild,

        /// <summary>
        /// Node with not null right and null left subtrees
        /// </summary>
        NodeWithRightChild,
        
        /// <summary>
        /// Node with not null left and right subtrees
        /// </summary>
        NodeWithTwoChildren
    }
}
