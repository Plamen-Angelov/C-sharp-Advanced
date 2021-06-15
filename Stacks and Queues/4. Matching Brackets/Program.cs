using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> openBrecketIndex = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    openBrecketIndex.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startIndex = openBrecketIndex.Pop();
                    Console.WriteLine(input.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
