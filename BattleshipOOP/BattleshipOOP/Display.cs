using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class Display
    {
        string name;
        int boardSize;
        public Display()
        {

        }
        public void DrawBoardPosition(Board board)
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
        public void DrawBoardCharacter(Board board)
        {
            for (int i = 0; i < board.size; i++)
            {
                for (int j = 0; j < board.size; j++)
                {
                    Console.Write(" " + board.ocean[i, j].GetCharacter());
                }
                Console.WriteLine();
            }
        }
        public void PrintMessageInLine(string message)
        {
            Console.Write(message);
        }
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }



    }
}
