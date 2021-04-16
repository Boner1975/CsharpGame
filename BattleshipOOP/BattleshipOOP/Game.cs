using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class Game
    {
        private int BoardSize;
        public Board Board1;
        public Board Board2;
        private Player Player1;
        private Player Player2;
        private Player CurrentPlayer;
        private Player Opponent;
        private BoardFactory bf = new BoardFactory();
        private Input input = new Input();
        private Display display = new Display();
        private Utility utility = new Utility();
        


        public void RunGame()
        {
            this.BoardSize = input.GetBoardSize(display);
            DefinePlayers();
            DefineBoards();

            do
            {
                CurrentPlayer = SwitchPlayers();
                Opponent = SwitchPlayers();
                Round();
            } while (Opponent.GetIsAlive());
        }

        private void DefineBoards()
        {
            Board2 = DefineBoardsAndSetShips(BoardSize, Player1);
            Board1 = DefineBoardsAndSetShips(BoardSize, Player2);
        }

        private Board DefineBoardsAndSetShips(int boardSize, Player player)
        {
            //(Board board, List<Ship> list) = player.GetIsHuman() ? bf.ManualPlacement() : bf.RandomPlacement(boardSize);
            (Board board, List<Ship> list) = bf.RandomPlacement(boardSize,player);
            player.SetListOfShips(list);
            return board;
        }

        private void DefinePlayers(bool isHuman = true)
        {
            Player1 = new Player(isHuman ? input.GetPlayerName(display) : "Player1", isHuman);
            Player2 = new Player(isHuman ? input.GetPlayerName(display) : "Player2", isHuman);
            CurrentPlayer = Player2;
        }

        private Player SwitchPlayers()
        {
            return CurrentPlayer.Equals(Player2) ? Player1 : Player2;
        }

        private void Round()
        {
            Board board = CurrentPlayer.Equals(Player1) ? Board1 : Board2;
            display.DrawGameBoards(Board1, Board2, Player1, Player2, utility);
            Square selectedSquare = GetSquareByCoordinates(input.GetLocation(display,utility,board), board);
            CurrentPlayer.CheckShot(selectedSquare, Opponent);
            CheckWin();
        }

        private Square GetSquareByCoordinates(List<int> coordinates, Board board)
        {
            int colIndex = 0;
            int rowIndex = 1;

            foreach (Square square in board.ocean)
            {
                if (square.x == coordinates[colIndex] && square.y == coordinates[rowIndex])
                {
                    return square;
                }
            }

            return null;

        }

        private void CheckWin()
        {
            if (!Opponent.GetIsAlive())
            {
                display.PrintMessage($"Player {(CurrentPlayer.Name)} win! Congratulations!!!");
            }
        }
    }
}
