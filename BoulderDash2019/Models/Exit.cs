using BoulderDash2019.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    public class Exit : Entity
    {
        bool open { get; set; }
        public Exit(ref Tile tile) : base (ref tile)
        {
            open = false;
        }

        internal override char getSymbol()
        {
            return 'E';
        }

        internal override bool MoveOn(DirectionEnum directionEnum, ForceEnum force)
        {
            switch (force)
            {
                case ForceEnum.PlayerPush:
                    if (open == false)
                        return false;
                    tile_ = null;
                    return true;
                default:
                    return false;
            }
        }

        internal override void Update(int frameUpdate)
        {
            
        }

        internal override bool Explode()
        {
            return false;
        }

        internal void Activate()
        {
            open = true;
        }
    }
}
