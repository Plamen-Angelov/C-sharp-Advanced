using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int num = int.Parse(Console.ReadLine());

            Queue<string> kids = new Queue<string>(input);

            while (kids.Count > 1)
            {
                for (int i = 0; i < num - 1; i++)
                {
                    kids.Enqueue(kids.Dequeue());
                }

                Console.WriteLine($"Removed {kids.Dequeue()}");
            }
            Console.WriteLine($"Last is {kids.Peek()}");
        }
    }
}
