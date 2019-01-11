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
        InputCMD input;

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
            Thread catchInput = new Thread(new ThreadStart(input.grabInput));
            draw.Start();
            catchInput.Start();

            play();
        }

        public void play()
        {
            levels[currentLevel].startTimer();

            while (Running)
            {
                Thread.Sleep(1000);
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
