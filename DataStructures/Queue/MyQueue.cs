using LinkedList;

namespace Queue
{
    public class MyQueue<T>
    {
        private DoublyLinkedList<T> _myLinkedList;

        public MyQueue()
        {
            _myLinkedList = new DoublyLinkedList<T>();
        }

        public int Size()
        {
            return _myLinkedList.Size();
        }

        public bool IsEmpty()
        {
            return _myLinkedList.IsEmpty();
        }

        public void Enqueue(T element)
        {
            _myLinkedList.Add(element);
        }

        public T DeQueue()
        {
            return _myLinkedList.Remove(0);
        }

        public T Front()
        {
            return _myLinkedList.Get(0);
        }

        public void Clear()
        {
             _myLinkedList.Clear();
        }

        public override string ToString()
        {
            return _myLinkedList.ToString();
        }
    }
}