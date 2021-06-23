using System;
using System.Collections.Generic;

namespace EX06GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                numbers.Add(num);
            }

            double element = double.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            int countOfGreaterElements = box.CountOfGreaterElements<double>(numbers, element);
            Console.WriteLine(countOfGreaterElements);
        }
    }
}
