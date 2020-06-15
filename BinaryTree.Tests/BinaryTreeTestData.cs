using System.Collections.Generic;

namespace BinaryTree.Tests
{
    static class BinaryTreeTestData
    {
        public static BinaryTree<int> SetupTestTree()
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

            var tree = new BinaryTree<int>();

            tree.Insert(new BinaryTreeNode<int>(50));
            tree.Insert(new BinaryTreeNode<int>(70));
            tree.Insert(new BinaryTreeNode<int>(20));
            tree.Insert(new BinaryTreeNode<int>(60));
            tree.Insert(new BinaryTreeNode<int>(10));
            tree.Insert(new BinaryTreeNode<int>(30));
            tree.Insert(new BinaryTreeNode<int>(15));

            return tree;
        }

        public static IEnumerable<object[]> MemberData_ContainsValue
        {
            get
            {
                var tree = SetupTestTree();

                yield return new object[] { tree, 50, true};
                yield return new object[] { tree, 10, true };
                yield return new object[] { tree, 30, true };
                yield return new object[] { tree, 100, false };
            }
        }

        public static IEnumerable<object[]> MemberData_GetNode
        {
            get
            {
                var tree = SetupTestTree();

                yield return new object[] { tree, 50, tree.Root };
                yield return new object[] { tree, 10, tree.Root.Left.Left };
                yield return new object[] { tree, 30, tree.Root.Left.Right };
                yield return new object[] { tree, 100, null };
            }
        }

        public static IEnumerable<object[]> MemberData_GetNodeWithParent
        {
            get
            {
                var tree = SetupTestTree();

                yield return new object[] { tree, 50, tree.Root, null };
                yield return new object[] { tree, 10, tree.Root.Left.Left, tree.Root.Left };
                yield return new object[] { tree, 30, tree.Root.Left.Right, tree.Root.Left };
                yield return new object[] { tree, 100, null, null };
            }
        }

        public static IEnumerable<object[]> MemberData_CountLevels
        {
            get
            {
                var tree1 = SetupTestTree();
                var tree2 = new BinaryTree<int>();
                var tree3 = new BinaryTree<int>();
                var tree4 = new BinaryTree<int>();

                tree2.Insert(new BinaryTreeNode<int>(1));

                tree4.Insert(new BinaryTreeNode<int>(2));
                tree4.Insert(new BinaryTreeNode<int>(1));
                tree4.Insert(new BinaryTreeNode<int>(3));

                yield return new object[] { tree1, 4 };
                yield return new object[] { tree2, 1 };
                yield return new object[] { tree3, 0 };
                yield return new object[] { tree4, 2 };
            }
        }

        public static IEnumerable<object[]> MemberData_GetAbsolutePathToNode
        {
            get
            {
                var tree1 = SetupTestTree();
                var tree2 = new BinaryTree<int>();
                var tree3 = new BinaryTree<int>();

                var result1 = new List<int>() { 50, 20, 10, 15 };
                var result2 = new List<int>() { 1 };
                var result3 = new List<int>() { 3, 1 };

                tree2.Insert(new BinaryTreeNode<int>(1));

                tree3.Insert(new BinaryTreeNode<int>(3));
                tree3.Insert(new BinaryTreeNode<int>(1));
                tree3.Insert(new BinaryTreeNode<int>(2));

                yield return new object[] { tree1, 15, result1 };
                yield return new object[] { tree2, 1, result2 };
                yield return new object[] { tree3, 1, result3 };
            }
        }
    }
}
