using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class ComputerPlayerHard: ComputerPlayerNormal
    {
        public override Square ChooseSquare(Board board)
        {
            Square square = HandleHits(board);
            if (square != null)
                return square;
            Random rand = new Random();
            int x, y;
            do
            {
                x = rand.Next(0, board.size);
                y = rand.Next(0, board.size);

            } while (!IsEmptySquare(board, x, y) || IsShipNeighbour(board, x, y));

            return GetSquare(board, x, y);

        }
    }
}
