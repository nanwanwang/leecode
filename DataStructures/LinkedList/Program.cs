using System;
using System.Runtime.InteropServices;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyLinkedList2<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);


            Console.WriteLine(list);

            list.Remove(2);
            Console.WriteLine(list);
        }
    }
}