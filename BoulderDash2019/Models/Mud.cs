using BoulderDash2019.Enums;
using BoulderDash2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    public class Mud : StationaryEntity
    {
        public Mud(ref Tile tile) : base(ref tile)
        {

        }

        internal override char getSymbol()
        {
            return '▒';
        }

        internal override bool MoveOn(DirectionEnum directionEnum, ForceEnum force)
        {
            switch (force)
            {
                case ForceEnum.PlayerPush:
                    tile_ = null;
                    return true;
                default:
                    return false;
            }
        }
        
        internal override bool Explode()
        {
            tile_ = null;
            return true;
        }
    }
}
