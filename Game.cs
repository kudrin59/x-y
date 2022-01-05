using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Game
    {
        const int maxPlayerSize = 2;
        int win = 0;

        IPlayer[] players = new IPlayer[maxPlayerSize];

        Map map = new Map();

        public void Start()
        {
            InitMap();
            CreatePlayers();

            int lastPlayer = 0;
            int num = 0;

            while (!IsGameOver())
            {
                map.Print();
                if (players[num].symbol == 1)
                {
                    if (CheckWinMove(players[num].symbol))
                    {
                        win = players[num].symbol;
                        break;
                    }
                }
                players[num].Move(map.map, map.size, players[lastPlayer].moveCount);
                lastPlayer = num;
                num++;
                if (num > maxPlayerSize - 1) num = 0;
            }
            map.Print();
            WhoWin();
            Console.ReadKey();
        }

        private void InitMap()
        {
            Console.WriteLine("Размеры игрового поля:");

            int i = 1;
            foreach (int valie in map.values)
            {
                Console.WriteLine($"{i} - {valie}x{valie}", i, valie);
                i++;
            }
            Console.Write($"Укажите размер поля: ");
            int n = Convert.ToInt32(Console.ReadLine());

            map.Init(n);
        }

        private void CreatePlayers()
        {
            Console.WriteLine("Роли:");
            Console.WriteLine("1 - Человек");
            Console.WriteLine("2 - Компьютер");
            for (int i = 0; i < maxPlayerSize; i++)
            {
                IPlayer player;
                Console.Write($"Роль для {i + 1}-й игрока: ");
                int num = Convert.ToInt32(Console.ReadLine());
                if(num == 1)
                    player = new HumanPlayer();
                else
                    player = new CompPlayer();
                player.symbol = i + 1;

                players[i] = player;
            }
        }

        private void WhoWin()
        {
            string str_win = "";
            switch (win)
            {
                case 0:
                    {
                        str_win = "Ничья!";
                        break;
                    }
                case 1:
                    {
                        str_win = "Победили крестики!";
                        break;
                    }
                case 2:
                    {
                        str_win = "Победили нолики!";
                        break;
                    }
            }
            Console.WriteLine(str_win);
        }

        private bool IsGameOver()
        {
            int count_x = 0; // Количество x
            int count_y = 0; // Количество y
            int clear_count = 0; // Количество пустых ячеек

            //Проверка строк
            for (int i = 0; i < map.size; i++)
            {
                count_x = 0;
                count_y = 0;
                for (int j = 0; j < map.size; j++)
                {
                    if (map.map[i, j] == 1) count_x++;
                    else if (map.map[i, j] == 2) count_y++;
                    if (map.map[i, j] == 0) clear_count++;
                }
                if (CheckOver(count_x, count_y)) return true;
            }

            //Проверка столбцов
            for (int i = 0; i < map.size; i++)
            {
                count_x = 0;
                count_y = 0;
                for (int j = 0; j < map.size; j++)
                {
                    if (map.map[j, i] == 1) count_x++;
                    else if (map.map[j, i] == 2) count_y++;
                }
                if (CheckOver(count_x, count_y)) return true;
            }

            //Проверка главное диагонали
            count_x = 0;
            count_y = 0;
            for (int i = 0; i < map.size; i++)
            {
                if (map.map[i, i] == 1) count_x++;
                else if (map.map[i, i] == 2) count_y++;
            }
            if (CheckOver(count_x, count_y)) return true;

            //Проверка побочной диагонали
            count_x = 0;
            count_y = 0;
            for (int i = 0; i < map.size; i++)
            {
                if (map.map[map.size - i - 1, i] == 1) count_x++;
                else if (map.map[map.size - i - 1, i] == 2) count_y++;
            }
            if (CheckOver(count_x, count_y)) return true;

            if (clear_count == 0) return true;
            return false;
        }

        private bool CheckOver(int x, int y)
        {
            if (x < map.size && y < map.size) return false;
            if (x >= map.size) win = 1;
            else if (y >= map.size) win = 2;
            return true;
        }

        private bool CheckWinMove(int symbol)
        {
            //Проверка главной диагонали
            int hod_count = 0;
            for (int i = 0; i < map.size; i++)
            {
                if (map.map[i, i] != symbol && map.map[i, i] != 0) // Если линия заблокирована
                {
                    hod_count--;
                    break;
                }
                if (map.map[i, i] == symbol) hod_count++;
            }
            if (hod_count + 1 == map.size) return true;

            //Проверка побочной диагонали
            hod_count = 0;
            for (int i = 0; i < map.size; i++)
            {
                if (map.map[map.size - i - 1, i] != symbol && map.map[map.size - i - 1, i] != 0) // Если линия заблокирована
                {
                    hod_count--;
                    break;
                }
                if (map.map[map.size - i - 1, i] == symbol) hod_count++;
            }
            if (hod_count + 1 == map.size) return true;

            //Проверка строк
            for (int i = 0; i < map.size; i++)
            {
                hod_count = 0;
                for (int j = 0; j < map.size; j++)
                {
                    if (map.map[i, j] != symbol && map.map[i, j] != 0) // Если линия заблокирована
                    {
                        hod_count--;
                        break;
                    }
                    if (map.map[i, j] == symbol) hod_count++;
                }
                if (hod_count + 1 == map.size) return true;
            }

            //Проверка столбцов
            for (int i = 0; i < map.size; i++)
            {
                hod_count = 0;
                for (int j = 0; j < map.size; j++)
                {
                    if (map.map[j, i] != symbol && map.map[j, i] != 0) // Если линия заблокирована
                    {
                        hod_count--;
                        break;
                    }
                    if (map.map[j, i] == symbol) hod_count++;
                }
                if (hod_count + 1 == map.size) return true;
            }

            return false;
        }

    }
}
