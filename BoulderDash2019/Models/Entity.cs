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
        internal int lastFrameUpdated_;

        public Entity(ref Tile tile)
        {
            tile_ = tile;
            tile.Entity_ = this;
        }
        
    }
}
