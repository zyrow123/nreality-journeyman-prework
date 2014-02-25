using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains
{
    public class DistinctPath
    {
        public Town Town { get; private set; }
        public int DistanceToNextTown { get; set; }
        public DistinctPath NextTown { get; set; }
        public DistinctPath PreviousTown { get; private set; }

        public DistinctPath(Town town)
        {
            Town = town;
        }

        public DistinctPath(DistinctPath distinctPath, Town town)
        {
            PreviousTown = distinctPath;
            Town = town;
        }

        public DistinctPath(DistinctPath distinctPath, Town town, int distanceToNextTown)
        {
            PreviousTown = distinctPath;
            Town = town;
            DistanceToNextTown = distanceToNextTown;
        }
    }
}
