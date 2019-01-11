using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BoulderDash2019
{
    public class OutputCMD
    {
        internal Level currentLevel { get; set; }

        public OutputCMD()
        {

        }

        public void Draw()
        {
            ClearScreen();
            DrawScore(Game.Instance.player.score);
            DrawWhiteSpace();
            DrawTimeLeft((int)currentLevel.getTimeleft());
            for (int y = 0; y < currentLevel.Tiles.GetLength(1); y++)
            {
                for (int x = 0; x < currentLevel.Tiles.GetLength(0); x++)
                {
                    Console.Write(currentLevel.Tiles[x, y].GetSymbol());
                }
                Console.Write('\n');
            }
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void DrawScore(int score)
        {
            Console.Write("Score: " + score);
        }

        public void DrawWhiteSpace()
        {
            Console.Write("\t\t");
        }

        public void DrawTimeLeft(int time)
        {
            Console.Write("Time left: " + time +"\n");
        }
    }
}
