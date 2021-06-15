using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace EX__07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int petrolStations = int.Parse(Console.ReadLine());
            long petrolInTruck = 0;
            int index = 0;

            Queue<int[]> circle = new Queue<int[]>();
            Queue<int[]> truckCircle = circle;

            for (int i = 0; i < petrolStations; i++)
            {
                int[] data = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                circle.Enqueue(data);
            }

            while (true)
            {
                int counter = 0;

                for (int i = 0; i < petrolStations; i++)
                {
                    petrolInTruck += truckCircle.Peek()[0];
                    int distanceToNextStation = truckCircle.Peek()[1];

                    if (petrolInTruck >= distanceToNextStation)
                    {
                        truckCircle.Enqueue(truckCircle.Dequeue());
                        petrolInTruck -= distanceToNextStation;
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (counter == petrolStations)
                {
                    Console.WriteLine(index);
                    return;
                }

                index++;
                circle.Enqueue(circle.Dequeue());
                truckCircle = circle;
                petrolInTruck = 0;
            }
        }
    }
}
