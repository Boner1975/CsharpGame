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
        //public Board EmptyBoard = new Board();
        private Player Player1;
        private Player Player2;
        private Player CurrentPlayer;
        private BoardFactory bf = new BoardFactory();


        public void RunGame(int boardSize = 10)
        {
            this.BoardSize = boardSize;
            DefinePlayers();
            DefineBoards();

            do
            {
                SwitchPlayers();
                Round();
            } while (CurrentPlayer.GetIsAlive());
        }

        private void DefineBoards()
        {
            Board1 = DefineBoardsAndSetShips(BoardSize, Player1);
            Board2 = DefineBoardsAndSetShips(BoardSize, Player2);
        }

        private Board DefineBoardsAndSetShips(int boardSize, Player player)
        {
            //(Board board, List<Ship> list) = player.GetIsHuman() ? bf.ManualPlacement() : bf.RandomPlacement(boardSize);
            (Board board, List<Ship> list) = bf.RandomPlacement(boardSize);
            player.SetListOfShips(list);
            return board;
        }

        private void DefinePlayers()
        {
            Player1 = new Player();
            Player2 = new Player();
            CurrentPlayer = Player2;
        }

        private void SwitchPlayers()
        {
            CurrentPlayer = CurrentPlayer.Equals(Player2) ? Player1 : Player2;
        }

        private void Round()
        {
            //CurrentPlayer makes his move 
        }
    }
}
