using System;
using System.Collections.Generic;
using System.Text;

namespace EX07Tuple
{
    public class Tuple <T, V>
    {
        public T Item1 { get; set; }

        public V Item2 { get; set; }

        public Tuple()
        {

        }


        public Tuple(T item1, V item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }
}
