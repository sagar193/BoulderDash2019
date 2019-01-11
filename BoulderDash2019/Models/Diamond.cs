﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    public class Diamond : Entity
    {
        public Diamond(ref Tile tile) : base(ref tile)
        {

        }

        internal override void Draw()
        {
            OutputCMD.Draw('¤');
        }

        internal override void Update(int frameUpdate)
        {
            
        }
    }
}