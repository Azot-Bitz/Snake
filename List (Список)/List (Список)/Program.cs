using System;
using System.Collections.Generic;

namespace List__Список_
{
    class Program
    {
        const int MINCHAR = 33; // 'символ !'
        const int MAXCHAR = 42; // 'символ *'
        const int MAXPOINT = 4; //  Сколько точек будет на экране

        static void Main(string[] args)
        {
            // Временно убираю такую реализацию... Буду использовать анонимные точки (объекты, классы)
            /*Point p1 = new Point(1, 3, '*');
            Point p2 = new Point(4, 5, '#');*/
            /*p1.Draw();
            p2.Draw();*/

            //  Для работы с рандомными числами...
            Random rnd = new Random();

            List<int> numlist = new List<int>();
            //  Забиваем список числами
            for (int i = 0; i < MAXPOINT * 2; i++)
            {
                numlist.Add(rnd.Next(0, 10));
            }

            //  Создаем список символов
            List<char> charList = new List<char>();
            for (int i = MINCHAR; i <= MAXCHAR; i++)
            {
                charList.Add((char)i);  //  кастуем число к символу
            }

            List<Point> pList = new List<Point>();
            for (int i = 0; i < MAXPOINT; i++)
            {
                // Буду использовать анонимные точки (объекты, классы)
                pList.Add(new Point(numlist[i], numlist[i + 1], charList[rnd.Next(i, charList.Count)]));
            }

            //  Выводим список точек на экран
            foreach (var p in pList)
            {
                p.Draw();
            }

            Console.ReadKey();
        }

    }
}
