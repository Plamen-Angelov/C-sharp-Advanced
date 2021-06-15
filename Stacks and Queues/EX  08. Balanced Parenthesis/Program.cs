using System;
using System.Collections.Generic;

namespace EX__08._Balanced_Parenthesis_SECOND_TRY
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> openParenthesis = new Stack<char>();
            Queue<char> closeParenthesis = new Queue<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (i < input.Length / 2)
                {
                    openParenthesis.Push(input[i]);
                }
                else
                {
                    closeParenthesis.Enqueue(input[i]);
                }
            }

            if (openParenthesis.Count != closeParenthesis.Count)
            {
                Console.WriteLine("NO");
                return;
            }

            int size = openParenthesis.Count;
            
            for (int i = 0; i < size; i++)
            {
            
                if (openParenthesis.Peek() == '(' && closeParenthesis.Peek() != ')')
                {
                    Console.WriteLine("NO");
                    return;
                }
                else if (openParenthesis.Peek() == '{' && closeParenthesis.Peek() != '}')
                {
                    Console.WriteLine("NO");
                    return;
                }
                else if (openParenthesis.Peek() == '[' && closeParenthesis.Peek() != ']')
                {
                    Console.WriteLine("NO");
                    return;
                }
            
                openParenthesis.Pop();
                closeParenthesis.Dequeue();
            }
            Console.WriteLine("YES");
        }
    }
}