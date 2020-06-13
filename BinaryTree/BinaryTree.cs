using System;

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

        public BinaryTreeNode<T> Root { get; set; }

        public int CountNodes { get; private set; }

        public bool ContainsValue(T value)
        {
            var foundNode = GetNode(value);
            return foundNode != null;
        }

        public BinaryTreeNode<T> GetNode(T value)
        {
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
            var tmp = Root;
            parent = null;

            while (tmp != null)
            {
                if (value.CompareTo(tmp.Value) == 0)
                    return tmp;

                parent = tmp == Root ? null : tmp;

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
    }
}
