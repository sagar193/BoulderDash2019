﻿using BoulderDash2019.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    public abstract class Entity
    {
        internal Tile tile_;
        protected int lastFrameUpdated_;

        public Entity(ref Tile tile)
        {
            tile_ = tile;
            tile.Entity_ = this;
        }

        abstract internal void Draw();

        abstract internal void Update(int frameUpdate);

        abstract internal bool MoveOn(DirectionEnum directionEnum, ForceEnum force);

        abstract internal bool Explode();
        
    }
}
