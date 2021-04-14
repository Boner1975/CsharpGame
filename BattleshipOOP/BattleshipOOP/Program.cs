using System;

namespace BattleshipOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(10);
            Display.DrawBoard(board);

            //Console.WriteLine(board.ocean.Length); 
            //Square square = new Square(1, 1);
            //Console.WriteLine(square.GetCharacter());
            //Console.WriteLine(square.Position);
        }
    }
}
