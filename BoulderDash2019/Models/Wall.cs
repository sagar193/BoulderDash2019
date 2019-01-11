using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    public class Wall : Entity
    {
        public Wall(ref Tile tile) : base(ref tile)
        {

        }

        internal override void Draw()
        {
            OutputCMD.Draw('W');
        }

        internal override bool Move(DirectionEnum directionEnum, int force)
        {
            throw new NotImplementedException();
        }

        internal override void Update(int frameUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
