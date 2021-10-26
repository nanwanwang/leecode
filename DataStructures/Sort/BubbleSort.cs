using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    /// bubble sort 最差时间复杂度  O(n^2) 最好时间复杂度O(n)
    public class BubbleSort
    {
        ///
        /// 普通冒泡
        ///
        public static void Sort(List<int> list)
        {
            int n = 0;

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;

                    }
                    n++;
                }
            }

            list.ForEach(x => Console.WriteLine(x));
            System.Console.WriteLine($"Sort比较了{n}次");
        }

        /// 如果数据本来就是有序的 就直接跳出循环
        public static void SortOptimization(List<int> list)
        {
            int n = 0;
            for (int i = 0; i < list.Count; i++)
            {
                var sorted = true;
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        var temp = list[j + 1];
                        list[j + 1] = list[j];
                        list[j] = temp;
                        sorted = false;
                    }

                    n++;
                }
              
                if (sorted) break;
            }

            list.ForEach(x => System.Console.WriteLine(x));
            System.Console.WriteLine($"SortOptimization 比较了{n}次");
        }


        ///局部已经有序就不需要再做交换判断
        public static void SortOptimization2(List<int> list)
        {
            int n =0;
            for (int end = list.Count - 1; end > 0; end--)
            {
                int sortedIndex = 1;
                for (int start = 1; start <= end; start++)
                {
                    if(list[start-1]>list[start])
                    {
                        var temp = list[start-1];
                        list[start-1] = list[start];
                        list[start] = temp;
                        sortedIndex = start;
                    }
                    n++;
                }

                end = sortedIndex;

            }

            list.ForEach(x => System.Console.WriteLine(x));
             System.Console.WriteLine($"SortOptimization2 比较了{n}次");
        }
    }
}

