using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
       private readonly Dictionary<string, Employee> data;

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new Dictionary<string, Employee>();
        }

        public void Add(Employee employee)
        {
            if (Capacity > Count)
            {
                data.Add(employee.Name, employee);
            }
        }

        public bool Remove(string name)
        {
            return data.Remove(name);
        }

        public Employee GetOldestEmployee()
        {
            Employee oldest = new Employee();

            foreach (var item in data.OrderByDescending(p => p.Value.Age))
            {
                oldest = item.Value;
                break;
            }

            return oldest;
        }

        public Employee GetEmployee(string name)
        {
            return data[name];
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var item in data)
            {
                sb.AppendLine($"{item.Value}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
