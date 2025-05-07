using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu
{
    class Corner : Figure  //как бы фигура углы, в тч для использования рисования именно фигура
    {
        
        public Corner(int mapWidth, int mapHeight)
        {
            
            pList = new List<Point>();

            // Угловые точки
            pList.Add(new Point(0, 0, '╔'));          // Левый верх
            pList.Add(new Point(mapWidth - 1, 0, '╗'));    // Правый верх
            pList.Add(new Point(0, mapHeight - 1, '╚'));   // Левый низ
            pList.Add(new Point(mapWidth - 1, mapHeight - 1, '╝')); // Правый низ

        }
    }
}
