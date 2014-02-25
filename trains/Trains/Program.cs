using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();

            graph.AddPath("A","B",5);
            graph.AddPath("B","C",4);
            graph.AddPath("C","D",8);
            graph.AddPath("D","C",8);
            graph.AddPath("D","E",6);
            graph.AddPath("A","D",5);
            graph.AddPath("C","E",2);
            graph.AddPath("E","B",3);
            graph.AddPath("A","E",7);


            QuestionOneToFive(graph, new[] { "A", "B", "C" }, 1);
            QuestionOneToFive(graph, new[] { "A", "D" }, 2);
            QuestionOneToFive(graph, new[] { "A", "D", "C" }, 3);
            QuestionOneToFive(graph, new[] { "A", "E", "B", "C", "D" }, 4);
            QuestionOneToFive(graph, new[] { "A", "E", "D" }, 5);

            Output(6, graph.DistinctPaths("C", "C", 3).ToString());

            Output(7, graph.DistinctMinStopPaths("A", "C", 4, 4).ToString());

            Output(8, graph.FastestRouteDistance("A", "C").ToString());

            Output(9, graph.FastestRouteDistance("B", "B").ToString());

            Output(10, graph.NumberOfRoutesWithMaxDistance("C", "C",30).ToString());

            Console.ReadLine();
        }

        static void QuestionOneToFive(Graph graph,string[] townNames, int outputNumber)
        {
            var distance = 0;

            if (graph.TryCalculatePathDistance(townNames, out distance))
            {
                Output(outputNumber, distance.ToString());
            }
            else
            {
                Output(outputNumber, "NO SUCH ROUTE");
            }
        }

        static void Output(int outputNumber, string result)
        {
            Console.WriteLine(string.Format("Output #{0}: {1}", outputNumber, result));
        }
    }
}
