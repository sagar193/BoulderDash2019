using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019
{
    class Game
    {
        Level[] levels;
        static void Main(string[] args)
        {
            Console.WriteLine("test");

            Game game = new Game();
            Console.ReadKey();
        }

        public Game()
        {
            levels = new Level[3];
            MapLoader mapLoader = new MapLoader();
            levels[0] = mapLoader.createLevel(LevelData.Level1);
            levels[1] = mapLoader.createLevel(LevelData.Level2);
            levels[2] = mapLoader.createLevel(LevelData.Level3);
        }
    }
}
