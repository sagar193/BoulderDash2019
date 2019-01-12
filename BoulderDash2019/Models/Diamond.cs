using BoulderDash2019.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    public class Diamond : GravitySensitiveEntity
    {
        public Diamond(ref Tile tile) : base(ref tile)
        {

        }

        internal override char getSymbol()
        {
            return '¤';
        }

        internal override bool MoveOn(DirectionEnum directionEnum, ForceEnum force)
        {
            switch (force)
            {
                case ForceEnum.PlayerPush:
                    Game.Instance.player.addScore(100);
                    Game.Instance.removeDiamondCount();
                    tile_ = null;
                    return true;
                default:
                    return false;
            }
        }
    }
}
