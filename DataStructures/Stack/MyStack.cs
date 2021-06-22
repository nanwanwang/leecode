using LinkedList;

namespace Stack
{
    public class MyStack<T>
    {
        private MyLinkedList<T> _myLinkedList;

        public MyStack()
        {
            _myLinkedList = new MyLinkedList<T>();
        }

        public int Size()
        {
            return _myLinkedList.Size();
        }

        public bool IsEmpty()
        {
            return _myLinkedList.IsEmpty();
        }

        public void Push(T element)
        {
            _myLinkedList.Add(element);
        }

        public T Pop()
        {
            return _myLinkedList.Remove(_myLinkedList.Size() - 1);
        }

        public T Peek()
        {
            return _myLinkedList.Get(_myLinkedList.Size() - 1);
        }

        public override string ToString()
        {
            return _myLinkedList.ToString();
        }
    }
}