using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake123
{
    class Snake : Figure
    {
        Direction direction; // В этой переменной, получаемой от конструктора, мы храним направление в котором должна двигаться змейка,
        // таким образом мы имеем возможность воспользоваться этой переменной в каких бы то не было методах внутри класса Snake.
        public Snake(Point tail, int lenght, Direction _direction) // Положение змейки на карте (координаты ее хвоста, ее длина, 
        //в каком направлении змейка изначально ориентирована (соответственно, в каком направлении она будет двигаться)).
        {
            direction = _direction;
            pList = new List<Point>();// Список.
            for(int i = 0; i < lenght; i++)
            {
                Point p = new Point(tail);// В цикле несколько раз будем создавать точки, являющимися  точной копией хвостовой точки, которую мы передаем в конструкторе.
                p.Move(i, direction);// Затем, эти точки мы хотим сдвинуть на i позиций, по направлению direction.
                pList.Add(p);// И добавить эти точки в список.
            }
        }

        internal void Move()
        {
            Point tail = pList.First();// Список pList (который хранит список точек, соответствующих змейке) вызывает метод First (он возвращает первый элемент списка).
            pList.Remove(tail);// Т.к. змейка всегда ползет вперед, та точка, которая соответствовала хвосту, больше не принадлежит змейке (тоесть ее надо удалить). Таким образом змейка остается из трех точек.
            Point head = GetNextPoint();// Голова должна переместится в зависимости от того куда мы двигаемся. Переменная head заполнится значением, которое вернет метод GetNextPoint().
            pList.Add(head);// Добавляем новую точку головы змейки в список.

            tail.Clear();// Мы изменили список pList, но при этом на консоли выведены еще старые значения. Надо стереть хвост змейки методом Clear().
            head.Draw();
        }
        public Point GetNextPoint()
        {
            Point head = pList.Last();// Тут методом Last вызываем текущее положение головы змейки, до того как она переместилась.
            Point nextPoint = new Point(head);// Создаем новую точку, которая является копией предыдущего положения головы.
            nextPoint.Move(1, direction);// Эту созданную точку сдвигаем по направлению direction.
            return nextPoint;// Мы получили точку, которая является новым положением головы змейки.
        }
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
        }
        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();// Функция GetNextPoint() вычисляет в какой точке оказывается змейка в следующий момент.
            if (head.IsHit(food))// Если эта точка, на которой окажется змейка на следующем ходу, совпадает с координатами еды, то в этом случае будет акт питания.
                                 // Координаты head и координаты food совпадают, поэтому переходим в тело цикла.
            {
                food.sym = head.sym;// Змейка удлиняется.
                pList.Add(food);
                return true;
            }
            else
                return false;
        }
    }
}
