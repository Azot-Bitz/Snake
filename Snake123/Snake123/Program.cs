using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake123
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.SetWindowSize(1, 1);
			Console.SetBufferSize(80, 25);
			Console.SetWindowSize(80, 25); // Эта функция устанавливает размер окна и убирает возможность перемотки.

			//Отрисовка рамки
			/*HorizontalLine upLine = new HorizontalLine(0,78,0,'+');
			HorizontalLine downLine = new HorizontalLine(0, 78, 24, '+');
			VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
			VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');
			upLine.Drow();
			downLine.Drow();
			leftLine.Drow();
			rightLine.Drow();*/
			VerticalLine v1 = new VerticalLine(0, 10, 5, '&');
			Draw(v1);

			//Отрисовка точек
			Point p = new Point(4, 5, '*');
			Figure fSnake = new Snake(p, 4, Direction.RIGHT); //(хвост, длина, направление змейки)
			Draw(fSnake);
			Snake snake = (Snake)fSnake;// Это явное приведение типов.
			HorizontalLine h1 = new HorizontalLine(0, 5, 6, '&');

			List<Figure> figures = new List<Figure>();
			figures.Add(fSnake);
			figures.Add(v1);
			figures.Add(h1);

			foreach(var f in figures)
			{
				f.Draw();
			}

			static void Draw(Figure figure)
			{
				figure.Draw();
			}
				
			FoodCreator foodCreator = new FoodCreator(80, 25, '$');// Для того, чтобы на карте появилась еда, мы создаем класс FoodCreator.
			// В конструкторе передаем данные необходимые для его работы (80 и 25 - габариты экрана, $ - символ еды).
			Point food = foodCreator.CreateFood();// Метод CreateFood будет создавать точку в рандомном месте на карте в пределах координат, которые мы передали в конструкторе.
			food.Draw();

				while (true)// Бесконечный цикл.
				{
					if (snake.Eat(food))// Метод snake.Eat возвращает бинарное значение (true, false).
					{
						food = foodCreator.CreateFood();// Создаем новую точку еды.
						food.Draw();
					}
					else
					{
						snake.Move();
					}
				Thread.Sleep(100);

				if (Console.KeyAvailable)// Проверяет была ли нажата какая-либо кнопка.
				{
					ConsoleKeyInfo key = Console.ReadKey();//Получает значение этой клавиши.
					snake.HandleKey(key.Key);
				}
			}
		}
	}
}
