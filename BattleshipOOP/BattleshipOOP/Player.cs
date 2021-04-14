using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class Player
    {
        private List<Ship> list;
        private bool IsAlive;
        private bool IsHuman;

        public Player(bool isHuman = true)
        {
            this.IsAlive = true;
            this.IsHuman = isHuman;
        }

        public bool GetIsAlive()
        {
            CheckPlayerStatus();
            return this.IsAlive;
        }

        private void CheckPlayerStatus()
        {
            this.IsAlive = list.Count > 0;
        }
        
        public bool GetIsHuman()
        {
            return this.IsHuman;
        }

        public void SetListOfShips(List<Ship> list)
        {
            this.list = list;
        }
    }
}
