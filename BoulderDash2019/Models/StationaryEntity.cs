using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    public abstract class StationaryEntity : Entity
    {
        public StationaryEntity(ref Tile tile) : base(ref tile)
        {

        }

        internal override void Update(int frameUpdate)
        {

        }
    }
}
