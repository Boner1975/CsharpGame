using System;
using System.Collections.Generic;

namespace BattleshipOOP
{
    public class Ship
    {
        public enum ShipType
        {
            Carrier = 5,
            Battleship = 4,
            Cruiser = 3,
            Destroyer = 2,
            Submarine = 1
        }

        internal ShipType Type { get; private set; }

        private List<Square> location;

        public Ship(ShipType type)
        {
            Type = type;
        }

        internal void SetCoordinates(List<Square> coordinates)
        {
            location = coordinates;
        }

        public List<Square> GetLocation()
        {
            return location;
        }
    }
}