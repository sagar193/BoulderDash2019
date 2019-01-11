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

        internal void SetNeighbour(DirectionEnum direction,  ref Tile tile)
        {
            neighbours.Add(direction, tile);
        }

        internal Tile Move(DirectionEnum direction, Entity entity, int force)
        {
            neighbours[direction].Move(direction, entity, force);
        }

        internal Tile Move(DirectionEnum direction, Entity entity, int force)
        {
            if (Entity_ == null)
            {
                Entity_ = entity;
                return this;
            }
            else
            {
                if (Entity_.Move(direction, force))
                {
                    Entity_ = entity;
                    return this;
                }
                else
                    return null;
            }
        }

        internal void Update(int frameUpdate)
        {
            Entity_.Update(frameUpdate);
        }

        internal void Draw()
        {
            if (Entity_ == null)
                OutputCMD.Draw(' ');
            else
                Entity_.Draw();
        }
    }
}
