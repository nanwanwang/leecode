using System.Text;
using DynamicArray;
using InterfaceDefine;

namespace LinkedList
{
    public class DoublyLinkedList<T> : AbstractList<T>
    {
        public DoublyLinkedList()
        {
            _first = new Node(default, null, null);
        }

        private Node _first;
        private Node _last;

        public class Node
        {
            public T Element;
            public Node Prev;
            public Node Next;


            public Node(T element, Node prev, Node next)
            {
                Element = element;
                Prev = prev;
                Next = next;
            }
        }


        public override T Get(int index)
        {
            return GetNode(index).Element;
        }

        public override T Set(int index, T element)
        {
            var originNode = GetNode(index);
            var old = originNode.Element;
            originNode.Element = element;
            return old;
        }

        public override void Add(int index, T element)
        {
            RangeCheckForAdd(index);
            if (index == _size)
            {
                var oldLast = _last;
                _last = new Node(element, oldLast, null);
                if (oldLast == null)
                {
                    _first = _last;
                }
                else
                {
                    oldLast.Next = _last;
                }
            }
            else
            {
                var next = GetNode(index);
                var prev = next.Prev;
                var newNode = new Node(element, prev, next);
                next.Prev = newNode;
                if (prev == null)
                {
                    _first = newNode;
                }
                else
                {  
                    prev.Next = newNode;
                }  
            }
           
            _size++;
        }

        public override T Remove(int index)
        {
            RangeCheck(index);
            var delNode= GetNode(index);
            var prev = delNode.Prev;
            var next = delNode.Next;
            if (prev == null)  //index == 0
            {
                _first = next;
            }
            else
            {
                prev.Next = next;
            }

            if (next == null)  //index == _size - 1
            {
                _last = prev;
            }
            else
            {
                next.Prev = prev;
            }
                
            _size--;
            return delNode.Element;
        }

        public override int IndexOf(T element)
        {
            var node = _first;
            if (element == null)
            {
                for (int i = 0; i < _size; i++)
                {
                    if (node.Element == null) return i;
                    node = node.Next;
                }
            }
            else
            {
                for (int i = 0; i < _size; i++)
                {
                    if (element.Equals(node.Element)) return i;
                    node = node.Next;
                }
            }

            return -1;
        }

        /// <summary>
        /// 双向链表清空 首尾都需要清空
        /// </summary>
         public override void Clear()
        {
            _size = 0;
            _first = null;
            _last = null;
        }

        private Node GetNode(int index)
        {
            RangeCheck(index);
            //双向链表 index小于_size一半从 头开始查找
            if (index < (_size >> 1))
            {
                var node = _first;
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }

                return node;
            } //双向链表 index大于等于_size一半从尾开始查找
            else
            {
                var node = _last;
                for (int i = _size - 1; i > index; i--)
                {
                    node = node.Prev;
                }

                return node;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(10);
            sb.Append("size = ").Append(_size).Append(", [");
            var node = _first;
            for (var i = 0; i < _size; i++)
            {
                if (i != 0)
                {
                    sb.Append(", ");
                }

                sb.Append(node.Element);
                node = node.Next;
            }

            sb.Append("]");
            return sb.ToString();
        }
    }
}