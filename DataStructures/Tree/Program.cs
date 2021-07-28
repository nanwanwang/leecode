using System;
using System.Collections.Generic;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 7, 4, 9, 2, 5, 8, 11, 1 };
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            foreach (var item in list)
            {
                bst.Add(item);
            }
            

            BTreePrinter.Print(bst._root);

            bst.PreorderTraversal(x => { Console.WriteLine(x); });

            Console.WriteLine("--------");
            bst.InorderTraversal(x => { Console.WriteLine(x); });

            Console.WriteLine("--------");
            bst.PostorderTraversal(x => { Console.WriteLine(x); });
            Console.WriteLine("--------");
            bst.LevelorderTraversal(x => { Console.WriteLine(x); });

            Console.WriteLine(bst.Height());
            Console.WriteLine(bst.IsComplete());

            var listPerson = new List<Person>
            {
              new Person{Name = "aa",Age=7 },
              new Person{Name = "bb",Age=4 },
              new Person{Name = "cc",Age=9 },
              new Person{Name = "dd",Age=2 },
              new Person{Name = "ee",Age=5 },
              new Person{Name = "ff",Age=8 },
              new Person{Name = "gg",Age=11 },
              new Person{Name = "hh",Age=3 },
            };

            BinarySearchTree<Person> bst2 = new BinarySearchTree<Person>();
            foreach (var item in listPerson)
            {
                bst2.Add(item);
            }

            BTreePrinter.Print(bst2._root);

            Console.WriteLine(bst2.ToString());
        }
    }
}