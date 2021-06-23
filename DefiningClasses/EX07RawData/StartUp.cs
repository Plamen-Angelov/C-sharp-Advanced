using System;
using System.Linq;

namespace EX07RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Car[] cars = new Car[n];

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = info[0];
                int engineSpeed = int.Parse(info[1]);
                int enginePower = int.Parse(info[2]);
                int cargoWeight = int.Parse(info[3]);
                string cargoType = info[4];
                double tire1Pressure = double.Parse(info[5]);
                int tire1Age = int.Parse(info[6]);
                double tire2Pressure = double.Parse(info[7]);
                int tire2Age = int.Parse(info[8]);
                double tire3Pressure = double.Parse(info[9]);
                int tire3Age = int.Parse(info[10]);
                double tire4Pressure = double.Parse(info[11]);
                int tire4Age = int.Parse(info[12]);

                Engine engine = new Engine() {Speed = engineSpeed, Power = enginePower};
                Cargo cargo = new Cargo() {Weight = cargoWeight, Type = cargoType};
                Car car = new Car();
                car.Tires = new Tire[4]
                {
                    new Tire() {Pressure = tire1Pressure, Year = tire1Age},
                    new Tire() {Pressure = tire2Pressure, Year = tire2Age},
                    new Tire() {Pressure = tire3Pressure, Year = tire3Age},
                    new Tire() {Pressure = tire4Pressure, Year = tire4Age},
                };

                car.Model = model;
                car.Cargo = cargo;
                car.Engine = engine;

                cars[i] = car;
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars = cars
                    .Where(c => c.Cargo.Type == "fragile")
                    .Where(c => c.Tires.Any(t => t.Pressure < 1))
                    .ToArray();
            }
            else if (command == "flamable")
            {
                cars = cars
                    .Where(c => c.Cargo.Type == "flamable")
                    .Where(c => c.Engine.Power > 250)
                    .ToArray();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
