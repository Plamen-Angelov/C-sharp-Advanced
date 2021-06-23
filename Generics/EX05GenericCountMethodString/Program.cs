using System;
using System.Collections.Generic;

namespace EX05GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> strs = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();

                strs.Add(str);
            }

            string element = Console.ReadLine();
            Box<string> box = new Box<string>();

            int countOfGreaterElements = box.CountOfGreaterElements<string>(strs, element);
            Console.WriteLine(countOfGreaterElements);
        }
    }
}
