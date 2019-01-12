using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoulderDash2019.Enums;

namespace BoulderDash2019
{
    public abstract class GravitySensitiveEntity : Entity
    {
        bool falling;
        public GravitySensitiveEntity(ref Tile tile) : base(ref tile)
        {
            bool falling = true;
            updateDelay = 5;
        }

        protected bool move(DirectionEnum direction)
        {
            if (falling)
                return false;

            Tile newTile = tile_.MoveToNeighbour(direction, this, ForceEnum.playerPushExtend);
            if (newTile != null)
            {
                tile_ = newTile;
                return true;
            }
            else return false;
        }

        internal override bool Explode()
        {
            tile_ = null;
            return true;
        }

        internal override void Update(int frameUpdate)
        {
            if (!shouldUpdate(frameUpdate))
                return;
            Tile newPosition = tile_.MoveToNeighbour(DirectionEnum.Down, this, ForceEnum.StationaryObject);
            if (newPosition != null)
            {
                tile_ = newPosition;
                return;
            }
            newPosition = tile_.SlideNeighbour(DirectionEnum.Left, this, ForceEnum.StationaryObject);
            if (newPosition != null)
            {
                tile_ = newPosition;
                return;
            }
            newPosition = tile_.SlideNeighbour(DirectionEnum.Right, this, ForceEnum.StationaryObject);
            if (newPosition != null)
            {
                tile_ = newPosition;
                return;
            }
        }
    }
}
