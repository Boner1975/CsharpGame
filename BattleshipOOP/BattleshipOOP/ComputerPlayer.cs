using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class ComputerPlayer : Player
    {

        public ComputerPlayer(string name = "Computer")
        {
            Name = name;
            IsHuman = false;
            list = new List<Ship>();
        }
        public override Square DoMove(Display display, Input input, Utility utility, Board board)
        {
            Random rand = new Random();
            int x, y;
            x = rand.Next(0, board.size);
            y = rand.Next(0, board.size);
            Square selectedSquare = GetSquareByCoordinates(new List<int> { x, y }, board);
            return selectedSquare;
        }
    }
}
