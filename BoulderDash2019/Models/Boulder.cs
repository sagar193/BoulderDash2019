using BoulderDash2019.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    public class Boulder : GravitySensitiveEntity
    {
        public Boulder(ref Tile tile) : base(ref tile)
        {

        }

        internal override void Draw()
        {
            OutputCMD.Draw('B');
        }

        internal override bool MoveOn(DirectionEnum directionEnum, ForceEnum force)
        {
            switch (force)
            {
                case ForceEnum.PlayerPush:
                    if (directionEnum == DirectionEnum.Up)
                        return false;
                    else
                        return move(directionEnum);
                default:
                    return false;
            }
        }

        internal override void Update(int frameUpdate)
        {
            
        }
    }
}
