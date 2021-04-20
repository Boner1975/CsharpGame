using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class ComputerPlayerEasy : Player
    {

        public ComputerPlayerEasy(string name = "Computer")
        {
            Name = name;
            IsHuman = false;
            list = new List<Ship>();
        }
        public override Square DoMove(Display display, Input input, Utility utility, Board board)
        {
            ConsoleKey consoleKey = Console.ReadKey().Key;
            if (consoleKey == ConsoleKey.Q)
            {
                Square qsquare = new Square(-1, -1);
                return qsquare;
            }
            Square selectedSquare = new Square(0,0);
            do
            {
                Random rand = new Random();
                int x, y;
                x = rand.Next(0, board.size);
                y = rand.Next(0, board.size);
                selectedSquare = GetSquareByCoordinates(new List<int> { x, y }, board);
            }while(selectedSquare.SquareStatus!=SquareStatus.Empty && selectedSquare.SquareStatus!=SquareStatus.Ship);
            return selectedSquare;

        }
    }
}
