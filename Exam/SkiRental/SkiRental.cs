using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private readonly List<Ski> data;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }

        public void Add(Ski ski)
        {
            if (Capacity > Count)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            return data.Remove(data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model));
        }

        public Ski GetNewestSki()
        {
            if (Count == 0)
            {
                return null;
            }
            return data.OrderByDescending(s => s.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");
            if (Count > 0)
            {
                sb.AppendLine(string.Join('\n', data));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
