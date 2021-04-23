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
        private int GameLevel;
        private List<bool> PlayersAreHumans;
        private BoardFactory bf = new BoardFactory();
        private Input input = new Input();
        private Display display = new Display();
        private Utility utility = new Utility();
        private bool isQuit;
        private bool isWin;



        public void RunGame(List<bool> playersMode, int gameLevel)
        {
            this.BoardSize = input.GetBoardSize(display);
            this.PlayersAreHumans = playersMode;
            this.GameLevel = gameLevel;
            DefinePlayers();

            do
            {
                Console.Clear();
                CurrentPlayer = SwitchPlayers();
                Opponent = SwitchPlayers();
                Round();
            } while (Opponent.IsAlive && !isQuit && !isWin);
        }

        private Board DefineBoardsAndSetShips(int boardSize, Player player)
        {
            Board board;
            List<Ship> list;

            switch (player.IsHuman)
            {
                case true:
                    YesNoMenu menu = new YesNoMenu();
                    bool manualShipPlacement = menu.RunMenu();
                    menu.ResetArrowIndex();
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
            List<Player> players = new List<Player>();
            List<Board> boards = new List<Board>();
            
            for (int i = 0; i < 2; i++)
            {
                players.Add(CreatePlayer(PlayersAreHumans[i], "Player1"));
                boards.Add(DefineBoardsAndSetShips(BoardSize, players[i]));
                Console.Clear();
                display.DrawClearBoard(boards[i], players[i], utility);
                display.PrintMessage("Press any key to precede to another player's board");
                Console.ReadKey();
                Console.Clear();
            }

            Player1 = players[0];
            Player2 = players[1];
            Board1 = boards[1];
            Board2 = boards[0];
            
            CurrentPlayer = Player2;
        }

        private Player CreatePlayer(bool isHuman, string defaultName)
        {
            string name = isHuman ? input.GetPlayerName(display) : defaultName;
            if (isHuman) return new HumanPlayer(name);
            switch (GameLevel)
            {
                case 1:
                    return new ComputerPlayerEasy(name);
                case 2:
                    return new ComputerPlayerNormal(name);
                default:
                    return new ComputerPlayerEasy(name);
            }            
        }

        private Player SwitchPlayers()
        {
            return CurrentPlayer.Equals(Player2) ? Player1 : Player2;
        }

        private void Round()
        {
            bool successfullShot;
            Board board = CurrentPlayer.Equals(Player1) ? Board1 : Board2;
            display.DrawGameBoards(Board1, Board2, Player1, Player2, utility);
            
            do
            {
                display.PrintMessage($"{CurrentPlayer.Name}");
                Square selectedSquare = CurrentPlayer.DoMove(display, input, utility, board);
                if (selectedSquare.x == -1)
                {
                    isQuit = true;
                    break;
                }
                System.Threading.Thread.Sleep(1000);
                successfullShot = (CurrentPlayer.CheckShot(selectedSquare, Opponent));
                display.DrawGameBoards(Board1, Board2, Player1, Player2, utility);
                CheckWin();
            } while (successfullShot && !isWin);

            //Console.ReadKey();
        }

        

        private void CheckWin()
        {
            if (!Opponent.IsAlive)
            {
                display.PrintMessage($"Player {(CurrentPlayer.Name)} win! Congratulations!!!");
                isWin = true;
                Console.ReadKey();
            }
            else
            {
                isWin = false;
            }
        }
    }
}
