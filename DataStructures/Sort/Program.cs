using System;
using System.Collections.Generic;
using System.Thread;
using System.Threading;
namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<int> { 1,8,9,4, 3, 5, 7, 9,110 };
            var list2 = new List<int> { 1,8,9,4, 3, 5, 7, 9 };
            var list3 = new List<int> { 1,8,9,4, 3, 5, 7, 9 };
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            // BubbleSort.Sort(list);
            // BubbleSort.SortOptimization(list2);
            // BubbleSort.SortOptimization2(list3);
            SelectionSort.Sort(list);
        }
    }
}
