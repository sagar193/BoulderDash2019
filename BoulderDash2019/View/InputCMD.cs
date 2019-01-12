using System;
using System.Collections.Concurrent;

namespace BoulderDash2019
{
    class InputCMD
    {
        private ConcurrentQueue<ConsoleKeyInfo> inputQueue;

        public InputCMD()
        {
            inputQueue = new ConcurrentQueue<ConsoleKeyInfo>();
        }

        internal void catchInput()
        {
            while (Game.Instance.Running)
            {
                var input = Console.ReadKey();
                lock (inputQueue)
                {
                    inputQueue.Enqueue(input);
                    while (inputQueue.Count > 3)
                    {
                        ConsoleKeyInfo overflow;
                        inputQueue.TryDequeue(out overflow);
                    }

                }
            }
        }

        internal ConsoleKeyInfo grabInputFromQueue()
        {
            ConsoleKeyInfo input;

            lock(inputQueue)
            {
                inputQueue.TryDequeue(out input);
            }
            return input;
        }

    }
}
/*var key = Console.ReadKey();
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
                */
