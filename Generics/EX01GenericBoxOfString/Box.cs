using System;
using System.Collections.Generic;
using System.Text;

namespace EX01GenericBoxOfString
{
    public class Box<T>
    {
        public T Value { get; set; }

        public override string ToString()
        {
            return $"{typeof(T)}: {Value}".ToString();
        }
    }
}
