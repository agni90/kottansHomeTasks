using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Battleship
{
    public class Ship
    {
        public uint X;
        public uint Y;
        public uint Length;
        public Direction Direction;
        
        public Ship(uint x, uint y, uint length, Direction direction)
        {
            X = x;
            Y = y;
            Length = length;
            Direction = direction;
        }

        public Ship()
        {
        }

        public static Ship Parse(string notation)
        {
            Ship shipResult = new Ship();
            char[] myStringToCharArray = notation.ToCharArray(0, notation.Length);

            Dictionary<char, uint> myDictionary = new Dictionary<char, uint>()
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
            char myX = myStringToCharArray[0];
            if (myDictionary.ContainsKey(myX))  shipResult.X = myDictionary[myX];
            

            uint myY = uint.Parse(myStringToCharArray[1].ToString());
            if (myY > 1 && myY < 10)  shipResult.Y = myY;


            if (2 < myStringToCharArray.Length)
            {
                uint myLength = uint.Parse(myStringToCharArray[3].ToString());
                if (myLength > 1 && myLength < 5) shipResult.Length = myLength;
               
                if (4 < myStringToCharArray.Length) shipResult.Direction = Direction.Horizontal;

                var myDirection = myStringToCharArray[4] == '|' ? Direction.Vertiacal : Direction.Horizontal;
                shipResult.Direction = myDirection;

            }
            else
            {
                shipResult.Y = 1;
                shipResult.Length = 1;
                shipResult.Direction = Direction.Horizontal;
            }

            return shipResult;
        }
    }
}