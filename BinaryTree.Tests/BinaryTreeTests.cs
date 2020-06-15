using System;
using System.Collections.Generic;
using Xunit;

namespace BinaryTree.Tests
{
    public class BinaryTreeTests
    {
        [Fact]
        public void Insert_ShouldThrowException_WhenNodeParameterIsNull()
        {
            var tree = BinaryTreeTestData.SetupTestTree();

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
        }

        [Fact]
        public void CountNodes_ShouldBeZeroByDefault()
        {
            var tree = new BinaryTree<int>();

            var result = tree.CountNodes;

            Assert.Equal(0, result);
        }

        [Fact]
        public void VisitNodesInOrder_ShouldPassTreeFromMinToMaxNode()
        {
            var tree = BinaryTreeTestData.SetupTestTree();
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
            var tree = BinaryTreeTestData.SetupTestTree();
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
        public void VisitNodesPreOrder_ShouldPassTreeInPreOrder()
        {
            var tree = BinaryTreeTestData.SetupTestTree();
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

        [Fact]
        public void VisitNodesPostOrder_ShouldPassTreeInPostOrder()
        {
            var tree = BinaryTreeTestData.SetupTestTree();
            var nodesPostOrderList = new List<BinaryTreeNode<int>>();

            tree.VisitNodesPostOrder(node =>
            {
                nodesPostOrderList.Add(node);
            });

            Assert.Equal(nodesPostOrderList[0], tree.Root.Left.Left.Right);
            Assert.Equal(nodesPostOrderList[1], tree.Root.Left.Left);
            Assert.Equal(nodesPostOrderList[2], tree.Root.Left.Right);
            Assert.Equal(nodesPostOrderList[3], tree.Root.Left);
            Assert.Equal(nodesPostOrderList[4], tree.Root.Right.Left);
            Assert.Equal(nodesPostOrderList[5], tree.Root.Right);
            Assert.Equal(nodesPostOrderList[6], tree.Root);
        }

        [Theory]
        [MemberData(nameof(BinaryTreeTestData.MemberData_ContainsValue), MemberType = typeof(BinaryTreeTestData))]
        public void ContainsValue_ShouldSearchForSpecifiedValueInTree(BinaryTree<int> tree, int searchValue, bool expectedResult)
        {
            var result = tree.ContainsValue(searchValue);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(nameof(BinaryTreeTestData.MemberData_GetNode), MemberType = typeof(BinaryTreeTestData))]
        public void GetNode_ShouldReturnTargetNode(BinaryTree<int> tree, int searchValue, BinaryTreeNode<int> targetNode)
        {
            var result = tree.GetNode(searchValue);

            Assert.Equal(targetNode, result);
        }

        [Fact]
        public void GetNode_ShouldThrowArgumentNullException_WhenValueIsNull()
        {
            var tree = new BinaryTree<string>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                tree.GetNode(null);
            });
        }

        [Theory]
        [MemberData(nameof(BinaryTreeTestData.MemberData_GetNodeWithParent), MemberType = typeof(BinaryTreeTestData))]
        public void GetNodeWithParent_ShouldReturnTargetNodeWithItsParent(BinaryTree<int> tree, int searchValue, BinaryTreeNode<int> targetNode, BinaryTreeNode<int> expectedParent)
        {
            var result = tree.GetNodeWithParent(searchValue, out var parent);

            Assert.Equal(targetNode, result);
            Assert.Equal(expectedParent, parent);
        }

        [Fact]
        public void GetNodeWithParent_ShouldThrowArgumentNullException_WhenValueIsNull()
        {
            var tree = new BinaryTree<string>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                tree.GetNodeWithParent(null, out var parent);
            });
        }

        [Theory]
        [InlineData(100)]
        public void Delete_ShouldThrowArgumentException_WhenTryingToDeleteNotExistingNode(int valueToDelete)
        {
            var tree = BinaryTreeTestData.SetupTestTree();

            Assert.Throws<ArgumentException>(() =>
            {
                tree.Delete(valueToDelete);
            });
        }

        [Fact]
        public void Delete_ShouldDeleteRootWithoutChildren()
        {
            var tree = new BinaryTree<int>();
            tree.Insert(new BinaryTreeNode<int>(100));

            tree.Delete(100);

            Assert.Null(tree.Root);
        }

        [Fact]
        public void Delete_ShouldDeleteNodeWithoutChildren()
        {
            var tree = BinaryTreeTestData.SetupTestTree();

            tree.Delete(15);

            Assert.Equal(50, tree.Root.Value);
            Assert.Equal(20, tree.Root.Left.Value);
            Assert.Equal(70, tree.Root.Right.Value);
            Assert.Equal(10, tree.Root.Left.Left.Value);
            Assert.Equal(30, tree.Root.Left.Right.Value);
            Assert.Equal(60, tree.Root.Right.Left.Value);
            Assert.Null(tree.Root.Left.Left.Right);
        }

        [Fact]
        public void Delete_ShouldDeleteRootWithLeftChild()
        {
            var tree = new BinaryTree<int>();
            tree.Insert(new BinaryTreeNode<int>(50));
            tree.Insert(new BinaryTreeNode<int>(20));
            tree.Insert(new BinaryTreeNode<int>(10));
            tree.Insert(new BinaryTreeNode<int>(30));

            tree.Delete(50);

            Assert.Equal(20, tree.Root.Value);
            Assert.Equal(10, tree.Root.Left.Value);
            Assert.Equal(30, tree.Root.Right.Value);
        }

        [Fact]
        public void Delete_ShouldDeleteNodeWithLeftChild()
        {
            var tree = BinaryTreeTestData.SetupTestTree();

            tree.Delete(70);

            Assert.Equal(50, tree.Root.Value);
            Assert.Equal(20, tree.Root.Left.Value);
            Assert.Equal(10, tree.Root.Left.Left.Value);
            Assert.Equal(30, tree.Root.Left.Right.Value);
            Assert.Equal(60, tree.Root.Right.Value);
            Assert.Equal(15, tree.Root.Left.Left.Right.Value);
            Assert.Null(tree.Root.Right.Left);
            Assert.Null(tree.Root.Right.Right);
        }

        [Fact]
        public void Delete_ShouldDeleteRootWithRightChild()
        {
            var tree = new BinaryTree<int>();
            tree.Insert(new BinaryTreeNode<int>(50));
            tree.Insert(new BinaryTreeNode<int>(70));
            tree.Insert(new BinaryTreeNode<int>(60));
            tree.Insert(new BinaryTreeNode<int>(100));

            tree.Delete(50);

            Assert.Equal(70, tree.Root.Value);
            Assert.Equal(60, tree.Root.Left.Value);
            Assert.Equal(100, tree.Root.Right.Value);
        }

        [Fact]
        public void Delete_ShouldDeleteNodeWithRightChild()
        {
            var tree = BinaryTreeTestData.SetupTestTree();

            tree.Delete(10);

            Assert.Equal(50, tree.Root.Value);
            Assert.Equal(20, tree.Root.Left.Value);
            Assert.Equal(70, tree.Root.Right.Value);
            Assert.Equal(30, tree.Root.Left.Right.Value);
            Assert.Equal(60, tree.Root.Right.Left.Value);
            Assert.Equal(15, tree.Root.Left.Left.Value);
            Assert.Null(tree.Root.Left.Left.Left);
            Assert.Null(tree.Root.Left.Left.Right);
        }

        [Fact]
        public void Delete_ShouldDeleteRootWithTwoChildren()
        {
            var tree = new BinaryTree<int>();
            tree.Insert(new BinaryTreeNode<int>(50));
            tree.Insert(new BinaryTreeNode<int>(20));
            tree.Insert(new BinaryTreeNode<int>(30));
            tree.Insert(new BinaryTreeNode<int>(70));

            tree.Delete(50);

            Assert.Equal(30, tree.Root.Value);
            Assert.Equal(20, tree.Root.Left.Value);
            Assert.Equal(70, tree.Root.Right.Value);
        }

        [Fact]
        public void Delete_ShouldDeleteNodeWithTwoChildren()
        {
            var tree = BinaryTreeTestData.SetupTestTree();

            tree.Delete(20);

            Assert.Equal(50, tree.Root.Value);
            Assert.Equal(70, tree.Root.Right.Value);
            Assert.Equal(60, tree.Root.Right.Left.Value);
            Assert.Equal(15, tree.Root.Left.Value);
            Assert.Equal(10, tree.Root.Left.Left.Value);
            Assert.Equal(30, tree.Root.Left.Right.Value);
        }

        [Fact]
        public void CountNodes_ShouldChangeOnInsertingNode()
        {
            var tree = new BinaryTree<int>();
            tree.Insert(new BinaryTreeNode<int>(1));
            tree.Insert(new BinaryTreeNode<int>(2));
            tree.Insert(new BinaryTreeNode<int>(3));

            var result = tree.CountNodes;

            Assert.Equal(3, result);
        }

        [Fact]
        public void CountNodes_ShouldChangeOnDeletingNode()
        {
            var tree = new BinaryTree<int>();
            tree.Insert(new BinaryTreeNode<int>(1));
            tree.Insert(new BinaryTreeNode<int>(2));
            tree.Insert(new BinaryTreeNode<int>(3));
            tree.Delete(2);
            tree.Delete(3);

            var result = tree.CountNodes;

            Assert.Equal(1, result);
        }

        [Fact]
        public void Clear_ShouldDeleteAllNodesFromTree()
        {
            var tree = BinaryTreeTestData.SetupTestTree();

            tree.Clear();

            Assert.Null(tree.Root);
            Assert.Equal(0, tree.CountNodes);
        }

        [Fact]
        public void CountSheetNodes_ShouldReturnCorrectNumber()
        {
            var tree = BinaryTreeTestData.SetupTestTree();

            var result = tree.CountSheetNodes;

            Assert.Equal(3, result);
        }

        [Fact]
        public void CountNotFullNodes_ShouldReturnCorrectNumber()
        {
            var tree = BinaryTreeTestData.SetupTestTree();

            var result = tree.CountNotFullNodes;

            Assert.Equal(2, result);
        }

        [Fact]
        public void CountFullNodes_ShouldReturnCorrectNumber()
        {
            var tree = BinaryTreeTestData.SetupTestTree();

            var result = tree.CountFullNodes;

            Assert.Equal(2, result);
        }

        [Theory]
        [MemberData(nameof(BinaryTreeTestData.MemberData_CountLevels), MemberType = typeof(BinaryTreeTestData))]
        public void CountLevels_ShouldReturnCorrectNumber(BinaryTree<int> tree, int expectedLevelsCount)
        {
            var result = tree.CountLevels;

            Assert.Equal(expectedLevelsCount, result);
        }

        [Theory]
        [MemberData(nameof(BinaryTreeTestData.MemberData_GetAbsolutePathToNode), MemberType = typeof(BinaryTreeTestData))]
        public void GetAbsolutePathToNode_ShouldReturnCorrectSequence_WhenTargetNodeExists(BinaryTree<int> tree, int targetValue, IEnumerable<int> expectedSequence)
        {
            var result = tree.GetAbsolutePathToNode(targetValue);

            Assert.Equal(expectedSequence, result);
        }

        [Fact]
        public void GetAbsolutePathToNode_ShouldThrowArgumentException_WhenTargetNodeDoesNotExist()
        {
            var tree = BinaryTreeTestData.SetupTestTree();

            Assert.Throws<ArgumentException>(() =>
            {
                tree.GetAbsolutePathToNode(100);
            });
        }
    }
}
