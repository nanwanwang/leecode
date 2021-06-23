using LinkedList;

namespace Queue
{
    /// <summary>
    /// 双端队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Deque<T>
    {
        private DoublyLinkedList<T> _doublyLinkedList;

        public Deque()
        {
            _doublyLinkedList = new DoublyLinkedList<T>();
        }

        public int Size()
        {
            return _doublyLinkedList.Size();
        }

        public bool IsEmpty()
        {
            return _doublyLinkedList.IsEmpty();
        }

        /// <summary>
        /// 从队尾入队
        /// </summary>
        /// <param name="element"></param>
        public void EnqueueRear(T element)
        {
            _doublyLinkedList.Add(_doublyLinkedList.Size(),element);
        }

        /// <summary>
        /// 从对头出队
        /// </summary>
        /// <returns></returns>
        public T DeQueueFront()
        {
            return _doublyLinkedList.Remove(0);
        }


        /// <summary>
        /// 从队头入队
        /// </summary>
        /// <param name="element"></param>
        public void EnQueueFront(T element)
        {
           _doublyLinkedList.Add(0,element);
        }

        /// <summary>
        /// 从队尾出队
        /// </summary>
        /// <returns></returns>
        public T DeQueueRear()
        {
            return _doublyLinkedList.Remove(_doublyLinkedList.Size() - 1);
        }

        /// <summary>
        /// 获取队头元素
        /// </summary>
        /// <returns></returns>
        public T Front()
        {
            return _doublyLinkedList.Get(0);
        }

        /// <summary>
        /// 获取队尾元素
        /// </summary>
        /// <returns></returns>
        public T Rear()
        {
            return _doublyLinkedList.Get(_doublyLinkedList.Size() - 1);
        }

        public override string ToString()
        {
            return _doublyLinkedList.ToString();
        }
    }
}