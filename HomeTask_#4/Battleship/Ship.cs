﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

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
                    throw  new Exception("should never be here, alredy checked on length");
            }
        }

        public static bool TryParse(string notation, out Ship ship)
        {
            try
            {
                ship = Parse(notation);
                return true;
            }
            catch (NotAShipException)
            {
                ship = null;
                return false;
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

        public bool FitsInSquare(byte squareHeight, byte squareWidth)
        {
            if (Direction == Direction.Vertiacal)
            {
                return X <= squareWidth && (Y + (Length - 1)) <= squareHeight;
            }
            else
            {
                return (X + (Length - 1)) <= squareWidth && Y <= squareHeight;
            }
        }

        public bool OverlapsWith(Ship pos2)
        {
            bool isOverlapped = false;
            //check heads
            if (X == pos2.X && Y == pos2.Y)
                isOverlapped = true;
            //check my head and his tail
            if (pos2.Direction == Direction.Horizontal && X == pos2.X + pos2.Length -1 && Y == pos2.Y)
                isOverlapped = true;
            if (pos2.Direction == Direction.Vertiacal && Y == pos2.Y + pos2.Length - 1 && X == pos2.X)
                isOverlapped = true;
            //check my tail and his head
            if (Direction == Direction.Horizontal && X + Length -1 == pos2.X && Y == pos2.Y)
                isOverlapped = true;
            if (Direction == Direction.Vertiacal && Y + Length - 1 == pos2.Y && X == pos2.X)
                isOverlapped = true;

            return isOverlapped;
        }
    }
}