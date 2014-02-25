using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Container<T>
    {
        public T Value { get; set; }
        public Container<T> Head { get; set; }
        public Container<T> Tail { get; set; }
    }
}
