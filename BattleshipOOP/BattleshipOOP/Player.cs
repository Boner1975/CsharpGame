using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class Player
    {
        private string name;
        public string Name 
        { 
            get
            {
                return name;
            }
        }
        private List<Ship> list;
        private bool IsAlive;
        private bool IsHuman;

        public Player(string name = "", bool isHuman = true)
        {
            this.name = name;
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
            this.IsAlive = !(list is null) ? list.Count > 0 : false;
        }
        
        public bool GetIsHuman()
        {
            return this.IsHuman;
        }

        public void SetListOfShips(List<Ship> list)
        {
            this.list = list;
        }

        public void CheckShot1(Square square)
        {
            bool squareInList = false;
            int shipIndex = 0;

            while (!(list is null) && !squareInList && shipIndex < list.Count)
            {
                squareInList = SuccessfullHit1(list[shipIndex], square);
                shipIndex++;
            }

            Console.ReadKey();
        }
        
        private bool SuccessfullHit1(Ship ship, Square square)
        {
            if (ship.GetLocation().Contains(square))
            {
                square.SquareStatus = SquareStatus.Hit;
                DidItSunk(ship);
                return true;
            }

            return false;
        }
        
        private void DidItSunk(Ship ship)
        {
            if (AllSquaresHit(ship))
                SunkTheShip(ship);

        }

        private bool AllSquaresHit(Ship ship)
        {
            foreach (Square square in ship.GetLocation())
            {
                if (square.SquareStatus != SquareStatus.Hit)
                    return false;
            }

            return true;
        }

        private void SunkTheShip(Ship ship)
        {
            foreach (Square square in ship.GetLocation())
            {
                square.SquareStatus = SquareStatus.Sunk;
            }
        }
    }
}
