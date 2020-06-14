using System.Collections.Generic;

namespace BinaryTree.Tests
{
    static class BinaryTreeNodeTestData
    {
        public static IEnumerable<object[]> MemberData_Status
        {
            get
            {
                var nodeWithZeroChildren = new BinaryTreeNode<int>()
                {
                    Left = null,
                    Right = null
                };

                var nodeWithLeftChild = new BinaryTreeNode<int>()
                {
                    Left = new BinaryTreeNode<int>(),
                    Right = null
                };

                var nodeWithRightChild = new BinaryTreeNode<int>()
                {
                    Left = null,
                    Right = new BinaryTreeNode<int>()
                };

                var nodeWithTwoChildren = new BinaryTreeNode<int>()
                {
                    Left = new BinaryTreeNode<int>(),
                    Right = new BinaryTreeNode<int>()
                };

                yield return new object[] { nodeWithZeroChildren, BinaryTreeNodeStatus.NodeWithZeroChildren };
                yield return new object[] { nodeWithLeftChild, BinaryTreeNodeStatus.NodeWithLeftChild };
                yield return new object[] { nodeWithRightChild, BinaryTreeNodeStatus.NodeWithRightChild };
                yield return new object[] { nodeWithTwoChildren, BinaryTreeNodeStatus.NodeWithTwoChildren };
            }
        }
    }
}
