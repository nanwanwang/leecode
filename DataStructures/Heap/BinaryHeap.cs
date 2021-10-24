using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    /// <summary>
    /// 最大堆
    /// 索引i 的规律(n 是元素的数量)
    /// 如果 i=0,它是根节点
    /// 如果i>0,它的父节点的索引为floor((i-1)/2)
    /// 如果2i+1<=  n+1 它的左子节点的索引为2i+1
    ///  如果2i+1> n-1 ,它无左子节点
    ///  
    /// 如果2i+2<= n-1,它的右子节点的索引为2i+2
    /// 如果2i+2> n-1,它无右子节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryHeap<T> : IHeap<T>
    {
        private T[] _elements;
        private int _size;
        private Comparer<T> _comparer;

        private const int DEFAULT_CAPACITY = 10;

        public BinaryHeap(Comparer<T> comparer)
        {
            _comparer = comparer;
            _elements = new T[DEFAULT_CAPACITY];
        }


        public BinaryHeap():this(null)
        {
            
        }

        /// <summary>
        /// 新增元素
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            ElementNotNullCheck(element);
            EnsureCapacity(_size + 1);

            _elements[_size++] = element;
            SiftUp(_size - 1);
           
        }


        /// <summary>
        /// 上滤过程 时间复杂度O(logn)
        /// </summary>
        /// <param name="index"></param>
        private void SiftUp(int index)
        {
            //如果node >父节点
            //与父节点交换位置
            T t = _elements[index];
            while (index>0)
            {
                int pIndex = (index - 1) >> 1;
                T p = _elements[pIndex];
                if (Compare(t, p) <= 0) return;

                T tmp = _elements[index];
                _elements[index] = _elements[pIndex];
                _elements[pIndex] = tmp;

                index = pIndex;
            }


            //如果node<=父节点,或者node没有父节点 退出循环 
        }

        public void Clear()
        {
            for (int i = 0; i < _size; i++)
            {
                _elements[i] = default(T);
            }
            _size = 0;
        }

        /// <summary>
        /// 获取堆顶
        /// </summary>
        /// <returns></returns>
        public T Get()
        {
            EmptyCheck();
            return _elements[0];
        }

       

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public T Remove()
        {
            throw new NotImplementedException();
        }

        public T Replace(T element)
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            return _size;
        }

        private int Compare(T e1,T e2)
        {
            return _comparer != null ? _comparer.Compare(e1, e2) : ((IComparable<T>)e1).CompareTo(e2);
        }


        /// <summary>
        /// 扩容
        /// </summary>
        /// <param name="capacity"></param>
        private void EnsureCapacity(int capacity)
        {
            int oldCapacity = _elements.Length;
            if (oldCapacity >= capacity) return;
            int newCapacity = oldCapacity + (oldCapacity >> 1);
            T[] newElements = new T[newCapacity];
            for (int i = 0; i < _size; i++)
            {
                newElements[i] = _elements[i];
            }

            _elements = newElements;
            
        }

        private void EmptyCheck()
        {
            if (_size == 0)
                throw new IndexOutOfRangeException("Heap is empty.");
        }

        private void ElementNotNullCheck(T element)
        {
            if (element == null)
                throw new ArgumentNullException("element must not be null.");
        }
    }
}
