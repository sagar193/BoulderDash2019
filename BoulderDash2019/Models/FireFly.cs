using BoulderDash2019.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    public class FireFly : Entity
    {
        public FireFly(ref Tile tile) : base(ref tile)
        {

        }

        internal override void Draw()
        {
            OutputCMD.Draw('F');
        }

        internal override bool MoveOn(DirectionEnum directionEnum, ForceEnum force)
        {
            switch (force)
            {
                case ForceEnum.Gravity:
                    tile_.Explode(2);
                    return true;
                default:
                    return false;
            }
        }

        internal override void Update(int frameUpdate)
        {
            if (lastFrameUpdated_ == frameUpdate)
                return;
            else
                lastFrameUpdated_ = frameUpdate;

        }

        internal override bool Explode()
        {
            tile_ = null;
            return true;
        }
    }
}
