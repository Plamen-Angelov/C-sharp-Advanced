using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] data = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = data[0];
                int age = int.Parse(data[1]);
                string town = data[2];

                Person person = new Person(name, age, town);
                persons.Add(person);
                command = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            int equals = 0;
            Person compareWithPerson = persons[index];


            foreach (var current in persons)
            {
                int comparision = compareWithPerson.CompareTo(current);

                if (comparision == 0)
                {
                    equals++;
                }
            }

            if (equals == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equals} {persons.Count - equals} {persons.Count}");
            }
        }
    }
}
