using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu
{
    class Programm
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            //// устанавливаем размер консоли
            //Console.SetWindowSize(80, 25);
            //Console.SetBufferSize(80, 25);

            Walls walls = new Walls(120, 30);
            walls.Draw();

            ////углы
            Corner corners = new Corner(120, 30);
            corners.Draw();

            Point p = new Point(60, 15, '■'); //как вариант для тела ■(!!! попробовать покрасить) ▀
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(119, 29, '■');//предположим змейка каннибал пока не разберусьс с символами поинтереснее
            Point food = foodCreator.CreateFood(snake);

            food.Draw();
            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood(snake);
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);


                }

                

            }


            Console.ReadLine();

            
            
        }
    }
}