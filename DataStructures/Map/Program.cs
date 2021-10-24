using System;
using System.Collections.Generic;

namespace Map
{
    class Program
    {
        static void Main(string[] args)
        {
   
            Dictionary<object, string> dic = new Dictionary<object, string>();
            dic.Add("test", "1243");
            var p1 = new Person { Name = "Jack", Age = 10, Height = 1.7f };
            var p2 = new Person { Name = "Jack", Age = 10, Height = 1.7f };


            dic.Add(p1, "123");
            dic.Add(p2, "456");
            Console.WriteLine( p1==p2);
            Console.WriteLine("p1:"+p1.GetHashCode());
            Console.WriteLine("p2:" + p2.GetHashCode());
            Console.WriteLine(dic.Count);
        }
    }

  
}
