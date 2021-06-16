using System;

namespace DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var personList = new ArrayList<Person>();
            personList.Add(new Person() {Age = 1, Name = "demon"});
            personList.Add(new Person() {Age = 2, Name = "demon2"});
            personList.Add(new Person() {Age = 3, Name = "demon3"});
            personList.Add(null);
            var index = personList.IndexOf(new Person() {Age = 3, Name = "demon3"});
            Console.WriteLine(index);
            var index2 = personList.IndexOf(null);
            Console.WriteLine(index2);

            var arrayList = new ArrayList<int>();
            arrayList.Add(0);
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            arrayList.Add(4);
            arrayList.Add(5);
            arrayList.Add(6);
            arrayList.Add(7);
            arrayList.Add(8);
            arrayList.Add(arrayList.Size(), 109);
            arrayList.Add(100);


            arrayList.Remove(2);

            Console.WriteLine(arrayList);

            arrayList.Add(2, 2);

            Console.WriteLine("====================");

            Console.WriteLine(arrayList);
            Console.WriteLine("Hello World!");
        }
    }
}