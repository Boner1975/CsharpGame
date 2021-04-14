using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public static class Display
    {
        public static void DrawBoard(Board board)
        {
            for (int i = 0; i < board.size; i++)
            {
                for (int j = 0; j < board.size; j++)
                {
                    Console.Write(" " + board.ocean[i, j].Position);
                }
                Console.WriteLine();
            }
        }
    }
}
