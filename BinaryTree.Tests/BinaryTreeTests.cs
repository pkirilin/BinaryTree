using System;
using System.Collections.Generic;
using Xunit;

namespace BinaryTree.Tests
{
    public class BinaryTreeTests
    {
        private IBinaryTree<int> SetupTestTree()
        {
            //             50
            //            /  \
            //           /    \
            //          /      \
            //         /        \
            //        20        70
            //       /  \      /
            //      /    \    /
            //     10    30  60
            //       \
            //       15

            var node50 = new BinaryTreeNode<int>(50);
            var node70 = new BinaryTreeNode<int>(70);
            var node20 = new BinaryTreeNode<int>(20);
            var node60 = new BinaryTreeNode<int>(60);
            var node10 = new BinaryTreeNode<int>(10);
            var node30 = new BinaryTreeNode<int>(30);
            var node15 = new BinaryTreeNode<int>(15);

            node50.Left = node20;
            node50.Right = node70;
            node20.Left = node10;
            node20.Right = node30;
            node70.Left = node60;
            node10.Right = node15;

            return new BinaryTree<int>()
            {
                Root = node50
            };
        }

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

        [Fact]
        public void VisitNodesInOrder_ShouldPassTreeFromMinToMaxNode()
        {
            var tree = SetupTestTree();
            var nodesInOrderList = new List<BinaryTreeNode<int>>();

            tree.VisitNodesInOrder(node =>
            {
                nodesInOrderList.Add(node);
            });

            Assert.Equal(nodesInOrderList[0], tree.Root.Left.Left);
            Assert.Equal(nodesInOrderList[1], tree.Root.Left.Left.Right);
            Assert.Equal(nodesInOrderList[2], tree.Root.Left);
            Assert.Equal(nodesInOrderList[3], tree.Root.Left.Right);
            Assert.Equal(nodesInOrderList[4], tree.Root);
            Assert.Equal(nodesInOrderList[5], tree.Root.Right.Left);
            Assert.Equal(nodesInOrderList[6], tree.Root.Right);
        }

        [Fact]
        public void VisitNodesInOrderReverse_ShouldPassTreeFromMaxToMinNode()
        {
            var tree = SetupTestTree();
            var nodesInOrderReverseList = new List<BinaryTreeNode<int>>();

            tree.VisitNodesInOrderReverse(node =>
            {
                nodesInOrderReverseList.Add(node);
            });

            Assert.Equal(nodesInOrderReverseList[0], tree.Root.Right);
            Assert.Equal(nodesInOrderReverseList[1], tree.Root.Right.Left);
            Assert.Equal(nodesInOrderReverseList[2], tree.Root);
            Assert.Equal(nodesInOrderReverseList[3], tree.Root.Left.Right);
            Assert.Equal(nodesInOrderReverseList[4], tree.Root.Left);
            Assert.Equal(nodesInOrderReverseList[5], tree.Root.Left.Left.Right);
            Assert.Equal(nodesInOrderReverseList[6], tree.Root.Left.Left);
        }

        [Fact]
        public void VisitNodesPreOrder_ShouldPassTreeSymmetrically()
        {
            var tree = SetupTestTree();
            var nodesPreOrderList = new List<BinaryTreeNode<int>>();

            tree.VisitNodesPreOrder(node =>
            {
                nodesPreOrderList.Add(node);
            });

            Assert.Equal(nodesPreOrderList[0], tree.Root);
            Assert.Equal(nodesPreOrderList[1], tree.Root.Left);
            Assert.Equal(nodesPreOrderList[2], tree.Root.Left.Left);
            Assert.Equal(nodesPreOrderList[3], tree.Root.Left.Left.Right);
            Assert.Equal(nodesPreOrderList[4], tree.Root.Left.Right);
            Assert.Equal(nodesPreOrderList[5], tree.Root.Right);
            Assert.Equal(nodesPreOrderList[6], tree.Root.Right.Left);
        }
    }
}
