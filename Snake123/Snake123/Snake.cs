using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake123
{
    class Snake : Figure
    {
        public Snake(Point tail, int lenght, Direction direction) // Положение змейки на карте (координаты ее хвоста, ее длина, 
        //в каком направлении змейка изначально ориентирована (соответственно, в каком направлении она будет двигаться)).
        {
            pList = new List<Point>();// Список.
            for(int i = 0; i < lenght; i++)
            {
                Point p = new Point(tail);// В цикле несколько раз будем создавать точки, являющимися  точной копией хвостовой точки, которую мы передаем в конструкторе.
                p.Move(i, direction);// Затем, эти точки мы хотим сдвинуть на i позиций, по направлению direction.
                pList.Add(p);// И добавить эти точки в список.
            }
        }
    }
}
