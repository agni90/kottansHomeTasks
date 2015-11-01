using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Battleship
{
    public class Ship
    {
        public uint X { get; set; }
        public uint Y { get; set; }
        public uint Length { get; set; }
        public Direction Direction { get; set; }

        private static readonly Dictionary<char, uint> myDictionary = new Dictionary<char, uint>()
            {
                {'A', 1},
                {'B', 2},
                {'C', 3},
                {'D', 4},
                {'E', 5},
                {'F', 6},
                {'G', 7},
                {'H', 8},
                {'I', 9},
                {'J', 10}
            };

        public Ship()
        {
        }

        public Ship(uint x, uint y)
        {
            X = x;
            Y= y;
        }

        public Ship(uint x, uint y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public Ship(uint x, uint y, uint length, Direction direction)
        {
            X = x;
            Y = y;
            Length = length;
            Direction = direction;
        }

        public Ship(Ship ship)
        {
            X = ship.X;
            Y = ship.Y;
            Length = ship.Length;
            Direction = ship.Direction;
        }

        public static Ship Parse(string notation)
        {
            Ship shipResult = new Ship();
            char[] myStringToCharArray = notation.ToCharArray(0, notation.Length);

            if (myStringToCharArray.Length > 5) throw new NotAShipException();

            //check, that X coordinate exists 
            char myX = myStringToCharArray[0]; 
            if (myDictionary.ContainsKey(myX)) shipResult.X = myDictionary[myX];
            else
            {
                throw new NotAShipException();
            }

            //check, that Y coordinate exists A2x2|
            uint myY = ParseYElementFromNotation(notation);
            if (myY > 0 && myY < 10)  shipResult.Y = myY;
            else
            {
                throw new NotAShipException();
            }

            //ship's length
            if (myStringToCharArray.Length > 3 && myStringToCharArray.Length < 6)
            {
                uint shipLength = uint.Parse(myStringToCharArray[3].ToString());
                if (shipLength > 0 && shipLength < 5) shipResult.Length = shipLength;
                else
                {
                    throw new NotAShipException();
                }
            }
            else
            {
                shipResult.Length = 1u;
                shipResult.Direction = Direction.Horizontal;
                //return shipResult;
            }

            //check ship's direction
            if (myStringToCharArray.Length > 4)
            {
                var myDirection = myStringToCharArray[4] == '|' ? Direction.Vertiacal : Direction.Horizontal;
                shipResult.Direction = myDirection;
            }
            else
            {
                shipResult.Direction = Direction.Horizontal;
            }

            //check kind of ship
            switch (shipResult.Length)
            {
                case 1:
                    shipResult.Direction = Direction.Horizontal;
                    return new PatrolBoat(shipResult);
                case 2:
                    return new Cruiser(shipResult);
                case 3:
                    return new Submarine(shipResult);
                case 4:
                    return new AircraftCarrier(shipResult);
                default:
                    throw  new Exception("should neber be here,alredy checked on lenth");
            }
        }

        private static uint ParseYElementFromNotation(string notation)
        {
            char[] toCharArr = notation.ToCharArray(0, notation.Length);
            if (notation.Length == 2 || toCharArr[2] == 'x')
            {
                string myNotation = notation.Substring(1, 1);
                return uint.Parse(myNotation);

            }
            else
            {
                string myNotation = notation.Substring(1, 2);
                return uint.Parse(myNotation);
            }

        }

        public static bool operator ==(Ship shipA, Ship shipB)
        {
            if (shipA.GetType() != shipB.GetType()) return false;
            if ((shipA.X == shipB.X) && (shipA.Y == shipB.Y) && (shipA.Direction == shipB.Direction))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Ship shipA, Ship shipB)
        {
            return !(shipA == shipB);
        }

        public override bool Equals(object obj)
        {
            return (Ship)this == obj as Ship;
        }
    }
}