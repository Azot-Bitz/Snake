using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake123
{
    class Point
    {
        public int x;
        public int y;
        public char sym;

        public Point()
        {

        }
        public Point(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }// конструктор с помощью которого можно задавать точки с помощью другой точки.

        public void Move(int offset, Direction direction)
        {
            if(direction == Direction.RIGHT)
            {
                x = x + offset;// x увеличиваем на размер смещения.
            }
            else if(direction == Direction.LEFT)
            {
                x = x - offset;
            }
            else if(direction == Direction.UP)
            {
                y = y + offset;
            }
            else if(direction == Direction.DOWN)
            {
                y = y - offset;
            }// метод Move, который будет сдвигать данную точку на расстояние offset, по направлению Direction.
        }
        public override string ToString()
        {
            return x + "," + y + "," + sym;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
    }
}
