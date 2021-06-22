using System;
using System.Runtime.InteropServices;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new DoublyCircleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(0,7);
 

            Console.WriteLine(list);

            list.Remove(2);
            Console.WriteLine(list);
        }
    }
}