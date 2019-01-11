using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    public class Rockford : Entity
    {
        public Rockford(ref Tile tile) : base(ref tile)
        {

        }

        internal override void Draw()
        {
            OutputCMD.Draw('R');
        }

        internal override void Update(int frameUpdate)
        {
            
        }

        internal void Move(DirectionEnum direction)
        {
            //tile_.Move()
        }
    }
}
