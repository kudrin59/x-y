using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class HumanPlayer : IPlayer
    {
        public int symbol { get; set; }
        public int moveCount { get; set; }

        public void Move(int[,] map, int mapSize, int opponentMoveCount)
        {
            while (true)
            {
                Console.Write("Укажите индексы для хода (I - строка, J - столбец) через пробел: ");
                string line = Console.ReadLine();
                string[] tokens = line.Split(" ");
                int i = Convert.ToInt32(tokens[0]) - 1;
                int j = Convert.ToInt32(tokens[1]) - 1;
                if (i >= 0 && i < mapSize && j >= 0 && j < mapSize)
                {
                    if (map[i, j] == 0)
                    {
                        map[i, j] = symbol;
                        break;
                    }
                }
                Console.WriteLine("Ячейка занята!");
            }
            moveCount++;
        }
    }
}
