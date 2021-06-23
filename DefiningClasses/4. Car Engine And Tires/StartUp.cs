using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Tire[] tires = new Tire[4]
            {
                new Tire(1, 2.2),
                new Tire(1, 2.3),
                new Tire(1, 2.2),
                new Tire(1, 2.3),
            };

            Engine engine = new Engine(110, 1700);

            Car car = new Car("opel", "astra", 2011, 60, 7, engine, tires);
        }
    }
}
