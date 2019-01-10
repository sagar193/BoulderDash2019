using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    public class Level
    {
        internal Tile[,] Tiles { get; set; }
        int diamonds_;
        Exit exit_;
        public Level(int width, int height)
        {
            Tiles = new Tile[width, height];
            diamonds_ = 0;
        }

        public void addTile(int xIndex, int yIndex, Tile tile)
        {
            Tiles[xIndex, yIndex] = tile;
        }

        public void addDiamondCount()
        {
            diamonds_++;
        }

        internal void addExit(Exit exit)
        {
            exit_ = exit;
        }
    }
}
