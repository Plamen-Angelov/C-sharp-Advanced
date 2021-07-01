using System;
using System.Linq;

namespace RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sum = Sum(array, 0);
            Console.WriteLine(sum);
        }

        private static int Sum(int[] array, int v)
        {
            if (v == array.Length)
            {
                return 0;
            }

            return array[v] + Sum(array, v+1);
        }
    }
}
