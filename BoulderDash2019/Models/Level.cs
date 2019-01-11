using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    public class Level
    {
        internal Tile[,] Tiles { get; set; }
        Exit exit_;
        internal Tile playerPosition { get; set; }

        public Level(int width, int height)
        {
            Tiles = new Tile[width, height];
        }

        public void addTile(int xIndex, int yIndex, Tile tile)
        {
            Tiles[xIndex, yIndex] = tile;
        }

        internal void addExit(Exit exit)
        {
            exit_ = exit;
        }

        internal void Draw()
        {
            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                for (int x = 0; x < Tiles.GetLength(0); x++)
                {
                    Tiles[x, y].Draw();
                }
                OutputCMD.Draw('\n');
            }
        }
    }
}
