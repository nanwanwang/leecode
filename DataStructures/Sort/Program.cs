using System;
using System.Collections.Generic;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<int> { 1,8,9,4, 3, 5, 7, 9 };
            var list2 = new List<int> { 1,8,9,4, 3, 5, 7, 9 };
            var list3 = new List<int> { 1,8,9,4, 3, 5, 7, 9 };
            BubbleSort.Sort(list);
            BubbleSort.SortOptimization(list2);
            BubbleSort.SortOptimization2(list3);
           
        }
    }
}
