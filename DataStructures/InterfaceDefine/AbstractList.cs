using System;

namespace InterfaceDefine
{
    public abstract class AbstractList<T> : IList<T>
    {
        const int ELEMENT_NOT_FOUND = 1;

        protected int _size;

        public int Size()
        {
            return _size;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != ELEMENT_NOT_FOUND;
        }

        public void Add(T element)
        {
            Add(_size, element);
        }

        public abstract T Get(int index);

        public abstract T Set(int index, T element);

        public abstract void Add(int index, T element);

        public abstract T Remove(int index);
        public abstract int IndexOf(T element);

        public abstract void Clear();


        private void OutOfBounds(int index)
        {
            throw new IndexOutOfRangeException("Index:" + index + ", Size:" + _size);
        }

        protected void RangeCheck(int index)
        {
            if (index < 0 || index >= _size)
            {
                OutOfBounds(index);
            }
        }

        protected void RangeCheckForAdd(int index)
        {
            if (index < 0 || index > _size)
            {
                OutOfBounds(index);
            }
        }
    }
}