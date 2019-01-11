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
        protected bool exploding;

        public Entity(ref Tile tile)
        {
            tile_ = tile;
            tile.Entity_ = this;
        }

        abstract internal void Draw();

        abstract internal void Update(int frameUpdate);

        abstract internal bool Move(DirectionEnum directionEnum, int force);
        
    }
}
