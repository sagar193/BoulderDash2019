using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    public class Tile
    {
        public Entity Entity_ { get; internal set; }
        public Dictionary<DirectionEnum, Tile> neighbours;

        public Tile()
        {
            neighbours = new Dictionary<DirectionEnum, Tile>();
        }

        public Tile(ref Entity entity)
        {
            Entity_ = entity;
        }

        internal void SetNeighbour(DirectionEnum direction, Tile tile)
        {
            neighbours.Add(direction, tile);
        }
    }
}
