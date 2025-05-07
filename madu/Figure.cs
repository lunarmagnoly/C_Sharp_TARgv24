using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu
{
    class Figure
    {
        protected List<Point> pList = new List<Point>();

        public virtual void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }

        public bool IsHit(Figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }

        public bool IsHit(Point point)
        {
            foreach (var p in pList)
            {
                if (point.IsHit(p)) // Проверяем, есть ли пересечение с переданной точкой
                    return true;
            }
            return false;
        }
    }
}
