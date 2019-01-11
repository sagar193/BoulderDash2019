using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace BoulderDash2019
{
    public class Level
    {
        internal Tile[,] Tiles { get; set; }
        Exit exit_;
        internal Tile playerPosition { get; set; }

        ///timers
        int levelTime;
        System.Timers.Timer timer;
        private DateTime startTime;
        private DateTime stopTime;

        public Level(int width, int height)
        {
            Tiles = new Tile[width, height];
            timer = new System.Timers.Timer();
            levelTime = 90;
        }

        public void addTile(int xIndex, int yIndex, Tile tile)
        {
            Tiles[xIndex, yIndex] = tile;
        }

        internal void addExit(Exit exit)
        {
            exit_ = exit;
        }
        
        public void startTimer()
        {
            timer.Start();

            if (startTime == null)
                startTime = DateTime.Now;
            else
                startTime += (DateTime.Now - stopTime);
        }

        public void stopTimer()
        {
            timer.Stop();
            stopTime = DateTime.Now;
        }

        public double getTimeleft()
        {
            double timeElapsed = (startTime - DateTime.Now).TotalSeconds;
            double timeLeft = levelTime + timeElapsed;
            return levelTime + timeElapsed;
        }
    }
}
