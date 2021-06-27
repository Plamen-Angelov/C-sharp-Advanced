using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count { get => data.Count; }

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public void Add(Car car)
        {
            if (Capacity > Count)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            foreach (var car in data)
            {
                if (car.Manufacturer == manufacturer && car.Model == model)
                {
                    data.Remove(car);
                    return true;
                }
            }
            return false;
        }

        public Car GetLatestCar()
        {
            return data.OrderByDescending(c => c.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            foreach (var car in data)
            {
                if (car.Manufacturer == manufacturer && car.Model == model)
                {
                    return car;
                }
            }
            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");
            sb.AppendLine($"{string.Join('\n', data)}");

            return sb.ToString().TrimEnd();
        }
    }
}
