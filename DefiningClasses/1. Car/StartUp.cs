using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car {Make = "VW", Model = "Golf", Year = 2020};
            
            Console.Write($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}
