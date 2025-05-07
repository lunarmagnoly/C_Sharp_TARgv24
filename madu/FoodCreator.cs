using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace madu
{
    class FoodCreator
    {
        int mapWidth;
        int mapHeight;
        char sym;
        Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }


        public Point CreateFood(Figure figure)
        {
            Point food;
            do
            {
                int x = random.Next(2, mapWidth - 3);
                int y = random.Next(2, mapHeight - 3);
                food = new Point(x, y, sym);
            }
            while (figure.IsHit(food)); // Здесь будет использоваться перегрузка IsHit для Figure

            return food;
        }


    }

}

