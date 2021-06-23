using System;
using System.Collections.Generic;
using System.Text;

namespace EX07Tuple
{
    public class Tuple <T, V, U>
    {
        public T Item1 { get; set; }

        public V Item2 { get; set; }

        public U Item3 { get; set; }

        public Tuple()
        {

        }

        public Tuple(T item1, V item2, U item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }
    }
}
