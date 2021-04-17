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
            this.list = new List<Ship>();
        }

        public bool GetIsAlive()
        {
            CheckPlayerStatus();
            return this.IsAlive;
        }

        private void CheckPlayerStatus()
        {
            Display display = new Display();
            bool stillAlive = list is null;
            int shipIndex = 0;
            int shipsNum = list.Count;

            while (!stillAlive && shipIndex < shipsNum)
            {
                foreach (Square square in list[shipIndex].GetLocation())
                {
                    if (square.SquareStatus == SquareStatus.Ship)
                    {
                        stillAlive = true;
                    }
                }
                
                shipIndex++;
            }

            this.IsAlive = stillAlive;
            
        }
        
        public bool GetIsHuman()
        {
            return this.IsHuman;
        }

        public void SetListOfShips(List<Ship> list)
        {
            this.list = list;
        }

        public void AddShipToList(Ship ship)
        {
            this.list.Add(ship);
        }

        public void CheckShot(Square square, Player opponent)
        {
            bool squareInList = false;
            int shipIndex = 0;

            while (!(opponent.list is null) && !squareInList && shipIndex < opponent.list.Count)
            {
                squareInList = SuccessfullHit(opponent.list[shipIndex], square);

                if (!squareInList)
                {
                    square.SquareStatus = SquareStatus.Missed;
                }
                
                shipIndex++;
            }
        }
        
        private bool SuccessfullHit(Ship ship, Square square)
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
