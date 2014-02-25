using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains
{
    public class PathEnumerationCriteria
    {
        public List<Path> SearchPaths { get; set; }
        public Town EndTown { get; set; }
        public DistinctPath DistinctPath { get; set; }
        public int MaxSearchDepth { get; set; }
        public int CurrentSearchDepth { get; set; }
        public int MinSearchDepth { get; set; }
        public int MaxPathDistance { get; set; }

        public PathEnumerationCriteria(List<Path> searchPaths, Town endTown, DistinctPath distinctPath, int maxSearchDepth)
        {
            SearchPaths = searchPaths;
            EndTown = endTown;
            DistinctPath = distinctPath;
            MaxSearchDepth = maxSearchDepth;
            CurrentSearchDepth = 0;
            MinSearchDepth = -1;
            MaxPathDistance = -1;
        }

        public PathEnumerationCriteria(List<Path> searchPaths, Town endTown, DistinctPath distinctPath, int maxSearchDepth, int currentSearchDepth)
        {
            SearchPaths = searchPaths;
            EndTown = endTown;
            DistinctPath = distinctPath;
            MaxSearchDepth = maxSearchDepth;
            CurrentSearchDepth = currentSearchDepth;
            MinSearchDepth = -1;
            MaxPathDistance = -1;
        }

        public PathEnumerationCriteria(List<Path> searchPaths, Town endTown, DistinctPath distinctPath, int maxSearchDepth, int currentSearchDepth, int minSearchDepth)
        {
            SearchPaths = searchPaths;
            EndTown = endTown;
            DistinctPath = distinctPath;
            MaxSearchDepth = maxSearchDepth;
            CurrentSearchDepth = currentSearchDepth;
            MinSearchDepth = minSearchDepth;
            MaxPathDistance = -1;
        }

        public PathEnumerationCriteria(List<Path> searchPaths, Town endTown, DistinctPath distinctPath, int maxSearchDepth, int currentSearchDepth, int minSearchDepth, int maxPathDistance)
        {
            SearchPaths = searchPaths;
            EndTown = endTown;
            DistinctPath = distinctPath;
            MaxSearchDepth = maxSearchDepth;
            CurrentSearchDepth = currentSearchDepth;
            MinSearchDepth = minSearchDepth;
            MaxPathDistance = maxPathDistance;
        }

        public PathEnumerationCriteria(PathEnumerationCriteria criteria, Path searchPath, DistinctPath distinctPath)
        {
            SearchPaths = searchPath.FromPaths.OrderBy(x => x.Distance).ToList();
            EndTown = criteria.EndTown;
            DistinctPath = distinctPath;
            MaxSearchDepth = criteria.MaxSearchDepth;
            CurrentSearchDepth = criteria.CurrentSearchDepth;
            MinSearchDepth = criteria.MinSearchDepth;
            MaxPathDistance = criteria.MaxPathDistance;
        }
    }
}
