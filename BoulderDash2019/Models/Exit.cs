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
        public Exit(ref Tile tile) : base (ref tile)
        {

        }

        internal override void Draw()
        {
            OutputCMD.Draw('E');
        }

        internal override bool MoveOn(DirectionEnum directionEnum, ForceEnum force)
        {
            throw new NotImplementedException();
        }

        internal override void Update(int frameUpdate)
        {
            
        }
    }
}
