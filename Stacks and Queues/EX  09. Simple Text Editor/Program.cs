using System;
using System.Collections.Generic;
using System.Text;

namespace EX__09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int operations = int.Parse(Console.ReadLine());

            Stack<string> stringStack = new Stack<string>();
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < operations; i++)
            {
                string command = Console.ReadLine();
                string[] data = command
                    .Split();
                    

                if (command.StartsWith("1"))
                {
                    stringStack.Push(text.ToString());
                    string stringToAdd = command.Substring(2).Replace(" ", "");
                    text.Append(stringToAdd);
                }
                else if (command.StartsWith("2"))
                {
                    stringStack.Push(text.ToString());
                    int count = int.Parse(data[1]);
                    text = text.Remove(text.Length - count, count);
                }
                else if (command.StartsWith("3"))
                {
                    int index = int.Parse(data[1]) - 1;

                    if (index >= 0 && index < text.Length)
                    {
                        Console.WriteLine(text[index]);
                    }
                }
                else if (command.StartsWith('4'))
                {
                    text.Clear();
                    text.Append(stringStack.Pop());
                }
            }
        }
    }
}
