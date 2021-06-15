using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace EX__10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<Queue<char>> cars = new Queue<Queue<char>>();
            string command = Console.ReadLine();
            int carsCounter = 0;

            while (command != "END")
            {
                if (command == "green")
                {
                    int remainingTimeOfGreen = greenLightDuration;

                    while (cars.Count > 0 && remainingTimeOfGreen >= cars.Peek().Count)
                    {
                        remainingTimeOfGreen -= cars.Dequeue().Count;
                        carsCounter++;
                    }

                    if (cars.Count == 0 || remainingTimeOfGreen == 0)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    else if (remainingTimeOfGreen + freeWindow >= cars.Peek().Count)
                    {
                        carsCounter++;
                    }
                    else
                    {
                        string car = string.Empty;
                        
                        foreach (var ch in cars.Peek())
                        {
                            car += ch;
                        }

                        int timeToPass = remainingTimeOfGreen + freeWindow;
                        Console.WriteLine($"A crash happened!");
                        Console.WriteLine($"{car} was hit at {car[timeToPass]}.");
                        return;
                    }
                }
                else
                {
                    Queue<char> newCarInTraffic = new Queue<char>();

                    for (int i = 0; i < command.Length; i++)
                    {
                        newCarInTraffic.Enqueue(command[i]);

                    }   

                    cars.Enqueue(newCarInTraffic);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsCounter} total cars passed the crossroads.");
        }
    }
}
