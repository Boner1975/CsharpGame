using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
        private bool[] PlayersAreHumans;
        private BoardFactory bf = new BoardFactory();
        private Input input = new Input();
        private Display display = new Display();
        private Utility utility = new Utility();
        


        public void RunGame()
        {
            ChooseMode();
            this.BoardSize = input.GetBoardSize(display);
            DefinePlayers();

            do
            {
                CurrentPlayer = SwitchPlayers();
                Opponent = SwitchPlayers();
                Round();
            } while (Opponent.GetIsAlive());
        }


        private void ChooseMode()
        {
            ModeMenu modeMenu = new ModeMenu();
            //int optionIndex = menu.RunMenu(modeMenu);
            PlayersAreHumans = modeMenu.RunMenu();
        }

        private Board DefineBoardsAndSetShips(int boardSize, Player player)
        {
            Board board;
            List<Ship> list;

            switch (player.GetIsHuman())
            {
                case true:
                    YesNoMenu menu = new YesNoMenu();
                    bool manualShipPlacement = menu.RunMenu();
                    menu.ResetSelectedOptionIndex();
                    (board, list) = manualShipPlacement 
                        ? bf.ManualPlacement(boardSize, display, input, utility, player)
                        : bf.RandomPlacement(boardSize, player);
                    break;
                case false:
                    (board, list) = bf.RandomPlacement(boardSize, player); break;
            }
            
            player.SetListOfShips(list);
            return board;
        }

        private void DefinePlayers()
        {
            bool player1IsHuman = PlayersAreHumans[0];
            bool player2IsHuman = PlayersAreHumans[1];
            
            Player1 = new Player(player1IsHuman ? input.GetPlayerName(display) : "Player1", player1IsHuman);
            Board2 = DefineBoardsAndSetShips(BoardSize, Player1);
            Console.Clear();
            display.DrawClearBoard(Board2, Player1, utility);
            display.PrintMessage("Press any key to precede to another player's board");
            Console.ReadKey();

            Console.Clear();
            Player2 = new Player(player2IsHuman ? input.GetPlayerName(display) : "Player2", player2IsHuman);
            Board1 = DefineBoardsAndSetShips(BoardSize, Player2);
            Console.Clear();
            display.DrawClearBoard(Board1, Player2, utility);
            display.PrintMessage("Press any key to precede start the game");
            Console.ReadKey();
            
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
