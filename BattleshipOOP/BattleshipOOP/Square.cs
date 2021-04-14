using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace BattleshipOOP
{
    public enum SquareStatus
    {
        Empty = '~',
        Ship = 'S',
        Hit = 'H',
        Missed = 'M'

        /*
        [Description("~")]
        Empty = 1,

        [Description("S")]
        Ship,

        [Description("H")]
        Hit,

        [Description("M")]
        Missed
        */
    }

    public class Square
    {
        public int x;
        public int y;
        public SquareStatus SquareStatus;

        public (int, int) Position
        {
            get
            {
                return (x, y);
            }
        }

        public Square(int x, int y)
        {
            this.x = x;
            this.y = y;
            SquareStatus = SquareStatus.Empty;
        }

        public char GetCharacter()
        {
            return (char)SquareStatus; 
        }
    }

}
