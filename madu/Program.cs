using System;
using C_Sharp_TARgv24;

namespace madu
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(110, 65);    // окно (лучше чуть больше стен)
            Console.SetBufferSize(110, 65);    // буфер (тоже чуть больше стен)
            Console.CursorVisible = false;

            HighScores highScores = new HighScores();
            Sounds sounds = new Sounds();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== SNAKE======");
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Dashboard");
                Console.WriteLine("3. Exit");
                Console.Write("Choose: ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    StartGame(highScores, sounds);
                }
                else if (input == "2")
                {
                    highScores.ShowTopResults();
                }
                else if (input == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный выбор. Нажмите любую клавишу...");
                    Console.ReadKey();
                }
            }
        }

        

        static void StartGame(HighScores highScores, Sounds sounds)
        {
            Console.Clear();
            sounds.PlayMusic();

            Walls walls = new Walls(100, 60);
            walls.Draw();
            Corner corners = new Corner(100, 60);
            corners.Draw();

            Point p = new Point(10, 10, '■');
            Snake snake = new Snake(p, 3, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(58, 18, 'o');
            Point food = foodCreator.CreateFood(snake);
            food.Draw();

            Score score = new Score();
            Level level = new Level();
            Speed speed = new Speed();

            if (score.GetScore() % 5 == 0)
            {
                level.NextLevel();
                speed.SpeedUp();
                // Сообщение на экране:
                Console.SetCursorPosition(25, 10);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("LEVEL UP!");
                Console.ResetColor();
                System.Threading.Thread.Sleep(700); // показать 0.7 сек
                                                    // Стереть сообщение:
                Console.SetCursorPosition(25, 10);
                Console.Write("         "); // столько пробелов, сколько букв в "LEVEL UP!"
            }


            bool gameOver = false;

            while (!gameOver)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    sounds.PlayGameOver();
                    gameOver = true;
                    break;
                }

                if (snake.Eat(food))
                {
                    score.Increase();
                    food = foodCreator.CreateFood(snake);
                    food.Draw();
                    sounds.PlayEat();
                    score.Display();
                    if (score.GetScore() % 5 == 0)
                    {
                        level.NextLevel();
                        speed.SpeedUp();
                    }
                }
                else
                {
                    snake.Move();
                }

                score.Display();
                level.Display();
                speed.Display();

                System.Threading.Thread.Sleep(speed.CurrentDelay);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                    if (key.Key == ConsoleKey.Escape)
                    {
                        gameOver = true;
                        break;
                    }
                }
            }

            sounds.StopMusic();
            sounds.PlayGameOver();

            // Имя игрока и сохранение результата
            string name = "";
            do
            {
                Console.SetCursorPosition(10, 15);
                Console.Write("Enter name (min. 3 characters):      ");
                Console.SetCursorPosition(45, 15);
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name) || name.Trim().Length < 3);

            Player player = new Player(name.Trim(), score.GetScore());
            highScores.SaveResult(player);

            highScores.ShowTopResults();

            Console.SetCursorPosition(10, 19);
            Console.Write("Press any button to return to menu...");
            Console.ReadKey();
        }
    }
}
