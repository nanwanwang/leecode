using System;
using System.Text;
using InterfaceDefine;

namespace DynamicArray
{
    public class ArrayList<T> : AbstractList<T>
    {
        private T[] _elements;
        private const int DEFAULT_CAPACITY = 4;

        public ArrayList() : this(DEFAULT_CAPACITY)
        {
        }

        public ArrayList(int capacity)
        {
            capacity = capacity < 10 ? DEFAULT_CAPACITY : capacity;
            _elements = new T[capacity];
        }

        /// <summary>
        /// 返回index位置对应的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override T Get(int index)
        {
            if (index < 0 || index >= _size) throw new IndexOutOfRangeException();
            return _elements[index];
        }

        /// <summary>
        /// 设置index位置的元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public override T Set(int index, T element)
        {
            RangeCheck(index);
            var old = _elements[index];
            _elements[index] = element;
            return old;
        }

        /// <summary>
        /// 往index位置添加元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        public override void Add(int index, T element)
        {
            RangeCheckForAdd(index);
            int oldCapacity = _elements.Length;
            if (oldCapacity < _size + 1)
            {
                var newCapacity = oldCapacity + (oldCapacity >> 1);
                T[] newElements = new T[newCapacity];
                for (int i = 0; i < _size; i++)
                {
                    newElements[i] = _elements[i];
                }

                _elements = newElements;
                Console.WriteLine($"扩容:旧容量{oldCapacity},新容量{newCapacity}");
            }

            for (var i = _size - 1; i >= index; i--)
            {
                _elements[i + 1] = _elements[i];
            }

            _elements[index] = element;
            _size++;
        }

        /// <summary>
        /// 删除index位置对应的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override T Remove(int index)
        {
            RangeCheck(index);
            var element = Get(index);
            for (int i = index; i < _size - 1; i++)
            {
                _elements[i] = _elements[i + 1];
            }

            _size--;
            //这边清除最后一个 赋值为default,不然双引用
            _elements[_size] = default;
            return element;
        }

        /// <summary>
        /// 查看元素的位置
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public override int IndexOf(T element)
        {
            if (element == null)
            {
                for (int i = 0; i < _size; i++)
                {
                    if (_elements[i] == null) return i;
                }
            }
            else
            {
                for (int i = 0; i < _size; i++)
                {
                    if (element.Equals(_elements[i])) return i;
                }
            }


            return -1;
        }

        /// <summary>
        /// 清除所有元素 引用类型需要使用default 赋值
        /// </summary>
        public override void Clear()
        {
            for (int i = 0; i < _size; i++)
            {
                _elements[i] = default;
            }

            _size = 0;
        }

        /// <summary>
        /// 扩容操作 java与.net framework实现方式类似
        /// </summary>
        /// <param name="capacity"></param>
        private void EnsureCapacity(int capacity)
        {
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(10);
            sb.Append("size = ").Append(_size).Append(", [");
            for (int i = 0; i < _size; i++)
            {
                if (i != 0)
                {
                    sb.Append(", ");
                }

                sb.Append(_elements[i]);
            }

            sb.Append("]");
            return sb.ToString();

        }
    }
}