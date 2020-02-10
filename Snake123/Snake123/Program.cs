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

			Walls walls = new Walls(80, 25);
			walls.Draw();
			

			//Отрисовка точек
			Point p = new Point(4, 5, '*');
			Figure fSnake = new Snake(p, 4, Direction.RIGHT); //(хвост, длина, направление змейки)
			Draw(fSnake);
			Snake snake = (Snake)fSnake;// Это явное приведение типов.

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
				if(walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
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
			WriteGameOver();
			Console.ReadLine();
		}


		static void WriteGameOver()
		{
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
			yOffset++;
			WriteText("Автор: Куликов Василий", xOffset + 2, yOffset++);
			WriteText("Специально для GeekBrains", xOffset + 1, yOffset++);
			WriteText("============================", xOffset, yOffset++);
		}

		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
	}
}

