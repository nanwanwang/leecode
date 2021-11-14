using System;
using System.Collections.Generic;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> s = new Stack<int>();
        
            MyStack<int> stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            Console.WriteLine(stack);
            stack.Pop();
            Console.WriteLine(stack);
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack);
        }
    }
}