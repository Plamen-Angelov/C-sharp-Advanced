using System;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Car[] cars = new Car[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionPerKilometer = double.Parse(input[2]);

                Car currenCar = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                cars[i] = currenCar;
            }

            string inputData = Console.ReadLine();

            while (inputData != "End")
            {
                string[] tokens = inputData
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[1];
                double distance = double.Parse(tokens[2]);

                foreach (var car in cars)
                {
                    if (car.Model == model)
                    {
                        car.Travel(distance);
                    }
                }

                inputData = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
