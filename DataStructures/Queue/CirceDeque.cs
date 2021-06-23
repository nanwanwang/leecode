using System;
using System.Text;

namespace Queue
{
    /// <summary>
    /// 循环双向队列
    /// </summary>
    public class CirceDeque<T>
    {
        private int _front;
        private int _size;
        private T[] _elements;

        const int Default_Capacity = 10;


        public CirceDeque()
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
        
        /// <summary>
        /// 从队头入队
        /// </summary>
        /// <param name="element"></param>
        public void EnQueueFront(T element)
        {
            EnsureCapacity(_size + 1);
            _front = Index(-1);
            _elements[_front] = element;
            _size++;
        }

        /// <summary>
        /// 从队尾入队
        /// </summary>
        /// <param name="element"></param>
        public void EnqueueRear(T element)
        {
            EnsureCapacity(_size + 1);
            _elements[Index(_size)] = element;
            _size++;
        }

        /// <summary>
        /// 从对头出队
        /// </summary>
        /// <returns></returns>
        public T DeQueueFront()
        {
            var element = _elements[_front];
            _elements[_front] = default;
            _front = Index(1);
            _size--;
            return element;
        }

        /// <summary>
        /// 从队尾出队
        /// </summary>
        /// <returns></returns>
        public T DeQueueRear()
        {
            int rearIndex = Index(_size - 1);
            var rearElement = _elements[rearIndex];
            _elements[rearIndex] = default;
            _size--;
            return rearElement;
        }

        /// <summary>
        /// 获取队头元素
        /// </summary>
        /// <returns></returns>
        public T Front()
        {
            return _elements[_front];
        }

        /// <summary>
        /// 获取队尾元素
        /// </summary>
        /// <returns></returns>
        public T Rear()
        {
            return _elements[Index(_size - 1)];
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

        /// <summary>
        /// 获取真实索引
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int Index(int index)
        {
            index += _front;
            if (index < 0) return index + _elements.Length;
            //前提条件 index < 2 * _element.Length
            return index - (index >= _elements.Length ? _elements.Length : 0);
        }

        public void Clear()
        {
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

                sb.Append(_elements[i] == null ? "null" : _elements[i]);
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}