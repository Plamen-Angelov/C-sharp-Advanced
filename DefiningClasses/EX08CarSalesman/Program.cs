using System;

namespace EX08CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numberOfEngines = int.Parse(Console.ReadLine());
            Engine[] engines = new Engine[numberOfEngines];

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine();
                engine.Model = info[0];
                engine.Power = int.Parse(info[1]);

                if (info.Length == 3)
                {
                    int number;

                    if (int.TryParse(info[2], out number))
                    {
                        engine.Displacement = int.Parse(info[2]);
                    }
                    else
                    {
                        engine.Efficiency = info[2];
                    }
                }
                else if (info.Length == 4)
                {
                    engine.Displacement = int.Parse(info[2]);
                    engine.Efficiency = info[3];
                }

                engines[i] = engine;
            }

            int numberOfCars = int.Parse(Console.ReadLine());
            Car[] cars = new Car[numberOfCars];

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car();
                car.Model = info[0];
                string engine = info[1];

                foreach (var currentEngine in engines)
                {
                    if (currentEngine.Model == engine)
                    {
                        car.Engine = currentEngine;
                    }
                }

                if (info.Length == 3)
                {
                    int number;

                    if (int.TryParse(info[2], out number))
                    {
                        car.Weight = int.Parse(info[2]);
                    }
                    else
                    {
                        car.Color = info[2];
                    }
                }
                else if (info.Length == 4)
                {
                    car.Weight = int.Parse(info[2]);
                    car.Color = info[3];
                }

                cars[i] = car;
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
