using System;

namespace EX07Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Tuple<string, string> tuple1 = new Tuple<string, string>($"{names[0]} { names[1]}", names[2]);
            Console.WriteLine($"{tuple1.Item1} -> {tuple1.Item2}");

            string[] personInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = personInfo[0];
            int littersOfBeer = int.Parse(personInfo[1]);
            Tuple<string, int> tuple2 = new Tuple<string, int>(name, littersOfBeer);
            Console.WriteLine($"{tuple2.Item1} -> {tuple2.Item2}");

            string[] info = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int intNum = int.Parse(info[0]);
            double doubleNum = double.Parse(info[1]);
            Tuple<int, double> numbers = new Tuple<int, double>(intNum, doubleNum);
            Console.WriteLine($"{numbers.Item1} -> {numbers.Item2}");
        }
    }
}
