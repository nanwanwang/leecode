using System;
using System.Collections.Generic;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<int> { 1, 45, 54, 17, 89 };
            BubbleSort.Sort(list);
        }
    }
}
