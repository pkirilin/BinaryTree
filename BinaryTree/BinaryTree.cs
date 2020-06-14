using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("BinaryTree.Tests")]

namespace BinaryTree
{
    /// <summary>
    /// Represents a generic binary search tree
    /// </summary>
    /// <typeparam name="T">Binary tree node data type</typeparam>
    public class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
    {
        public BinaryTree()
        {
            Root = null;
            CountNodes = 0;
        }

        public BinaryTreeNode<T> Root { get; private set; }

        public int CountNodes { get; private set; }

        public bool ContainsValue(T value)
        {
            var foundNode = GetNode(value);
            return foundNode != null;
        }

        public void Delete(T value)
        {
            var nodeForDelete = GetNodeWithParent(value, out var nodeForDeleteParent);

            if (nodeForDelete == null)
                throw new ArgumentException($"Cannot delete node with value '{value}' because tree doesn't contain node with this value", nameof(value));

            switch (nodeForDelete.Status)
            {
                case BinaryTreeNodeStatus.NodeWithZeroChildren:
                    DeleteNodeWithZeroChildren(nodeForDelete, nodeForDeleteParent);
                    break;
                case BinaryTreeNodeStatus.NodeWithLeftChild:
                    DeleteNodeWithLeftChild(nodeForDelete, nodeForDeleteParent);
                    break;
                case BinaryTreeNodeStatus.NodeWithRightChild:
                    DeleteNodeWithRightChild(nodeForDelete, nodeForDeleteParent);
                    break;
                case BinaryTreeNodeStatus.NodeWithTwoChildren:
                    DeleteNodeWithTwoChildren(nodeForDelete, nodeForDeleteParent);
                    break;
                default:
                    break;
            }
        }

        public BinaryTreeNode<T> GetNode(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var tmp = Root;

            while (tmp != null)
            {
                if (value.CompareTo(tmp.Value) == 0)
                    return tmp;

                if (value.CompareTo(tmp.Value) > 0)
                    tmp = tmp.Right;
                else
                    tmp = tmp.Left;
            }

            return null;
        }

        public BinaryTreeNode<T> GetNodeWithParent(T value, out BinaryTreeNode<T> parent)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var tmp = Root;
            parent = null;

            while (tmp != null)
            {
                if (value.CompareTo(tmp.Value) == 0)
                    return tmp;

                parent = tmp;

                if (value.CompareTo(tmp.Value) > 0)
                    tmp = tmp.Right;
                else
                    tmp = tmp.Left;
            }

            parent = null;
            return null;
        }

        public void Insert(BinaryTreeNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            if (Root == null)
                Root = node;
            else
            {
                var tmp = Root;
                var parent = Root;
                var insertLeft = true;

                while (tmp != null)
                {
                    parent = tmp;

                    if (node.Value.CompareTo(tmp.Value) < 0)
                    {
                        tmp = tmp.Left;
                        insertLeft = true;
                    }
                    else
                    {
                        tmp = tmp.Right;
                        insertLeft = false;
                    }   
                }

                if (insertLeft)
                    parent.Left = node;
                else
                    parent.Right = node;
            }

            CountNodes++;
        }

        public void VisitNodesInOrder(Action<BinaryTreeNode<T>> action)
        {
            BinaryTreeRecursiveHelper<T>.VisitNodesInOrder(Root, action);
        }

        public void VisitNodesInOrderReverse(Action<BinaryTreeNode<T>> action)
        {
            BinaryTreeRecursiveHelper<T>.VisitNodesInOrderReverse(Root, action);
        }

        public void VisitNodesPreOrder(Action<BinaryTreeNode<T>> action)
        {
            BinaryTreeRecursiveHelper<T>.VisitNodesPreOrder(Root, action);
        }

        #region Private -> Delete node methods

        /// <summary>
        /// Deletes sheet node from tree
        /// </summary>
        /// <param name="node">Node for delete</param>
        /// <param name="parent">Node for delete parent</param>
        private void DeleteNodeWithZeroChildren(BinaryTreeNode<T> node, BinaryTreeNode<T> parent)
        {
            if (parent == null)
                Root = null;
            else
            {
                if (parent.Left == node)
                    parent.Left = null;
                else
                    parent.Right = null;
            }
        }

        /// <summary>
        /// Deletes node with only left child from tree
        /// </summary>
        /// <param name="node">Node for delete</param>
        /// <param name="parent">Node for delete parent</param>
        private void DeleteNodeWithLeftChild(BinaryTreeNode<T> node, BinaryTreeNode<T> parent)
        {
            if (parent == null)
                Root = node.Left;
            else
            {
                if (parent.Left == node)
                    parent.Left = node.Left;
                else
                    parent.Right = node.Left;

                node.Left = null;
            }
        }

        /// <summary>
        /// Deletes node with only right child from tree
        /// </summary>
        /// <param name="node">Node for delete</param>
        /// <param name="parent">Node for delete parent</param>
        private void DeleteNodeWithRightChild(BinaryTreeNode<T> node, BinaryTreeNode<T> parent)
        {
            if (parent == null)
                Root = node.Right;
            else
            {
                if (parent.Left == node)
                    parent.Left = node.Right;
                else
                    parent.Right = node.Right;

                node.Right = null;
            }
        }

        /// <summary>
        /// Deletes node with both left and right child from tree
        /// </summary>
        /// <param name="node">Node for delete</param>
        /// <param name="parent">Node for delete parent</param>
        private void DeleteNodeWithTwoChildren(BinaryTreeNode<T> node, BinaryTreeNode<T> parent)
        {
            // Getting node with max value in left subtree of deleting node with its parent
            var maxNodeInLeftSubtree = GetMaxNodeWithParentInLeftSubtree(node, out var maxNodeInLeftSubtreeParent);

            // Temporarily removing it from tree
            if (maxNodeInLeftSubtreeParent.Left == maxNodeInLeftSubtree)
                maxNodeInLeftSubtreeParent.Left = null;
            else
                maxNodeInLeftSubtreeParent.Right = null;

            // Setting deleting node's parent child to max node in left subtree
            if (parent == null)
                Root = maxNodeInLeftSubtree;
            else
            {
                if (parent.Left == node)
                    parent.Left = maxNodeInLeftSubtree;
                else
                    parent.Right = maxNodeInLeftSubtree;
            }

            // Setting max node in left subtree's childs to childs of deleting node
            maxNodeInLeftSubtree.Left = node.Left;
            maxNodeInLeftSubtree.Right = node.Right;

            // Removing child references from deleting node
            node.Left = node.Right = null;
        }

        /// <summary>
        /// Gets max (most "right") node with its parent in left subtree of specified node
        /// </summary>
        /// <param name="node">Specified node</param>
        /// <param name="parent">Max node parent</param>
        /// <returns>Max node</returns>
        private BinaryTreeNode<T> GetMaxNodeWithParentInLeftSubtree(BinaryTreeNode<T> node, out BinaryTreeNode<T> parent)
        {
            if (node.Left.Right == null)
            {
                parent = node;
                return node.Left;
            }
            else
            {
                var root = node.Left;

                while (root.Right.Right != null)
                    root = root.Right;

                parent = root;
                return root.Right;
            }
        }

        #endregion
    }
}
