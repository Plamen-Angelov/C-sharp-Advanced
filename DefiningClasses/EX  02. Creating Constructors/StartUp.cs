using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person pesho = new Person();
            Console.WriteLine($"{pesho.Name} - {pesho.Age}");

            Person misho = new Person(35);
            Console.WriteLine($"{misho.Name} - {misho.Age}");

            Person gosho = new Person("Gosho", 28);
            Console.WriteLine($"{gosho.Name} - {gosho.Age}");
        }
    }
}
