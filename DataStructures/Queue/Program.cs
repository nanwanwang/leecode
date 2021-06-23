using System;
using System.Xml;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            // var queue = new CircleQueue<int>();
            // for (int i = 0; i < 10; i++)
            // {
            //     queue.EnQueue(i); 
            // }
            // Console.WriteLine(queue);
            //
            // for (int i = 0; i < 5; i++)
            // {
            //     queue.DeQueue();
            // }
            //
            // Console.WriteLine(queue);
            //
            // for (int i = 15; i <30; i++)
            // {
            //     queue.EnQueue(i);
            //     
            // }
            //
            // Console.WriteLine(queue);

            var dqueue = new CirceDeque<string>();
            for (int i = 0; i < 10; i++)
            {
                dqueue.EnQueueFront((i+1).ToString());
                dqueue.EnqueueRear((i+100).ToString());
            }

            Console.WriteLine(dqueue);
        }
    }
}