using System;
using System.Collections.Generic;

namespace BattleshipOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Battleship bs = new Battleship();
            bs.StartApp();
        }
    }
}
