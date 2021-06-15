using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();


            Stack<string> stringStack = new Stack<string>(input);

            while (stringStack.Count > 1)
            {
                int num1 = int.Parse(stringStack.Pop());
                char sighn = char.Parse(stringStack.Pop());
                int num2 = int.Parse(stringStack.Pop());

                if (sighn == '+')
                {
                    stringStack.Push((num1 + num2).ToString());
                }
                else
                {
                    stringStack.Push((num1 - num2).ToString());
                }
            }

            Console.WriteLine(stringStack.Peek());
        }
    }
}
