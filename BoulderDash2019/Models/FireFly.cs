﻿using System;
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

        internal override void Update(int frameUpdate)
        {
            
        }
    }
}