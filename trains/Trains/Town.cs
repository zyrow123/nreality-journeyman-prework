using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains
{
    public class Town
    {
        public string Name { get; private set; }

        public Town(string name)
        {
            Name = name;
        }
    }
}
