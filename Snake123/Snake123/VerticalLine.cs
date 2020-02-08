using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake123
{
    class VerticalLine
    {
        List<Point> mList;

        public VerticalLine(int x, int yUp, int yBottom, char sym)
        {
            mList = new List<Point>();
            for (int y = yUp; y <= yBottom; y++)
            {
                Point m = new Point(x, y, sym);
                mList.Add(m);
            }

        }
        public void Drow()
        {
            foreach (Point m in mList)
            {
                m.Draw();
            }
        }
    }
}
