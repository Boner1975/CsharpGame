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
            List<int> list = input.GetLocation(display, utility, board);
            if (list.Count != 0)
            {
                Square selectedSquare = GetSquareByCoordinates(list, board);
                return selectedSquare;
            }
            else
            {
                Square qsquare = new Square(-1, -1);
                return qsquare;
            }
        }
    }
}
