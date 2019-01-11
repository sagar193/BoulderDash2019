using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BoulderDash2019
{
    static class OutputCMD
    {
        static public void Draw(char c)
        {
            Console.Write(c);
        }

        static public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
