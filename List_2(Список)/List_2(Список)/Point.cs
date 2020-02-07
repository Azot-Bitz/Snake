using System;
using System.Collections.Generic;
using System.Text;

namespace List_2_Список_
{
    class Point
    {
        public int x;
        public int y;
        public char sym;
        public Point()
        {

        }
        public Point(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
    }
}
