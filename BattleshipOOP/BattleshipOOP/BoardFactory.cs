using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class BoardFactory
    {
        private Board CreateBoard(int size)
        {
            Board board = new Board(size);
            return board;
        }

        private List<Ship> CreateListOfShips()
        {
            return new List<Ship> {
                {new Ship(Ship.ShipType.Carrier) },
                {new Ship(Ship.ShipType.Battleship) },
                {new Ship(Ship.ShipType.Cruiser) },
                {new Ship(Ship.ShipType.Destroyer) },
                {new Ship(Ship.ShipType.Destroyer) },
                {new Ship(Ship.ShipType.Submarine) },
                {new Ship(Ship.ShipType.Submarine) }
            };
        }

        public (Board, List<Ship>) RandomPlacement(int size)
        {
            Board board = CreateBoard(size);
            List<Ship> ships = CreateListOfShips();
            Random random = new Random();
            foreach (Ship ship in ships)
            {
                int shipSize = (int)ship.Type;
                int x1, x2, y1, y2;
                int counter = 0;
                do
                {
                    x1 = random.Next(0, size);
                    y1 = random.Next(0, size);

                    int direction = random.Next(0, 2);
                    int ascending = random.Next(0, 2);

                    x2 = x1;
                    y2 = y1;
                    if (direction == 1)
                    {
                        x2 = ChooseDirection(x1, shipSize, ascending);
                    }
                    else
                    {
                        y2 = ChooseDirection(y1, shipSize, ascending);
                    }
                    if (counter > 1_000_000)
                        throw new Exception("There is a problem whith ships random placement after 1000000 tries");

                } while (!board.PlaceShip(ship, x1,y1,x2,y2));
            }

            return (board, ships);
        }

        private static int ChooseDirection(int y1, int shipSize, int ascending)
        {
            int y2;
            if (ascending == 1)
            {
                y2 = y1 + shipSize - 1;
            }
            else
            {
                y2 = y1 - shipSize + 1;
            }

            return y2;
        }

        public void ManualPlacement(int size)
        {
            Board board = CreateBoard(size);
            List<Ship> ships = CreateListOfShips();
        }
    }
}