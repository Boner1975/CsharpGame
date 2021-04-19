using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class HumanPlayer: Player
    {
        public HumanPlayer(string name = "")
        {
            Name = name;
            IsHuman = true;
            list = new List<Ship>();
        }

        public override Square DoMove(Display display, Input input, Utility utility, Board board)
        {
            Square selectedSquare = GetSquareByCoordinates(input.GetLocation(display, utility, board), board);
            return selectedSquare;
        }
    }
}
