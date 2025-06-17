using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu
{
    internal class Score
    {
       
            private int score;

            // Конструктор, инициализируем счет в 0
            public Score()
            {
                score = 0;
            }

            // Метод для увеличения счета
            public void Increase()
            {
                score++;
            }

            // Метод для получения текущего счета
            public int GetScore()
            {
                return score;
            }

            // Метод для отображения счета (можно вызывать в каждом обновлении экрана)
            public void Display()
            {
                Console.SetCursorPosition(55, 1); // Позиционируем курсор на верхней строке
                Console.Write($"Score: {score}");
            }

            // Сброс счета (например, при начале новой игры)
            public void Reset()
            {
                score = 0;
            }
        


    }
}
