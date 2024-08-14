using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGameConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false; //Отключить курсора
            //Создаём карту локации
            char[,] Map =
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', '#' },
                {'#', ' ', 'X', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', ' ', '#' },
                {'#', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', '#', ' ', '#' },
                {'#', ' ', 'X', '#', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                {'#', ' ', ' ', '#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', ' ', ' ', ' ', 'X', '#' },
                {'#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#' },
                {'#', ' ', ' ', ' ', ' ', '#', ' ', ' ', 'X', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                {'#', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', '#' },
                {'#', ' ', '#', '#', ' ', ' ', ' ', '#', '#', '#', '#', 'X', '#', ' ', '#', ' ', ' ', '#' },
                {'#', 'X', ' ', ' ', 'X', '#', ' ', ' ', ' ', 'X', '#', ' ', ' ', ' ', '#', ' ', 'X', '#' },
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };
            
            int userX = 4, userY = 10; //Координаты игрока
            char[] bag = new char[1]; //Создание одномерного массива на одну ячейку

            //Цикл бесконечной отрисовки карты
            while (true)
            {
                Console.SetCursorPosition(0, 15);
                Console.Write("Сумка: ");

                //Цикл перебора для отображения элементов в хранящихся сумке
                for (int i = 0; i < bag.Length; i++)
                {
                    Console.Write(bag[i] + " ");
                }

                Console.SetCursorPosition(0, 0); //Отображение массива в начале консоли
                for (int i = 0; i < Map.GetLength(0); i++)
                {
                    for (int j = 0; j < Map.GetLength(1); j++)
                    {
                        Console.Write(Map[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.SetCursorPosition(userY, userX);
                Console.Write('@'); //Отрисовка персонажа '@'

                ConsoleKeyInfo charKey = Console.ReadKey(); //ConsoleKeyInfo - Считывание клавишь с клавиатуры

                switch (charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (Map[userX - 1, userY] != '#')
                        {
                            userX--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Map[userX + 1, userY] != '#')
                        {
                            userX++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Map[userX, userY - 1] != '#')
                        {
                            userY--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (Map[userX, userY + 1] != '#')
                        {
                            userY++;
                        }
                        break;
                }

                if (Map[userX, userY] == 'X')
                {
                    Map[userX, userY] = 'o'; //Переписать 'X' в 'o'
                    char[] tempBag = new char[bag.Length + 1]; //Создание временного массива для перезаписи предыдущего значения

                    for (int i = 0; i < bag.Length; i++) 
                    {
                        tempBag[i] = bag[i];
                    }
                    tempBag[tempBag.Length - 1] = 'X'; //Присваеваем последнему значению временной сумки присваевыем 'X'
                    bag = tempBag; //Присваеваем значение временной сумки настоящей
                }
                Console.Clear(); //ЧТобы цикл не отресовывал карту занаво
            }
        }
    }
}