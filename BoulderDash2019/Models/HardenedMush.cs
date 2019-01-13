using BoulderDash2019.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    class HardenedMush : StationaryEntity
    {
        int hardness;
        public HardenedMush(ref Tile tile) : base(ref tile)
        {
            hardness = 3;
        }

        internal override char getSymbol()
        {
            return 'H';
        }

        internal override bool MoveOn(DirectionEnum directionEnum, ForceEnum force)
        {
            switch (force)
            {
                case ForceEnum.PlayerPush:
                    return move();
                default:
                    return false;
            }
        }

        internal override bool Explode()
        {
            tile_ = null;
            return true;
        }

        private bool move()
        {
            if (hardness <= 0)
            {
                tile_ = null;
                return true;
            }
            hardness--;
            return false;
        }
    }
}
