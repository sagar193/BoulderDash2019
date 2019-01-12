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
        public bool Running { get; set; }
        internal Rockford player { get; private set; }
        private static Game instance = null;
        OutputCMD output;
        internal InputCMD input { get; private set; }

        private Game()
        {
            levels = new Level[3];
            MapLoader mapLoader = new MapLoader();
            levels[0] = mapLoader.createLevel(LevelData.Level1);
            levels[1] = mapLoader.createLevel(LevelData.Level2);
            levels[2] = mapLoader.createLevel(LevelData.Level3);

            currentLevel = 0;
            Running = true;
            output = new OutputCMD();
            input = new InputCMD();
            
            player = new Rockford(levels[currentLevel].playerPosition);
            output.currentLevel = levels[currentLevel];
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
            Thread catchInput = new Thread(new ThreadStart(input.catchInput));
            draw.Start();
            catchInput.Start();

            play();
        }

        public void play()
        {
            levels[currentLevel].startTimer();
            int update = 0;

            while (currentLevel >= 0 && currentLevel < levels.Length)
            {
                for (int y = 0; y < levels[currentLevel].Tiles.GetLength(1); y++)
                {
                    for (int x = 0; x < levels[currentLevel].Tiles.GetLength(0); x++)
                    {
                        levels[currentLevel].Tiles[x, y].Update(update);
                    }
                }
                update++;
                Thread.Sleep(200);
            }

            levels[currentLevel].stopTimer();
        }

        public void nextLevel()
        {
            currentLevel++;
            output.currentLevel = levels[currentLevel];
        }

        public void drawGame()
        {
            while (Running)
            {
                output.Draw();
                Thread.Sleep(300);
            }
        }
    }
}
