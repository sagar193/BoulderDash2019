using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BoulderDash2019
{
    public sealed class Game
    {
        Level[] levels;
        int currentLevel;
        bool playing;
        public Rockford player { get; private set; }
        private static Game instance = null;

        private Game()
        {
            levels = new Level[3];
            MapLoader mapLoader = new MapLoader();
            levels[0] = mapLoader.createLevel(LevelData.Level1);
            levels[1] = mapLoader.createLevel(LevelData.Level2);
            levels[2] = mapLoader.createLevel(LevelData.Level3);

            currentLevel = 0;
            playing = true;
            player = new Rockford(levels[currentLevel].playerPosition);
        }

        public static Game Instance
        {
            get
            {
                if (instance == null)
                    instance = new Game();
                return instance;
            }
        }

        public void startGame()
        {
            Thread draw = new Thread(new ThreadStart(drawGame));
            draw.Start();

            play();
        }

        public void play()
        {
            levels[currentLevel].startTimer();
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
                    case ConsoleKey.E:
                        player.Explode(2);
                        break;
                    default:

                        break;
                }
            }
            levels[currentLevel].stopTimer();
        }

        public void drawGame()
        {
            while (playing)
            {
                OutputCMD.ClearScreen();
                OutputCMD.DrawScore(player.score);
                OutputCMD.DrawWhiteSpace();
                levels[currentLevel].Draw();
                Thread.Sleep(300);
            }
        }
    }
}
