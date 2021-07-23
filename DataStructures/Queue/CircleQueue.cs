using System.Linq;
using System.Text;

namespace Queue
{
    public class CircleQueue<T>
    {
        private int _front;
        private int _size;
        private T[] _elements;
        
        const int Default_Capacity = 10;

        public CircleQueue()
        {
            _elements = new T[Default_Capacity];
        }

        public int Size()
        {
            return _size;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public void EnQueue(T element)
        {
            EnsureCapacity(_size + 1);
            _elements[Index(_size)] = element;
            _size++;
        }

        public T DeQueue()
        {
            var frontElement = _elements[_front];
            _elements[_front] = default;
            _front = Index(1);
            _size--;
            return frontElement;
        }

        public T Front()
        {
            return _elements[_front];
        }

        private void EnsureCapacity(int capacity)
        {
            int oldCapacity = _elements.Length;
            if (oldCapacity >= capacity) return;
            int newCapacity = oldCapacity + (oldCapacity >> 1);
            T[] newElements = new T[newCapacity];
            for (int i = 0; i < _size; i++)
            {
                newElements[i] = _elements[Index(i)];
            }

            _elements = newElements;
            _front = 0;
        }

        private int Index(int index)
        {
            // return (index + _front) % _elements.Length;
            index += _front;
            return index - (index >= _elements.Length ? _elements.Length : 0);
        }
        
        public void Clear()
        {
            //循环遍历清空?
            _elements = new T[Default_Capacity];
            _size = 0;
            _front = 0;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("front=").Append(_front).Append(",capacity=").Append(_elements.Length).Append(",size=")
                .Append(_size)
                .Append(",[");
            for (int i = 0; i < _elements.Length; i++)
            {
                if (i != 0)
                {
                    sb.Append(",");
                }

                sb.Append(_elements[i]);
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}