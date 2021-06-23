using System;

namespace ComparingObjects
{
    public class Person:IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public string Name => name;

        public int Age => age;

        public string Town => town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);

            if (result == 0)
            {
                Age.CompareTo(other.Age);
            }

            if (result == 0)
            {
                Town.CompareTo(other.Town);
            }

            return result;
        }
    }
}
