using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace madu
{
    class Snake : Figure
    {
        Direction direction;
        public Snake(Point tail, int lenght, Direction _direction)
        {
            direction = _direction;
            pList = new List<Point>();
            for (int i = 0; i < lenght; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        internal void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        internal bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }





        public void HandleKey(ConsoleKey key)//добавила что нельзя менять направление на противоположное
        {
            
            if (direction != Direction.RIGHT && key == ConsoleKey.LeftArrow)
            {
                direction = Direction.LEFT;
            }
            else if (direction != Direction.LEFT && key == ConsoleKey.RightArrow)
            {
                direction = Direction.RIGHT;
            }
            else if (direction != Direction.DOWN && key == ConsoleKey.UpArrow)
            {
                direction = Direction.UP;
            }
            else if (direction != Direction.UP && key == ConsoleKey.DownArrow)//add wasd controll if possible
            {
                direction = Direction.DOWN;
            }
        }
        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }else { return false; }
        }

        public override void Draw()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }
    }    
}
