using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    class MapLoader
    {
        internal Level createLevel(char[,] blueprint)
        {
            var test = blueprint.GetLength(1);
            Level level = new Level(blueprint.GetLength(1), blueprint.GetLength(0));

            for (int x = 0; x < blueprint.GetLength(1); x++)
            {
                for (int y = 0; y < blueprint.GetLength(0); y++)
                {
                    //var tst = blueprint[y, x];
                    //var rer = createTileWithEntity(blueprint[x, y], ref level);
                    //level.addTile(x,y, rer);
                    level.addTile(x, y, createTileWithEntity(blueprint[y, x], ref level));
                }
            }

            connectTiles(ref level);
            return level;
        }

        private void connectTiles(ref Level level)
        {
            var y1= level.Tiles.GetLength(1);
            var x1 = level.Tiles.GetLength(0);
            for (int y = 0; y < level.Tiles.GetLength(1); y++)
            {
                for (int x = 0; x < level.Tiles.GetLength(0); x++)
                {
                    if (x > 0)
                        level.Tiles[x, y].SetNeighbour(DirectionEnum.Left, ref level.Tiles[x -1 , y]);
                    if (y > 0)
                        level.Tiles[x, y].SetNeighbour(DirectionEnum.Up, ref level.Tiles[x, y-1]);
                    if (x < level.Tiles.GetLength(0)-1)
                        level.Tiles[x, y].SetNeighbour(DirectionEnum.Right, ref level.Tiles[x + 1, y]);
                    if (y < level.Tiles.GetLength(1)-1)
                        level.Tiles[x, y].SetNeighbour(DirectionEnum.Down, ref level.Tiles[x, y + 1]);
                }
            }
        }

        Tile createTileWithEntity(char c, ref Level level)
        {
            Tile tile = new Tile();
            switch (c)
            {
                case 'R':
                    level.playerPosition = tile;
                    break;
                case 'B':
                    Boulder boulder = new Boulder(ref tile);
                    break;
                case 'D':
                    Diamond diamond = new Diamond(ref tile);
                    break;
                case 'F':
                    FireFly fireFly = new FireFly(ref tile);
                    break;
                case 'M':
                    Mud mud = new Mud(ref tile);
                    break;
                case 'S':
                    SteelWall steelWall = new SteelWall(ref tile);
                    break;
                case 'W':
                    Wall wall = new Wall(ref tile);
                    break;
                case ' ':
                    break;
                case 'E':
                    Exit exit = new Exit(ref tile);
                    level.addExit(exit);
                    break;
            }
            return tile;
        }
    }
}
