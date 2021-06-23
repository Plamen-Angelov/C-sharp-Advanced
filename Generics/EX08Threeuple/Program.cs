using System;
using System.Text;

namespace EX08Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = $"{names[0]} {names[1]}";
            string adres = names[2];
            StringBuilder town = new StringBuilder();

            for (int i = 3; i < names.Length; i++)
            {
                town.Append($"{names[i]} ");
            }

            Tuple<string, string, string> tuple1 = new Tuple<string, string, string>(name, adres, town.ToString());

            Console.WriteLine($"{tuple1.Item1} -> {tuple1.Item2} -> {tuple1.Item3}");



            string[] personInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string personName = personInfo[0];
            int littersOfBeer = int.Parse(personInfo[1]);
            bool isDrunk = personInfo[2] == "drunk";

            Tuple<string, int, bool> tuple2 = new Tuple<string, int, bool>(personName, littersOfBeer, isDrunk);
            Console.WriteLine($"{tuple2.Item1} -> {tuple2.Item2} -> {tuple2.Item3}");




            string[] info = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string person = info[0];
            double bankBalance = double.Parse(info[1]);
            string bankName = info[2];

            Tuple<string, double, string> personStat = new Tuple<string, double, string>(person, bankBalance, bankName);
            Console.WriteLine($"{personStat.Item1} -> {personStat.Item2} -> {personStat.Item3}");
        }
    }
}
