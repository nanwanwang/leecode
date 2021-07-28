using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    public class BinarySearchTree<T>: BinaryTree<T>
    {
        private IComparer<T> _comparer;

        public BinarySearchTree() : this(null)
        {

        }

        public BinarySearchTree(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

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
            Remove(GetNode(element));
        }

        private void Remove(Node<T> node)
        {
            if (node == null) return;

            //度为2的节点
            if (node.HasTwoChildren())
            {
                //1.找前驱 或后继节点
                Node<T> s = Successor(node);
                //2.用前驱或后继节点的值 覆盖度为2的节点
                node.Element = s.Element;
                //3.删除前驱或后继节点
                node = s;
            }

            //删除node节点(node的度必然是1或者0)
            Node<T> replacement = node.Left != null ? node.Left : node.Right;

            //node 是度为1的节点
            if (replacement != null)
            {
                //更改parent
                replacement.Parent = node.Parent;
                //更改parent的 left 与right的指向
                if (node.Parent == null)
                {
                    _root = replacement;
                }
                else if (node == node.Parent.Left)
                {
                    node.Parent.Left = replacement;
                }
                else 
                {
                    node.Parent.Right = replacement;
                }
            }
            else if (node.Parent == null) //叶子节点并且是根节点
            {
                _root = null;
            }
            else   // 叶子节点不是根节点
            {
                if (node == node.Parent.Left)
                {
                    node.Parent.Left = null;
                }
                else
                {
                    node.Parent.Right = null;
                }
            }

            _size--;
        }

        private Node<T> GetNode(T element)
        {
            Node<T> node = _root;
            while (node != null)
            {
                int result = Compare(element, node.Element);
                if (result == 0)
                {
                    return node;
                }
                else if (result > 0)
                {
                    node = node.Right;
                }
                else
                {
                    node = node.Left;
                }

            }
            return null;
        }

        public bool Contains(T element)
        {
            return GetNode(element)!=null;
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

      

       

    
    }

 
}