using System;
using System.Collections.Generic;

namespace BattleshipOOP
{
    public class Board
    {
        public Square[,] ocean;
        public int size;

        public Board(int size)
        {
            this.size = size;
            ocean = new Square[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    ocean[i, j] = new Square(i, j);
        }

        public bool IsPlacementOk
        {
            get
            {
                return true; //to be implemented
            }
        }

        public bool PlaceShip(Ship ship, int x1, int y1, int x2, int y2, Player player)
        {
            if (x1 < 0 || x1 >= size ||
                y1 < 0 || y1 >= size ||
                x2 < 0 || x2 >= size ||
                y2 < 0 || y2 >= size
                )
            {
                return false;
            }

            int shipSize = (int)ship.Type;
            int sumX = Math.Abs(x2 - x1);
            int sumY = Math.Abs(y2 - y1);
            
            if (!(sumY + sumX == shipSize - 1 && (sumX == 0 || sumY == 0)))
            {
                return false;
            }

            if (y1 > y2)
            {
                int tmp = y1;
                y1 = y2;
                y2 = tmp;
            }

            if (x1 > x2)
            {
                int tmp = x1;
                x1 = x2;
                x2 = tmp;
            }

            List<Square> list = new List<Square>();
            if (x1 != x2)
            {
                for (int i = x1; i <= x2; i++)
                {
                    if (CheckSquare(i, y1) == false)
                    {
                        return false;
                    }
                    else
                    {
                        list.Add(ocean[i, y1]);
                    }
                }
            }
            else
            {
                for (int i = y1; i <= y2; i++)
                {
                    if (CheckSquare(x1, i) == false)
                    {
                        return false;
                    }
                    else
                    {
                        list.Add(ocean[x1, i]);
                    }
                }
            }

            foreach(var squar in list)
            {
                squar.ShipCreation();
            }

            ship.SetCoordinates(list);
            player.AddShipToList(ship);

            return true;
        }

        private bool CheckSquare(int x,int y)
        {
            for (int i = x-1;i <= x + 1; i++) 
            {

                if (i<0 || i >= size) 
                {
                    continue;
                }
                for (int j = y - 1; j <= y + 1; j++)
                { 
                    if(j<0 || j>=size)
                    {
                        continue;
                    }
                    if (ocean[i, j].SquareStatus == SquareStatus.Ship)
                    {
                        return false;
                    }
                }
            }
            return true;

        }
    }
}