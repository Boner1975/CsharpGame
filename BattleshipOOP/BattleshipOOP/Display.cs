using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class Display
    {
        public static string spacingForOneDigitCols = "  ";
        public static string spacingForTwoDigitsCols = " ";
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

        public void DrawClearBoard(Board board)
        {
            Console.WriteLine();
            Console.Write("        ");
            for (int i = 0; i < board.size; i++)
            {
                if (i < 9)
                {
                    Console.Write(" " + (i + 1) + spacingForOneDigitCols);
                }
                else
                {
                    Console.Write(" " + (i + 1) + spacingForTwoDigitsCols);
                }
            }
            Console.WriteLine();
            for (int i = 0; i < board.size; i++)
            {
                Console.Write("       +");
                for (int i1 = 0; i1 < board.size; i1++)
                {
                    Console.Write("---+");
                }
                Console.WriteLine();
                Console.Write("    " + (char)(i + 65) + "  |");
                for (int i2 = 0; i2 < board.size; i2++)
                {
                    Console.Write(" ~ |");
                }
                Console.WriteLine();
            }
            Console.Write("       +");
            for (int i = 0; i < board.size; i++)
            {
                Console.Write("---+");
            }
            Console.WriteLine();
        }

        public void PrintMessageInLine(string message)
        {
            Console.Write(message);
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintMainMenu(int optionIndex)
        {
            MainMenu mM = new MainMenu();
            
            Console.Clear();
            Console.Out.WriteLine(mM.gameLogo);
            Console.Out.WriteLine(mM.mainMenu);
            PrintOptions(mM, optionIndex);
        }

        private void PrintOptions(MainMenu menu, int optionIndex)
        {
            for (int i = 0; i < menu.optionsList.Length; i++)
            {
                Console.Out.WriteLine(menu.ManageOptions(optionIndex, i));
            }
        }


    }
}
