using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> collection;

        private int currentIndex;

        public ListyIterator(params T[] data )
        {
            collection = new List<T>(data);
            currentIndex = 0;
        }

        public List<T> List => collection;


        public bool Move()
        {
            if (HasNext())
            {
                currentIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HasNext()
        {
            return currentIndex + 1 < collection.Count;
        }

        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine($"{collection[currentIndex]}");
        }
    }
}
