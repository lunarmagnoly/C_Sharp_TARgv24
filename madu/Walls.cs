using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace madu
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            //Отрисовка рамочки

            HorizontalLine upline = new HorizontalLine(1, mapWidth - 2, 0, '═');
            HorizontalLine downline = new HorizontalLine(1, mapWidth - 2, mapHeight - 1, '═');

            VerticalLine leftline = new VerticalLine(0, 1, mapHeight - 2, '║');
            VerticalLine rightline = new VerticalLine(mapWidth - 1, 1, mapHeight - 2, '║');


            wallList.Add(upline);
            wallList.Add(downline);
            wallList.Add(leftline);
            wallList.Add(rightline);

        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
                
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
