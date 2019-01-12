using BoulderDash2019.Enums;
using BoulderDash2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    public class Wall : StationaryEntity
    {
        public Wall(ref Tile tile) : base(ref tile)
        {

        }

        internal override char getSymbol()
        {
            return 'W';
        }

        internal override bool MoveOn(DirectionEnum directionEnum, ForceEnum force)
        {
            return false;
        }

        internal override bool Explode()
        {
            tile_ = null;
            return true;
        }
    }
}
