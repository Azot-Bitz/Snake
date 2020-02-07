using System;
using System.Collections.Generic;
using System.Text;

namespace List__Список_
{
    class Point
    {
        //private int x;
        //private int y;
        //  Временно делаем поля открытыми
        public int x;
        public int y;
        private char sym;

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
