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

            //BoardFactory bf = new BoardFactory();
            //bf.ManualPlacement(10, new Display(), new Input(), new Utility(), new Player());
            /*
            Board board = new Board(10);
            Display display = new Display();
            display.DrawBoardPosition(board);
            display.DrawBoardCharacter(board);
            Input input = new Input();
            //Console.WriteLine(input.GetBoardSize());
            //Console.WriteLine(input.GetPlayerName());
            Console.WriteLine(input.GetBoardSize(display));
            //Console.WriteLine(board.ocean.Length); 
            //Square square = new Square(1, 1);
            //Console.WriteLine(square.GetCharacter());
            //Console.WriteLine(square.Position);
            
            
            Console.ReadKey();
            */

            //Input input = new Input();
            //Game game = new Game();
            //game.RunGame();
        }
    }
}
