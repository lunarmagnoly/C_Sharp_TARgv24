using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu
{
    internal class Speed
    {
        public int CurrentDelay { get; private set; } = 120;
        public void SpeedUp()
        {
            if (CurrentDelay > 40) CurrentDelay -= 10;
        }
        public void Display()
        {
            Console.SetCursorPosition(25, 1);
            Console.Write($"Speed: {120 - CurrentDelay + 1} ");
        }
    }
}
