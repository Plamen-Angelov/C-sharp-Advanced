using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int counter = 0;
            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "green")
                {
                    if (cars.Count >= num)
                    {
                        for (int i = 0; i < num; i++)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            counter++;
                        }
                    }
                    else
                    {
                        while (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            counter++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
