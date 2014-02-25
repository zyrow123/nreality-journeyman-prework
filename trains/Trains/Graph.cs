using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains
{
    public class Graph
    {
        private GraphData _data = new GraphData();

        public void AddPath(string stratName, string endName, int distance)
        {
            var startTown = _data.AddTown(new Town(stratName));
            var endTown = _data.AddTown(new Town(endName));

            _data.CreatePath(new Path(startTown, endTown, distance));
        }

        public bool TryCalculatePathDistance(string [] townNames, out int distance)
        {
            var pathExists = true;
            distance = 0;
            var towns = _data.GetTownsFromNames(townNames);
            
            for(int index = 0; index < towns.Length - 1; index++)
            {
                var startPaths = _data.GetPathsByStartTown(towns[index]);

                //var distinctPaths = PathEnumeration(startPaths, towns[index + 1], new DistinctPath(towns[index]), 1);

                var distinctPaths = PathEnumeration(new PathEnumerationCriteria(startPaths, towns[index + 1], new DistinctPath(towns[index]), 1));

                var pathDistance = GetDistanceFromEndToStart(distinctPaths.FirstOrDefault());

                if (pathDistance == -1)
                {
                    pathExists = false;
                    break;
                }

                distance += pathDistance;
            }

            return pathExists;
        }

        public int DistinctPaths(string startTownName, string endTownName, int searchDepth)
        {
            var startTown = _data.GetTown(startTownName);
            var endTown = _data.GetTown(endTownName);
            var startPaths = _data.GetPathsByStartTown(startTown);

            return PathEnumeration(new PathEnumerationCriteria(startPaths, endTown, new DistinctPath(startTown), searchDepth)).Count;
        }

        public int DistinctMinStopPaths(string startTownName, string endTownName, int searchDepth, int minStops)
        {
            var startTown = _data.GetTown(startTownName);
            var endTown = _data.GetTown(endTownName);
            var startPaths = _data.GetPathsByStartTown(startTown);

            return PathEnumeration(new PathEnumerationCriteria(startPaths, endTown, new DistinctPath(startTown), searchDepth,0, minStops)).Count;
        }

        public int FastestRouteDistance(string startTownName, string endTownName)
        {
            var startTown = _data.GetTown(startTownName);
            var endTown = _data.GetTown(endTownName);
            var startPaths = _data.GetPathsByStartTown(startTown);

            var distinctPaths = PathEnumeration(new PathEnumerationCriteria(startPaths, endTown, new DistinctPath(startTown), 3));

            var shortestDistance = int.MaxValue;

            foreach (var distinctPath in distinctPaths)
            {
                var routeDistance = GetDistanceFromEndToStart(distinctPath);

                if (routeDistance != -1 && routeDistance < shortestDistance)
                {
                    shortestDistance = routeDistance;
                }
            }

            return shortestDistance;
        }

        public int NumberOfRoutesWithMaxDistance(string startTownName, string endTownName, int maxDistance)
        {
            var startTown = _data.GetTown(startTownName);
            var endTown = _data.GetTown(endTownName);
            var startPaths = _data.GetPathsByStartTown(startTown);

            var distinctPaths = PathEnumeration(new PathEnumerationCriteria(startPaths, endTown, new DistinctPath(startTown), -1, 0, -1, maxDistance));

            var routes = 0;

            foreach (var distinctPath in distinctPaths)
            {
                var routeDistance = GetDistanceFromEndToStart(distinctPath);

                if (routeDistance != -1 && routeDistance < maxDistance)
                {
                    routes++;
                }
            }

            return routes;
        }

        private List<DistinctPath> PathEnumeration(PathEnumerationCriteria criteria)
        {
            var distinctPaths = new List<DistinctPath>();

            criteria.CurrentSearchDepth++;
            if (criteria.MinSearchDepth == -1 || criteria.CurrentSearchDepth == criteria.MinSearchDepth)
            {
                AddDistinctPaths(criteria, distinctPaths);
            }

            var distance = GetDistanceFromEndToStart(criteria.DistinctPath);

            if ((criteria.CurrentSearchDepth < criteria.MaxSearchDepth || criteria.MaxSearchDepth == -1) && (criteria.MaxPathDistance == -1 || distance < criteria.MaxPathDistance))
            {
                ContinuePathEnumartaion(criteria, distinctPaths);
            }

            return distinctPaths;
        }

        private void AddDistinctPaths(PathEnumerationCriteria criteria, List<DistinctPath>  distinctPaths)
        {
            var foundPaths = criteria.SearchPaths.Where(x => x.EndTown == criteria.EndTown).OrderBy(x => x.Distance).ToList();
            foreach (var path in foundPaths)
            {
                criteria.DistinctPath.DistanceToNextTown = path.Distance;
                criteria.DistinctPath.NextTown = new DistinctPath(criteria.DistinctPath, criteria.EndTown);

                distinctPaths.Add(criteria.DistinctPath.NextTown);
            }
        }

        private void ContinuePathEnumartaion(PathEnumerationCriteria criteria, List<DistinctPath> distinctPaths)
        {
            foreach (var searchPath in criteria.SearchPaths)
            {
                var newDistinctPath = new DistinctPath(criteria.DistinctPath.PreviousTown, criteria.DistinctPath.Town, searchPath.Distance);
                newDistinctPath.NextTown = new DistinctPath(newDistinctPath, searchPath.EndTown);
                
                var innerDistinctPaths =
                    PathEnumeration(new PathEnumerationCriteria(criteria, searchPath, newDistinctPath.NextTown));
                if (innerDistinctPaths.Any())
                {
                    distinctPaths.AddRange(innerDistinctPaths);
                }
            }
        }

        private int GetDistanceFromEndToStart(DistinctPath path)
        {
            if (path == null || path.PreviousTown == null)
            {
                return -1;
            }

            var distance = 0;

            while (path.PreviousTown != null)
            {
                path = path.PreviousTown;
                distance += path.DistanceToNextTown;
            }

            return distance;
        }
    }
}
