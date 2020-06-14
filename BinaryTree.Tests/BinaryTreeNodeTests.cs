using Xunit;

namespace BinaryTree.Tests
{
    public class BinaryTreeNodeTests
    {
        [Theory]
        [MemberData(nameof(BinaryTreeNodeTestData.MemberData_Status), MemberType = typeof(BinaryTreeNodeTestData))]
        public void Status_ShouldReturnCorrectNodeStatus(BinaryTreeNode<int> node, BinaryTreeNodeStatus expectedStatus)
        {
            var result = node.Status;

            Assert.Equal(expectedStatus, result);
        }
    }
}
