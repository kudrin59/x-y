using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class CompPlayer : IPlayer
    {
        public int symbol { get; set; }
        public int moveCount { get; set; }
        public bool checkWinMove { get; set; }

        public void Move(int[,] map, int mapSize, int opponentMoveCount)
        {
            // При возможности ходим в центр
            double temp = mapSize / 2;
            int z = Convert.ToInt32(Math.Ceiling(temp));
            if (map[z, z] == 0)
            {
                map[z, z] = symbol;
                moveCount++;
                return;
            }

            // Собираем ячейки противника
            int[,] player_hod = new int[opponentMoveCount, 2];
            int player_count = 0;
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (symbol != map[i, j] && map[i, j] != 0)
                    {
                        player_hod[player_count, 0] = i;
                        player_hod[player_count, 1] = j;
                        player_count++;
                    }
                }
            }

            //Проверяем заблокированы ли линии
            int temp_i = player_hod[player_count - 1, 0];
            int temp_j = player_hod[player_count - 1, 1];

            int temp_block_i = 0;
            int temp_block_j = 0;
            int temp_count = 0;

            int block_i = -1;
            int block_j = -1;
            int block_count = 0;

            int rez_i = -1;
            int rez_j = -1;
            int rez_count = 0;

            //Проверяем главную диагональ
            bool locked = false;
            temp_block_i = -1;
            for (int i = 0; i < mapSize; i++)
            {
                if (map[i, i] == symbol) // Если линия заблокирована
                    locked = true;
                if (symbol != map[i, i] && map[i, i] != 0) // Если клетка занята противником
                    temp_count++;
                else if (map[i, i] == 0) // Если клетка пустая
                    temp_block_i = temp_block_j = i;
            }
            if (temp_block_i != -1)
            {
                if (temp_count == mapSize - 1 && !locked) // Если противник вот вот выйграет и можно заблокировать ход
                {
                    map[temp_block_i, temp_block_j] = symbol;
                    moveCount++;
                    return;
                }
                if (locked)
                {
                    if (temp_count > block_count) // Если на линии больше клеток противника
                    {
                        block_i = temp_block_i;
                        block_j = temp_block_j;
                        block_count = temp_count;
                    }
                    else
                    {
                        if (temp_count > rez_count)
                        {
                            rez_i = temp_block_i;
                            rez_j = temp_block_j;
                        }
                    }
                }
                else // Если линия не заблокирована
                {
                    if (temp_count > rez_count)
                    {
                        rez_i = temp_block_i;
                        rez_j = temp_block_j;
                        rez_count = temp_count;
                    }
                }
            }

            //Проверяем побочную диагональ
            locked = false;
            temp_count = 0;
            temp_block_i = -1;
            for (int i = 0; i < mapSize; i++)
            {
                if (map[mapSize - i - 1, i] == symbol) // Если линия заблокирована
                    locked = true;
                if (symbol != map[mapSize - i - 1, i] && map[mapSize - i - 1, i] != 0) // Если клетка занята противником
                    temp_count++;
                else if (map[mapSize - i - 1, i] == 0) // Если клетка пустая
                {
                    temp_block_i = mapSize - i - 1;
                    temp_block_j = i;
                }
            }
            if (temp_block_i != -1)
            {
                if (temp_count == mapSize - 1 && !locked) // Если противник вот вот выйграет и можно заблокировать ход
                {
                    map[temp_block_i, temp_block_j] = symbol;
                    moveCount++;
                    return;
                }
                if (locked)
                {
                    if (temp_count > block_count) // Если на линии больше клеток противника
                    {
                        block_i = temp_block_i;
                        block_j = temp_block_j;
                        block_count = temp_count;
                    }
                    else
                    {
                        if (temp_count > rez_count)
                        {
                            rez_i = temp_block_i;
                            rez_j = temp_block_j;
                        }
                    }
                }
                else // Если линия не заблокирована
                {
                    if (temp_count > rez_count)
                    {
                        rez_i = temp_block_i;
                        rez_j = temp_block_j;
                        rez_count = temp_count;
                    }
                }
            }

            //Проверяем столбец
            locked = false;
            temp_count = 0;
            temp_block_i = -1;
            for (int i = 0; i < mapSize; i++)
            {
                if (map[i, temp_j] == symbol) // Если линия заблокирована
                    locked = true;
                if (symbol != map[i, temp_j] && map[i, temp_j] != 0) // Если клетка занята противником
                    temp_count++;
                else if (map[i, temp_j] == 0) // Если клетка пустая
                {
                    temp_block_i = i;
                    temp_block_j = temp_j;
                }
            }
            if (temp_block_i != -1)
            {
                if (temp_count == mapSize - 1 && !locked) // Если противник вот вот выйграет и можно заблокировать ход
                {
                    map[temp_block_i, temp_block_j] = symbol;
                    moveCount++;
                    return;
                }
                if (locked)
                {
                    if (temp_count > block_count) // Если на линии больше клеток противника
                    {
                        block_i = temp_block_i;
                        block_j = temp_block_j;
                        block_count = temp_count;
                    }
                    else
                    {
                        if (temp_count > rez_count)
                        {
                            rez_i = temp_block_i;
                            rez_j = temp_block_j;
                        }
                    }
                }
                else // Если линия не заблокирована
                {
                    if (temp_count > rez_count)
                    {
                        rez_i = temp_block_i;
                        rez_j = temp_block_j;
                        rez_count = temp_count;
                    }
                }
            }

            //Проверяем строку
            locked = false;
            temp_count = 0;
            temp_block_i = -1;
            for (int j = 0; j < mapSize; j++)
            {
                if (map[temp_i, j] == symbol) // Если линия заблокирована
                    locked = true;
                if (symbol != map[temp_i, j] && map[temp_i, j] != 0) // Если клетка занята противником
                    temp_count++;
                else if (map[temp_i, j] == 0) // Если клетка пустая
                {
                    temp_block_i = temp_i;
                    temp_block_j = j;
                }
            }
            if (temp_block_i != -1)
            {
                if (temp_count == mapSize - 1 && !locked) // Если противник вот вот выйграет и можно заблокировать ход
                {
                    map[temp_block_i, temp_block_j] = symbol;
                    moveCount++;
                    return;
                }
                if (locked)
                {
                    if (temp_count > block_count)
                    {
                        block_i = temp_block_i;
                        block_j = temp_block_j;
                        block_count = temp_count;
                    }
                    else
                    {
                        if (temp_count > rez_count)
                        {
                            rez_i = temp_block_i;
                            rez_j = temp_block_j;
                        }
                    }
                }
                else
                {
                    if (temp_count > rez_count)
                    {
                        rez_i = temp_block_i;
                        rez_j = temp_block_j;
                        rez_count = temp_count;
                    }
                }
            }

            if (rez_i != -1)
            {
                map[rez_i, rez_j] = symbol;
            }
            else if (block_i != -1)
                map[block_i, block_j] = symbol;
            else
            {
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (map[i, j] == 0)
                        {
                            map[i, j] = symbol;
                            moveCount++;
                            return;
                        }
                    }
                }
            }
            moveCount++;
        }

    }
}
