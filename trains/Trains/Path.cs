using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains
{
    public class Path
    {
        public Town StartTown { get; private set; }

        public Town EndTown { get; private set; }

        public int Distance { get; private set; }

        public List<Path> FromPaths { get; set; }
        public List<Path> ToPaths { get; set; }

        public Path(Town startTown,Town endTown, int distance )
        {
            StartTown = startTown;
            EndTown = endTown;
            Distance = distance;

            FromPaths = new List<Path>();
            ToPaths = new List<Path>();
        }
    }
}
