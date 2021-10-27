using System.Collections.Generic;

namespace Sort
{
    //选择排序  交换逻辑在外层for循环里面总体性能高于冒泡排序好
    public class SelectionSort
    {
         public static void Sort(List<int> list)
         {
             for (int i = 0; i < list.Count-1; i++)
             {
                int maxIndex = 0;
                //j使用<= list.Count -1 -i 因为里面没有使用到 j +1 冒泡排序使用到了 所以用< 
                for (int j = 1; j <= list.Count - 1 - i; j++)
                {
                    if (list[maxIndex]<=list[j])
                    {
                        maxIndex = j;
                    }
                }
                var temp = list[maxIndex];
                list[maxIndex] = list[list.Count-1-i];
                list[list.Count-1-i] = temp;
            }

            list.ForEach(x=>System.Console.WriteLine(x));
         }
    }
}