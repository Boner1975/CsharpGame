using System;

namespace BattleshipOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(10);
            Display display = new Display();
            display.DrawBoardPosition(board);
            display.DrawBoardCharacter(board);
            //Console.WriteLine(board.ocean.Length); 
            //Square square = new Square(1, 1);
            //Console.WriteLine(square.GetCharacter());
            //Console.WriteLine(square.Position);

            Console.ReadKey();
            
            //Display display = new Display();
            display.PrintMainMenu();
        }
    }
}
