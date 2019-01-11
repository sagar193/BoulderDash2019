﻿using BoulderDash2019.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    public class Rockford : Entity
    {
        internal int score { get; private set; }
        internal bool alive { get; set; }

        public Rockford(Tile tile) : base(ref tile)
        {
            score = 0;
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
            if (tile_ == null)
                return;
            Tile newPosition = tile_.MoveToNeighbour(direction, this, ForceEnum.PlayerPush);
            if (newPosition != null)
            {
                tile_ = newPosition;
            }
        }

        internal override bool MoveOn(DirectionEnum directionEnum, ForceEnum force)
        {
            switch (force)
            {
                case ForceEnum.FireflyPush:
                    alive = false;
                    tile_.Explode(2);
                    tile_ = null;
                    return true;
                case ForceEnum.Gravity:
                    alive = false;
                    tile_.Explode(2);
                    tile_ = null;
                    return true;
                default:
                    return false;
            }
        }

        internal void addScore(int addScore)
        {
            score += addScore;
        }

        internal override bool Explode()
        {
            //tile_ = null;
            alive = false;
            return false;
        }

        internal void Explode(int v)
        {
            tile_.Explode(1);
        }
    }
}
