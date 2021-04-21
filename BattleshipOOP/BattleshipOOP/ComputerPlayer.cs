using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public abstract class ComputerPlayer : Player
    {
        public override Square DoMove(Display display, Input input, Utility utility, Board board)
        {
            ConsoleKey consoleKey = Console.ReadKey().Key;
            if (consoleKey == ConsoleKey.Q)
            {
                Square qsquare = new Square(-1, -1);
                return qsquare;
            }

            Square selectedSquare = new Square(0, 0);
            do
            {
                selectedSquare = ChooseSquare(board);

            } while (selectedSquare.SquareStatus != SquareStatus.Empty && selectedSquare.SquareStatus != SquareStatus.Ship);
            return selectedSquare;
        }
        public abstract Square ChooseSquare(Board board);
    }
}
