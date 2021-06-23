using System.Collections.Generic;
using System;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking()
        {

        }

        public Parking(int capacity)
        {
            Cars = new List<Car>();
        }

        public List<Car> Cars { get; set; }

        public int Capacity { get; private set; }


        public void AddCar(Car car)
        {
            if (Cars.Count == 0)
            {
                Cars.Add(car);
                Console.WriteLine($"Successfully added new car {car.Make} {car.RegistartionNumber}");
            }
            else
            {
                foreach (var c in Cars)
                {
                    if (c.RegistartionNumber == car.RegistartionNumber)
                    {
                        Console.WriteLine($"Car with that registration number, already exists!");
                        break;
                    }
                }

                if (Cars.Count == Capacity)
                {
                    Console.WriteLine($"Parking is full!");
                }
                else
                {
                    Cars.Add(car);
                    Console.WriteLine($"Successfully added new car {car.Make} {car.RegistartionNumber}");
                }
            }
        }

            

        public void RemoveCar(string registartionNumber)
        {
            if (Cars.Count == 0)
            {

            }
            else
            {
                foreach (var car in cars)
            {
                if (car.RegistartionNumber == registartionNumber)
                {
                    cars.Remove(car);
                    Console.WriteLine($"Successfully removed {registartionNumber}");
                    break;
                }

                Console.WriteLine($"Car with that registration number, doesn't exist!");
            }
            }
            
        }

        public Car GetCar(string registartionNumber)
        {
            foreach (var car in cars)
            {
                if (car.RegistartionNumber == registartionNumber)
                {
                    return car;
                }
            }
            Car car1 = new Car();
            return car1;
        }

        public void RemoveSetOfRegistrationNumbers(List<string> registrationNumbers)
        {
            foreach (var rn in registrationNumbers)
            {
                foreach (var car in cars)
                {
                    if (car.RegistartionNumber == rn)
                    {
                        cars.Remove(car);
                    }
                }
            }
        }
    }
}
