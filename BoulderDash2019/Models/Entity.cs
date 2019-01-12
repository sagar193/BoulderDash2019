using BoulderDash2019.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    public abstract class Entity
    {
        internal Tile tile_;
        protected int lastFrameUpdated_;
        protected int updateDelay;

        public Entity(ref Tile tile)
        {
            tile_ = tile;
            tile.Entity_ = this;
        }

        abstract internal char getSymbol();

        abstract internal void Update(int frameUpdate);

        protected bool shouldUpdate(int frameUpdate)
        {
            if (lastFrameUpdated_ > frameUpdate - updateDelay)
                return false;
            else
                lastFrameUpdated_ = frameUpdate;
            return true;
        }

        abstract internal bool MoveOn(DirectionEnum directionEnum, ForceEnum force);

        abstract internal bool Explode();
        
    }
}
