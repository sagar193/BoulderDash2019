using BoulderDash2019.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    public class FireFly : Entity
    {
        private DirectionEnum lastMovedDirection;

        public FireFly(ref Tile tile) : base(ref tile)
        {
            lastMovedDirection = 0;
            updateDelay = 3;
            lastMovedDirection = DirectionEnum.Up;
        }

        internal override char getSymbol()
        {
            return 'F';
        }

        internal override bool MoveOn(DirectionEnum directionEnum, ForceEnum force)
        {
            switch (force)
            {
                case ForceEnum.FallingObject:
                    tile_.Explode(1);
                    return true;
                default:
                    return false;
            }
        }

        internal override void Update(int frameUpdate)
        {
            if (!shouldUpdate(frameUpdate))
                return;

            if (lastMovedDirection == DirectionEnum.Left) ///do down left up
            {
                if (move(DirectionEnum.Down))
                    return;
                if (move(DirectionEnum.Left))
                    return;
                if (move(DirectionEnum.Up))
                    return;
                else
                    lastMovedDirection = DirectionEnum.Up;
            }
            if (lastMovedDirection == DirectionEnum.Down) ///do right down left
            {
                if (move(DirectionEnum.Right))
                    return;
                if (move(DirectionEnum.Down))
                    return;
                if (move(DirectionEnum.Left))
                    return;
                else
                    lastMovedDirection = DirectionEnum.Left;
                return;
            }
            if (lastMovedDirection == DirectionEnum.Up) /// do left up right
            {
                if (move(DirectionEnum.Left))
                    return;
                if (move(DirectionEnum.Up))
                    return;
                if (move(DirectionEnum.Right))
                    return;
                else
                    lastMovedDirection = DirectionEnum.Right;
            }
            if (lastMovedDirection == DirectionEnum.Right) /// do up right down
            {
                if (move(DirectionEnum.Up))
                    return;
                if (move(DirectionEnum.Right))
                    return;
                if (move(DirectionEnum.Down))
                    return;
                else
                    lastMovedDirection = DirectionEnum.Down;
            }
        }

        private bool move(DirectionEnum direction)
        {
            Tile newPosition = tile_.MoveToNeighbour(direction, this, ForceEnum.FireflyPush);
            if (newPosition != null)
            {
                tile_ = newPosition;
                lastMovedDirection = direction;
                return true;
            }
            return false;
        }

        internal override bool Explode()
        {
            tile_ = null;
            return true;
        }
    }
}
