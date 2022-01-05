using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Map
    {
        public int[,] map { get; set; }
        public int size { get; set; }
        public int[] sizeValue { get; }

        public int[] values = { 3, 4, 5 };

        public void Init(int n)
        {
            size = values[n - 1];
            map = new int[size, size];
        }

        public void Print()
        {
            string str = "";
            Console.WriteLine();
            Console.WriteLine("Поле:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    switch (map[i, j])
                    {
                        case 0:
                            {
                                str = "-";
                                break;
                            }
                        case 1:
                            {
                                str = "x";
                                break;
                            }
                        case 2:
                            {
                                str = "o";
                                break;
                            }
                    }
                    Console.Write(str + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
