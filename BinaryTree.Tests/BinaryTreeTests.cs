using System;
using Xunit;

namespace BinaryTree.Tests
{
    public class BinaryTreeTests
    {
        [Fact]
        public void Insert_ShouldThrowException_WhenNodeParameterIsNull()
        {
            var tree = SetupTestTree();

            Assert.Throws<ArgumentNullException>(() =>
            {
                tree.Insert(null);
            });
        }

        [Fact]
        public void Insert_ShouldInsertNode()
        {
            var tree = new BinaryTree<int>();
            var nodeToAdd1 = new BinaryTreeNode<int>(50);
            var nodeToAdd2 = new BinaryTreeNode<int>(70);
            var nodeToAdd3 = new BinaryTreeNode<int>(20);
            var nodeToAdd4 = new BinaryTreeNode<int>(60);
            var nodeToAdd5 = new BinaryTreeNode<int>(80);
            var nodeToAdd6 = new BinaryTreeNode<int>(10);
            var nodeToAdd7 = new BinaryTreeNode<int>(30);

            var nodesToAdd = new List<BinaryTreeNode<int>>
            {
                nodeToAdd1,
                nodeToAdd2,
                nodeToAdd3,
                nodeToAdd4,
                nodeToAdd5,
                nodeToAdd6,
                nodeToAdd7,
            };

            foreach (var node in nodesToAdd)
                tree.Insert(node);

            Assert.Equal(nodeToAdd1, tree.Root);
            Assert.Equal(nodeToAdd2, tree.Root.Right);
            Assert.Equal(nodeToAdd3, tree.Root.Left);
            Assert.Equal(nodeToAdd4, tree.Root.Right.Left);
            Assert.Equal(nodeToAdd5, tree.Root.Right.Right);
            Assert.Equal(nodeToAdd6, tree.Root.Left.Left);
            Assert.Equal(nodeToAdd7, tree.Root.Left.Right);
            Assert.Equal(7, tree.CountNodes);
        }

        [Fact]
        public void CountNodes_ShouldBeZeroByDefault()
        {
            var tree = new BinaryTree<int>();

            Assert.Equal(0, tree.CountNodes);
        }
    }
}
