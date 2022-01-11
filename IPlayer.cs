using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface IPlayer
    {
        int symbol { get; set; }
        int moveCount { get; set; }
        bool checkWinMove { get; set; }

        public void Move(int[,] map, int mapSize, int opponent_count);

    }
}
