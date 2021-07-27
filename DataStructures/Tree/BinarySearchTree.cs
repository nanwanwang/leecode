using System;
using System.Collections.Generic;
using System.Text;
using TreePointer;

namespace Tree
{
    public class BinarySearchTree<T> : BinaryTreeInfo
    {
        private int _size;
        public Node<T> _root;

        private IComparer<T> _comparer;

        public BinarySearchTree() : this(null)
        {

        }

        public BinarySearchTree(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public int Size()
        {
            return _size;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public void Clear() { }


        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            ElementNotNullCheck(element);

            if (_root == null)
            {
                _root = new Node<T>(element, null);
                _size++;
                return;
            }

            Node<T> parent = _root;
            Node<T> node = _root;
            int compareResult = 0;
            while (node != null)
            {
                compareResult = Compare(element, node.Element);
                parent = node;
                if (compareResult > 0)
                {
                    node = node.Right;
                }
                else if (compareResult < 0)
                {
                    node = node.Left;
                }
                else
                {
                    node.Element = element;
                    return;
                }
            }

            Node<T> newNode = new Node<T>(element, parent);
            if (compareResult > 0)
            {
                parent.Right = newNode;
            }
            else
            {
                parent.Left = newNode;
            }


            _size++;

        }

        public void Remove(T element)
        {

        }

        public bool Contains(T element)
        {
            return false;
        }

        /// <summary>
        /// 比较方法 小于0 element1 小于 element2  等于0 相等  大于0 element1 大于 element2
        /// </summary>
        /// <param name="element1"></param>
        /// <param name="element2"></param>
        /// <returns></returns>
        private int Compare(T element1, T element2)
        {
            if (_comparer != null)
            {
                return _comparer.Compare(element1, element2);
            }
            return ((IComparable<T>)element1).CompareTo(element2);
        }

        private void ElementNotNullCheck(T element)
        {
            if (element == null)
                throw new ArgumentNullException("element must not be null");

        }

        public object Root()
        {
            return _root;
        }

        public object Left(object node)
        {
            return ((Node<T>)node).Left;
        }

        public object Right(object node)
        {
            return ((Node<T>)node).Right;
        }

        public object String(object node)
        {
            return ((Node<T>)node).Element;
        }

        /// <summary>
        /// 前序遍历
        /// </summary>
        public void PreorderTraversal(Action<T> action)
        {
            PreorderTraversal(_root, action);
        }

        /// <summary>
        /// 前序遍历
        /// </summary>
        /// <param name="node"></param>
        private void PreorderTraversal(Node<T> node, Action<T> action)
        {
            if (node == null) return;
            action?.Invoke(node.Element);
            PreorderTraversal(node.Left, action);
            PreorderTraversal(node.Right, action);
        }

        /// <summary>
        /// 中序遍历
        /// </summary>
        public void InorderTraversal(Action<T> action)
        {
            Inordertraversal(_root, action);
        }

        private void Inordertraversal(Node<T> node, Action<T> action)
        {
            if (node == null) return;
            Inordertraversal(node.Left, action);
            action?.Invoke(node.Element);
            Inordertraversal(node.Right, action);
        }

        /// <summary>
        /// 后序遍历
        /// </summary>
        public void PostorderTraversal(Action<T> action)
        {
            PostorderTraversal(_root, action);
        }

        private void PostorderTraversal(Node<T> node, Action<T> action)
        {
            if (node == null) return;
            PostorderTraversal(node.Left, action);
            PostorderTraversal(node.Right, action);
            action?.Invoke(node.Element);
        }

        /// <summary>
        /// 层序遍历
        /// </summary>
        /// <param name="node"></param>
        public void LevelorderTraversal(Action<T> action)
        {
            LevelorderTraversal(_root, action);
        }

        public void LevelorderTraversal(Node<T> node, Action<T> action)
        {
            if (node == null) return;
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var headNode = queue.Dequeue();
                action?.Invoke(headNode.Element);
                if (headNode.Left != null)
                {
                    queue.Enqueue(headNode.Left);
                }
                if (headNode.Right != null)
                {
                    queue.Enqueue(headNode.Right);
                }

            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            ToString(_root, sb, "");
            return sb.ToString();
        }

        private void ToString(Node<T> node, StringBuilder stringBuilder, string pre)
        {
            if (node == null) return;
            stringBuilder.Append(pre).AppendLine(node.Element.ToString());
            ToString(node.Left, stringBuilder, "L__");
            ToString(node.Right, stringBuilder, "R__");
        }

        public int Height()
        {
            return Height(_root);
        }

        /// <summary>
        /// 使用层序遍历 来获取高度  高度 根节点到最远的叶子节点的经过节点的个数
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int Height(Node<T> node)
        {
            if (node == null) return 0;
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(node);
            int levelCount = 1;
            int height = 0;

            while (queue.Count>0)
            {
                 node = queue.Dequeue();
                levelCount--;
                if(node.Left!=null)
                {
                    queue.Enqueue(node.Left);
                }

                if(node.Right!=null)
                {
                    queue.Enqueue(node.Right);
                }

                if(levelCount==0)
                {
                    levelCount = queue.Count;
                    height++;
                }
            }
            return height;
        }


        public int Height2()
        {
            return Height2(_root);
        }

        /// <summary>
        /// 使用递归获取高度
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int Height2(Node<T> node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(Height2(node.Left), Height2(node.Right));
        }


        /// <summary>
        /// 是否完全二叉树
        /// </summary>
        /// <returns></returns>
        public bool IsComplete()
        {
            if (_root == null) return false;
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(_root);
            bool leaf = false;
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (leaf && !node.IsLeaf())
                {
                    return false;
                }

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }else if(node.Right!=null)
                {
                    return false;
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
                else
                {
                    leaf = true;
                }
            }
            return true;
        }

        public bool IsComplete2()
        {
            if (_root == null) return false;
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(_root);
            bool leaf = false;
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (leaf && !node.IsLeaf())
                {
                    return false;
                }
                if (node.HasTwoChildren())
                {
                    queue.Enqueue(node.Left);
                    queue.Enqueue(node.Right);
                }
                else if (node.Right != null && node.Left == null)
                {
                    return false;
                }
                else
                {
                    if(node.Left!=null)
                    {
                        queue.Enqueue(node.Left);
                    }
                    leaf = true;
                }
            }
            return true;
        }

        /// <summary>
        /// 前驱节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node<T> Predecessor(Node<T> node)
        {
            if (node == null) return null;
            Node<T> p = node.Left;
            if (p != null)
            {
                while (p.Right != null)
                {
                    p = p.Right;
                }
                return p;
            }

            while (node.Parent != null && node == node.Parent.Left )
            {
                node = node.Parent;
            }

            //node.parent == null
            return node.Parent;
        }

        /// <summary>
        /// 后继节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node<T> Successor(Node<T> node)
        {
            if (node == null) return null;
            Node<T> p = node.Right;
            if (p != null)
            {
                while (p.Left != null)
                {
                    p = p.Left;
                }
                return p;
            }


            while (p.Parent != null && node == node.Parent.Right)
            {
                node = node.Parent;
            }

            return node.Parent;

        }




    }

    public class Node<E>
    {
        public E Element { get; set; }
        public Node<E> Left { get; set; }
        public Node<E> Right { get; set; }
        public Node<E> Parent { get; set; }

        public Node(E element, Node<E> parent)
        {
            Element = element;
            Parent = parent;
        }

        /// <summary>
        /// 判断是否为叶子节点
        /// </summary>
        /// <returns></returns>
        public bool IsLeaf()
        {
            return Left == null && Right == null;
        }

        /// <summary>
        /// 是否有两个节点
        /// </summary>
        /// <returns></returns>
        public bool HasTwoChildren()
        {
            return Left != null && Right != null;
        }


    }
}