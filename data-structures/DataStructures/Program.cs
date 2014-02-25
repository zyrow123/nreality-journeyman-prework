using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch(); 
            watch.Start();
            var test1 = new List<int>();

            int counter = 0;

            while(true)
            {

                test1.Add(counter++);

                if (counter == 10) break;
            }



            Console.WriteLine(test1.GetIndex(0));

            Console.WriteLine(test1.IndexOf(0));

            var test = new Queue<int>();
            
            test.Add(1);

            test.Add(2);

            test.Add(3);

            test.Add(4);

            test.Add(5);

            Console.WriteLine(test.Length);
            Console.WriteLine(test.ReadQueue());
            Console.WriteLine(test.ReadQueue());
            Console.WriteLine(test.ReadQueue());
            Console.WriteLine(test.ReadQueue());
            Console.WriteLine(test.ReadQueue());
            Console.WriteLine(test.Length);
        }
    }
}
