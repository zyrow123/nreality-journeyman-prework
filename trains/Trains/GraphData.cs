using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains
{
    public class GraphData
    {
        public List<Town> Towns { get; set; }
        public List<Path> Paths { get; set; }

        public GraphData()
        {
            Towns = new List<Town>();
            Paths = new List<Path>();
        }

        public Town GetTown(string townName)
        {
            return Towns.SingleOrDefault(x => x.Name.Equals(townName));
        }

        public List<Path> GetPathsByStartTown(Town town)
        {
            return Paths.Where(x => x.StartTown == town).OrderBy(x => x.Distance).ToList();
        }

        public Town AddTown(Town town)
        {
            if (!Towns.Any(x => x.Name.Equals(town.Name)))
            {
                Towns.Add(town);

                return town;
            }

            return Towns.Single(x => x.Name.Equals(town.Name));
        }

        public void CreatePath(Path path)
        {
            if (!Paths.Any(x => x.StartTown == path.StartTown && x.EndTown == path.EndTown && x.Distance == path.Distance))
            {
                Paths.Add(path);
            }

            ReCalculateFromToPaths(path);
        }

        public void ReCalculateFromToPaths(Path newPath)
        {
            foreach (var path in Paths.Where(x => x.EndTown == newPath.EndTown || x.EndTown == newPath.StartTown || x.StartTown == newPath.StartTown || x.StartTown == newPath.EndTown))
            {
                path.FromPaths = Paths.Where(x => x.StartTown == path.EndTown).ToList();
                path.ToPaths = Paths.Where(x => x.EndTown == path.StartTown).ToList();
            }
        }

        public Town[] GetTownsFromNames(string[] names)
        {
            var towns = new List<Town>();

            foreach (var name in names)
            {
                var knownTown = Towns.SingleOrDefault(x => x.Name.Equals(name));
                if (knownTown != null)
                {
                    towns.Add(knownTown);
                }
            }

            return towns.ToArray();
        }

    }
}
