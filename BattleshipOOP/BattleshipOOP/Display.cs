using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class Display
    {
        public string spacingForOneDigitCols = "  ";
        public string spacingForTwoDigitsCols = " ";
        string text = "Let's begin ships placement";
        
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

        public void DrawClearBoard(Board board, Player player, Utility utility)
        {
            string leftMarginPlayer = utility.NickPosition(board.size, player.Name);
            string leftMarginText = utility.NickPosition(board.size, text);
            string tab = new string(' ', 8);
            Console.WriteLine();
            Console.WriteLine($"{tab}{leftMarginPlayer}{player.Name}");
            Console.WriteLine($"{tab}{leftMarginText}{text}");
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
                for (int j = 0; j < board.size; j++)
                {
                    Console.Write($" {board.ocean[i, j].GetCharacter()} |");
                }
                Console.WriteLine();
            }
            Console.Write("       +");
            for (int i = 0; i < board.size; i++)
            {
                Console.Write("---+");
            }
            Console.WriteLine(); Console.WriteLine();
        }
        public void DrawGameBoards(Board board1, Board board2, Player player1, Player player2, Utility utility)
        {
            string MarginPlayer1 = utility.NickPosition(board1.size, player1.Name);
            string MarginPlayer2 = utility.NickPosition(board1.size, player2.Name);
            string boardBorder = new StringBuilder().Insert(0, "---+", board1.size).ToString();
            string tab = new string(' ', 8);
            string tab2 = new string(' ', 7);
            Console.WriteLine();
            Console.WriteLine($"{tab}{MarginPlayer1}{player1.Name}{MarginPlayer1}{tab}{MarginPlayer2}{player2.Name}");
            Console.WriteLine();
            for (int multi = 0; multi <= 1; multi++)
            {
                Console.Write(tab);
                for (int i = 0; i < board1.size; i++)
                {
                    if (i < 9)
                    {
                        Console.Write($" {i + 1}{spacingForOneDigitCols}");
                    }
                    else
                    {
                        Console.Write($" {i + 1}{spacingForTwoDigitsCols}");
                    }
                }
            }
            Console.WriteLine();
            for (int i = 0; i <= 2 * board1.size; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine();
                    Console.Write($"       +{boardBorder}{tab2}+{boardBorder}");
                }
                
                if (i % 2 != 0)
                {
                    Console.WriteLine();
                    Console.Write($"    {(char)(i / 2 + 65)}  |");
                    for (int j = 0; j < board1.size; j++)
                    {
                        Console.Write($" {board2.ocean[i/2, j].GetCharacter()} |");
                    }
                    Console.Write($"    {(char)(i / 2 + 65)}  |");
                    for (int j = 0; j < board1.size; j++)
                    {
                        Console.Write($" {board1.ocean[i / 2, j].GetCharacter()} |");
                    }
                }
            }
            Console.WriteLine();
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

        public void PrintShipsNameAndSize(Ship ship)
        {
            if ((int)ship.Type == 1)
            {
                Console.WriteLine($"Set ship {ship.Type} of {(int)ship.Type} square size");
            }
            else
                Console.WriteLine($"Set ship {ship.Type} of {(int)ship.Type} squares size");
        }



    }
}
