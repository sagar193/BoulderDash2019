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
        public GravitySensitiveEntity(ref Tile tile) : base(ref tile)
        {
        }

        protected bool move(DirectionEnum direction)
        {
            Tile newTile = tile_.MoveToNeighbour(direction, this, ForceEnum.playerPushExtend);
            if (newTile != null)
            {
                tile_ = newTile;
                return true;
            }
            else return false;
        }
    }
}
