using System;

namespace EX__05._Date_Modifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            Console.WriteLine(DateModifier.GetDaysBetweenDates(firstDate, secondDate));
        }
    }
}
