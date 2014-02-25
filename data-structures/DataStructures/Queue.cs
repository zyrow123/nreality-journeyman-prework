using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Queue<T>:Collection<T>
    {
        public T ReadQueue()
        {
            if (Length == 0)
                throw new Exception("No elements in queue");

            var value = GetTailValue();

            Pop();

            return value;
        }

        public void Add(T anything)
        {
            Push(anything);
        }
    }
}
