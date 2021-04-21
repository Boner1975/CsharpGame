using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class ComputerPlayerEasy : ComputerPlayer
    {

        public ComputerPlayerEasy(string name = "Computer")
        {
            Name = name;
            IsHuman = false;
            list = new List<Ship>();
        }

        public override Square ChooseSquare(Board board)
        {
            Random rand = new Random();
            int x, y;
            x = rand.Next(0, board.size);
            y = rand.Next(0, board.size);
            return GetSquareByCoordinates(new List<int> { x, y }, board);
        }

    }
}
