using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();

            string inputTires = Console.ReadLine();

            while (inputTires != "No more tires")
            {
                string[] tiresInfo = inputTires
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                Tire[] currentTires = new Tire[4]
                {
                    new Tire(int.Parse(tiresInfo[0]), double.Parse(tiresInfo[1])),
                    new Tire(int.Parse(tiresInfo[2]), double.Parse(tiresInfo[3])),
                    new Tire(int.Parse(tiresInfo[4]), double.Parse(tiresInfo[5])),
                    new Tire(int.Parse(tiresInfo[6]), double.Parse(tiresInfo[7])),
                };

                tires.Add(currentTires);
                inputTires = Console.ReadLine();
            }

            List<Engine> engines = new List<Engine>();

            string inputEngine = Console.ReadLine();

            while (inputEngine != "Engines done")
            {
                string[] engineInfo = inputEngine
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int horsePowwer = int.Parse(engineInfo[0]);
                double cubicCapasity = double.Parse(engineInfo[1]);

                Engine currentEngine = new Engine(horsePowwer, cubicCapasity);

                engines.Add(currentEngine);
                inputEngine = Console.ReadLine();
            }

            List<Car> cars = new List<Car>();

            string inputCar = Console.ReadLine();
            
            while (inputCar != "Show special")
            {
                string[] carInfo = inputCar
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Car currentCar = new Car()
                {
                    Make = carInfo[0],
                    Model = carInfo[1],
                    Year = int.Parse(carInfo[2]),
                    FuelQuantity = double.Parse(carInfo[3]),
                    FuelConsumption = double.Parse(carInfo[4]),
                    Engine = engines[int.Parse(carInfo[5])],
                    Tires = tires[int.Parse(carInfo[6])]
                };
                cars.Add(currentCar);

                inputCar = Console.ReadLine();
            }

            List<Car> specialCars = cars
                .Where(c => c.Year >= 2017)
                .Where(c => c.Engine.HorsePower > 330)
                .Where(c => c.Tires.Sum(t => t.Pressure) >= 9
                            && c.Tires.Sum(t => t.Pressure) <= 10)
                .ToList();

            foreach (var car in specialCars)
            {
                car.Drive(20);

                Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\n" +
                                  $"HorsePowers: {car.Engine.HorsePower}\n" +
                                  $"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
