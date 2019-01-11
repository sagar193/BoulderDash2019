using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BoulderDash2019
{
    class Game
    {
        Level[] levels;
        int currentLevel;
        bool playing;
        Rockford player;

        public Game()
        {
            levels = new Level[3];
            MapLoader mapLoader = new MapLoader();
            levels[0] = mapLoader.createLevel(LevelData.Level1);
            levels[1] = mapLoader.createLevel(LevelData.Level2);
            levels[2] = mapLoader.createLevel(LevelData.Level3);

            currentLevel = 0;
            playing = true;
            player = new Rockford(ref levels[currentLevel].playerPosition.tile_);
        }

        public void startGame()
        {
            Thread draw = new Thread(new ThreadStart(drawGame));
            draw.Start();

            play();
        }

        public void play()
        {
            while (playing)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        player.Move(DirectionEnum.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        player.Move(DirectionEnum.Right);
                        break;
                    case ConsoleKey.UpArrow:
                        player.Move(DirectionEnum.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        player.Move(DirectionEnum.Down);
                        break;
                    default:

                        break;
                }
            }
        }

        public void drawGame()
        {
            while (playing)
            {
                OutputCMD.ClearScreen();
                levels[currentLevel].Draw();
                Thread.Sleep(300);
            }
        }


    }
}
