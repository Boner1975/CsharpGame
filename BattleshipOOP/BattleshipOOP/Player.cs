using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public abstract class Player
    {
        protected List<Ship> list;
        public bool IsAlive { get { return CheckPlayerStatus(); } }
        public bool IsHuman { get; protected set; }
        public string Name { get; protected set; }
        public void AddShipToList(Ship ship)
        {
            this.list.Add(ship);
        }

        public bool CheckShot(Square square, Player opponent)
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

            return squareInList;
        }

        public abstract Square DoMove(Display display, Input input, Utility utility, Board board);
       
        public void SetListOfShips(List<Ship> list)
        {
            this.list = list;
        }

        protected Square GetSquareByCoordinates(List<int> coordinates, Board board)
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

        private bool AllSquaresHit(Ship ship)
        {
            foreach (Square square in ship.GetLocation())
            {
                if (square.SquareStatus != SquareStatus.Hit)
                    return false;
            }

            return true;
        }

        private bool CheckPlayerStatus()
        {
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

            return stillAlive;

        }
        
        private void DidItSunk(Ship ship)
        {
            if (AllSquaresHit(ship))
                SunkTheShip(ship);
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
        
        private void SunkTheShip(Ship ship)
        {
            foreach (Square square in ship.GetLocation())
            {
                square.SquareStatus = SquareStatus.Sunk;
            }
        }
    }
}
