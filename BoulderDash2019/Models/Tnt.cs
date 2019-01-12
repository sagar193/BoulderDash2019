using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoulderDash2019.Enums;

namespace BoulderDash2019.Models
{
    class Tnt : GravitySensitiveEntity
    {
        int frameExist;
        bool falling;
        public Tnt(ref Tile tile) : base(ref tile)
        {
            frameExist = 0;
            updateDelay = 5;
            falling = false;
        }

        internal override char getSymbol()
        {
            return 't';
        }

        internal override bool MoveOn(DirectionEnum directionEnum, ForceEnum force)
        {
            throw new NotImplementedException();
        }

        internal override void Update(int frameUpdate)
        {
            if (frameExist == 0)
                frameExist = frameUpdate;
            if (frameUpdate > frameExist + 10 * 30)
                tile_.Explode(1);
            if (!shouldUpdate(frameUpdate))
                return;
            if (!base.fall())
                stopFalling();
            else
                falling = true;
        }

        internal override void stopFalling()
        {
            if (falling == true)
                tile_.Explode(1);
        }
    }
}
