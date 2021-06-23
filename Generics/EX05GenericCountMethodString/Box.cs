using System;
using System.Collections.Generic;

namespace EX05GenericCountMethodString
{
    public class Box<T>
    {
        public T Value { get; set; }

        public override string ToString()
        {
            return $"{typeof(T)}: {Value}".ToString();
        }

        public int CountOfGreaterElements<T>(List<T> elements, T element) where T : IComparable<T>
        {
            int count = 0;

            foreach (var item in elements)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
