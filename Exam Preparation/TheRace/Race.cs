using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private readonly List<Racer> data;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;


        public Race(string name, int capacity)
        {
            data = new List<Racer>();

            Name = name;
            Capacity = capacity;
        }

        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            foreach (var racer in data)
            {
                if (racer.Name == name)
                {
                    data.Remove(racer);
                    return true;
                }
            }
            return false;
        }

        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(r => r.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(r => r.Car.Speed).FirstOrDefault();
        }

        //public int Count()
        //{
        //    return data.Count;
        //}

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {Name}:");
            sb.AppendLine($"{string.Join('\n', data)}");

            return sb.ToString().TrimEnd();
        }
    }
}
