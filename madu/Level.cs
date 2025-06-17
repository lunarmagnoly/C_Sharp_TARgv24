using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu
{
    internal class Level
    {
        public int CurrentLevel { get; private set; } = 1;
        public void NextLevel()
        {
            CurrentLevel++;
        }
        public void Display()
        {
            Console.SetCursorPosition(10, 1);
            Console.Write($"Level: {CurrentLevel} ");
        }
    }
}
