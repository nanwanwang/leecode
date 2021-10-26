using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class BubbleSort
    {
        public static void Sort(List<int> list)
        {

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
                }
            }



            list.ForEach(x => Console.WriteLine(x));

        }
    }
}

