using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func<int[], int> GetMinValue = nums => nums.Min();

            Func<int[], int> GetMinValue = nums =>
            {
                int min = int.MaxValue;

                foreach (var n in nums)
                {
                    if (n < min)
                    {
                        min = n;
                    }
                }
                return min;
            };

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int minNum = GetMinValue(numbers);
            Console.WriteLine(minNum);
        }
    }
}
