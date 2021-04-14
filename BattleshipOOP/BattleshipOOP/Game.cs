using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class Game
    {
        //public Board EmptyBoard = new Board();
        private Player Player1;
        private Player Player2;
        private Player CurrentPlayer;


        public void RunGame()
        {
            DefinePlayers();

            do
            {
                SwitchPlayers();
                Round();
            } while (CurrentPlayer.IsAlive);
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
