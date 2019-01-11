using BoulderDash2019.Enums;
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
        int explosionCounter;

        public Tile()
        {
            neighbours = new Dictionary<DirectionEnum, Tile>();
            explosionCounter = 0;
        }

        public Tile(ref Entity entity)
        {
            Entity_ = entity;
        }

        internal void SetNeighbour(DirectionEnum direction,  ref Tile tile)
        {
            neighbours.Add(direction, tile);
        }

        internal void Explode(int v)
        {
            explosionCounter = 4;
            if (v > 0)
            {
                foreach (var neighbour in neighbours)
                {
                    neighbour.Value.Explode(v - 1);
                }
            }
            if (Entity_ != null)
            {
                bool destroyed = Entity_.Explode();
                if (destroyed)
                    Entity_ = null;
            }

        }

        internal Tile MoveToNeighbour(DirectionEnum direction, Entity entity, ForceEnum force)
        {
            Tile successTile = neighbours[direction].MoveOn(direction, entity, force);
            if (successTile != null)
            {
                Entity_ = null;
                return successTile;
            }
            else return null;
        }

        internal Tile MoveOn(DirectionEnum direction, Entity entity, ForceEnum force)
        {
            if (Entity_ == null)
            {
                Entity_ = entity;
                return this;
            }
            else
            {
                if (Entity_.MoveOn(direction, force))
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
            if (explosionCounter > 0)
            {
                explosionCounter--;
                if (Entity_ != null)
                    Entity_.Explode();
            }
            if(Entity_ != null)
            {
                Entity_.Update(frameUpdate);
            }
        }

        internal char GetSymbol()
        {
            if (explosionCounter > 0)
            {
                return 'O';
            }
            if (Entity_ == null)
                return ' ';
            else
                return Entity_.getSymbol();
        }
    }
}
