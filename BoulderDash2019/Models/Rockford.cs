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
            Tile newPosition = tile_.MoveToNeighbour(direction, this, ForceEnum.PlayerPush);
            if (newPosition != null)
            {
                tile_ = newPosition;
            }
        }

        internal override bool MoveOn(DirectionEnum directionEnum, ForceEnum force)
        {
            throw new NotImplementedException();
        }

        internal void addScore(int addScore)
        {
            score += addScore;
        }
    }
}
