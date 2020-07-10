using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("BinaryTree.Tests")]

namespace BinaryTree
{
    /// <summary>
    /// Represents a generic binary search tree
    /// </summary>
    /// <typeparam name="T">Binary tree node data type</typeparam>
    public class BinaryTree<T> where T : IComparable<T>
    {
        public BinaryTree()
        {
            Root = null;
            CountNodes = 0;
        }

        /// <summary>
        /// Binary tree root node
        /// </summary>
        public BinaryTreeNode<T> Root { get; private set; }

        /// <summary>
        /// Gets all tree nodes count
        /// </summary>
        public int CountNodes { get; private set; }

        /// <summary>
        /// Gets count of nodes with no children
        /// </summary>
        public int CountLeafNodes
        {
            get
            {
                var count = 0;

                VisitNodesPreOrder(node =>
                {
                    if (node.Status == BinaryTreeNodeStatus.NodeWithZeroChildren)
                        count++;
                });

                return count;
            }
        }

        /// <summary>
        /// Gets count of nodes having only one child
        /// </summary>
        public int CountNotFullNodes
        {
            get
            {
                var count = 0;

                VisitNodesPreOrder(node =>
                {
                    if (node.Status == BinaryTreeNodeStatus.NodeWithLeftChild
                        || node.Status == BinaryTreeNodeStatus.NodeWithRightChild)
                        count++;
                });

                return count;
            }
        }

        /// <summary>
        /// Gets count of nodes having two children
        /// </summary>
        public int CountFullNodes
        {
            get
            {
                var count = 0;

                VisitNodesPreOrder(node =>
                {
                    if (node.Status == BinaryTreeNodeStatus.NodeWithTwoChildren)
                        count++;
                });

                return count;
            }
        }

        /// <summary>
        /// Gets tree height
        /// </summary>
        public int Height
        {
            get
            {
                var maxDepth = 0;
                BinaryTreeRecursiveHelper<T>.GetMaxDepth(Root, 0, ref maxDepth);
                return maxDepth;
            }
        }

        /// <summary>
        /// Gets first entry of node with specified value or null if it doesn't exist
        /// </summary>
        /// <param name="value">Node value</param>
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

        /// <summary>
        /// Gets first entry of node with specified value or null if it doesn't exist
        /// </summary>
        /// <param name="value">Node value</param>
        /// <param name="parent">Found node's parent (null for root node)</param>
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

        /// <summary>
        /// Checks if tree contains at least one node with specified value
        /// </summary>
        /// <param name="value">Node value</param>
        public bool ContainsValue(T value)
        {
            var foundNode = GetNode(value);
            return foundNode != null;
        }

        /// <summary>
        /// Inserts new node to binary tree
        /// </summary>
        /// <param name="value">New node's value</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Insert(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (ContainsValue(value))
                throw new ArgumentException($"Node with value = '{value}' already exists in tree", nameof(value));

            var newNode = new BinaryTreeNode<T>(value);

            if (Root == null)
                Root = newNode;
            else
            {
                var tmp = Root;
                var parent = Root;
                var insertLeft = true;

                while (tmp != null)
                {
                    parent = tmp;

                    if (value.CompareTo(tmp.Value) < 0)
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
                    parent.Left = newNode;
                else
                    parent.Right = newNode;
            }

            CountNodes++;
        }

        /// <summary>
        /// Visits all tree nodes in direct order (from min to max node) and performs specified action for each node
        /// </summary>
        /// <param name="action">Action to perform</param>
        public void VisitNodesInOrder(Action<BinaryTreeNode<T>> action)
        {
            BinaryTreeRecursiveHelper<T>.VisitNodesInOrder(Root, action);
        }

        /// <summary>
        /// Visits all tree nodes in reverse order (from max to min node) and performs specified action for each node
        /// </summary>
        /// <param name="action">Action to perform</param>
        public void VisitNodesInOrderReverse(Action<BinaryTreeNode<T>> action)
        {
            BinaryTreeRecursiveHelper<T>.VisitNodesInOrderReverse(Root, action);
        }

        /// <summary>
        /// Visits all tree nodes in pre order (from root to left and right, symmetric) and performs specified action for each node
        /// </summary>
        /// <param name="action">Action to perform</param>
        public void VisitNodesPreOrder(Action<BinaryTreeNode<T>> action)
        {
            BinaryTreeRecursiveHelper<T>.VisitNodesPreOrder(Root, action);
        }

        /// <summary>
        /// Visits all tree nodes in post order and performs specified action for each node
        /// </summary>
        /// <param name="action">Action to perform</param>
        public void VisitNodesPostOrder(Action<BinaryTreeNode<T>> action)
        {
            BinaryTreeRecursiveHelper<T>.VisitNodesPostOrder(Root, action);
        }

        /// <summary>
        /// Deletes node with specified value from binary search tree
        /// </summary>
        /// <param name="value">Node value for delete</param>
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
                    // Guaranties that existing node will be deleted (if not, throws this exception)
                    // This allows to perform common post-deleting actions after switch for all cases
                    // instead of copy-pasting them to each case
                    throw new NotSupportedException($"Could not determine node for delete status = '${nodeForDelete.Status}'");
            }

            CountNodes--;
        }

        #region Private -> Delete node methods

        /// <summary>
        /// Deletes leaf node from tree
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

        /// <summary>
        /// Deletes all nodes from tree
        /// </summary>
        public void Clear()
        {
            BinaryTreeRecursiveHelper<T>.VisitNodesPostOrder(Root, node =>
            {
                Delete(node.Value);
            });
        }

        /// <summary>
        /// Gets absolute path starting from root to node with specified value, including target node
        /// </summary>
        /// <param name="value">Specified value</param>
        /// <returns>A sequence of node values starting from root to node with specified value</returns>
        /// <exception cref="ArgumentException"></exception>
        public IEnumerable<T> GetAbsolutePathToNode(T value)
        {
            var targetNode = GetNode(value);

            if (targetNode == null)
                throw new ArgumentException($"Could not get absolute path to node = '{value}' bacause it doesn't exist in tree", nameof(value));

            var tmp = Root;
            var path = new List<T>();

            while (tmp != null)
            {
                path.Add(tmp.Value);

                if (tmp.Value.CompareTo(value) == 0)
                    break;

                if (value.CompareTo(tmp.Value) < 0)
                    tmp = tmp.Left;
                else
                    tmp = tmp.Right;
            }

            return path;
        }

        /// <summary>
        /// Converts binary tree to its array representation.
        /// In this representation, for node with index i its children can be found at indices
        /// 2 * i + 1 (left child) and 2 * i + 2 (right child), while its parent - at index (i - 1) / 2.
        /// The result array size is equal to 2^(h + 1) - 1, where h is tree height
        /// </summary>
        /// <returns>Node values array</returns>
        public T[] ToArray()
        {
            if (CountNodes == 0)
                return Array.Empty<T>();

            var array = new T[Convert.ToInt32(Math.Pow(2, Height + 1) - 1)];
            BinaryTreeRecursiveHelper<T>.ToArray(Root, array, 0);
            return array;
        }
    }
}
