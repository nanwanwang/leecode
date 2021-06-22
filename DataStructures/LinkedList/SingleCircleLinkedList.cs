using System.Runtime.InteropServices;
using System.Text;
using InterfaceDefine;

namespace LinkedList
{
    public class SingleCircleLinkedList<T> : AbstractList<T>
    {
        private Node _first;

        public class Node
        {
            public T Element;
            public Node Next;

            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.Append(Element).Append("_").Append(Next.Element);
                return sb.ToString();
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
            //考虑 0位置
            if (index == 0)
            {
               //先不要修改_first 因为修改后 查找节点的时候会有问题 因为在查找节点的时候会用到_first节点
                var newFirst = new Node(element, _first);
                var last = _size == 0 ? newFirst : GetNode(_size - 1);
                last.Next = newFirst;
                _first = newFirst;
            }
            else
            {
                var preNode = GetNode(index - 1);
                preNode.Next = new Node(element, preNode.Next);
            }

            _size++;
        }

        public override T Remove(int index)
        {
            RangeCheck(index);
            var node = _first;
            if (index == 0)
            {
                if (_size == 1)
                {
                    _first = null;
                }
                else
                {
                    var last = GetNode(_size - 1);
                    _first = _first.Next;
                    last.Next = _first;

                }
            }
            else
            {
                var preNode = GetNode(index - 1);
                node = preNode.Next;
                preNode.Next = node.Next;
            }

            _size--;
            return node.Element;
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

        public override void Clear()
        {
            _size = 0;
            _first = null;
        }

        private Node GetNode(int index)
        {
            RangeCheck(index);
            Node node = _first;

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node;
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

                sb.Append(node);
                node = node.Next;
            }

            sb.Append("]");
            return sb.ToString();
        }
    }
}