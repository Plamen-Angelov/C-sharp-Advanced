using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string str = Console.ReadLine();

            while (str != "END")
            {
                string[] car = str
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (car[0] == "IN")
                {
                    cars.Add(car[1]);
                }
                else if (car[0] == "OUT")
                {
                    cars.Remove(car[1]);
                }

                str = Console.ReadLine();
            }

            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            
        }
    }
}
