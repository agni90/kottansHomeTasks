using System;
using System.Security.Cryptography.X509Certificates;

namespace Battleship.Tests
{
    public class Ship
    {
        public uint X;
        public uint Y;
        public uint Length;
        public Direction direction;

        public Ship()
        {
            this.X = X;
            this.Y = Y;
            this.Length = Length;
            this.direction = direction;
        }

        public Ship Parse(string notation)
        {
            char[] myStringToCharArray = notation.ToCharArray(0, notation.Length);

        }
    }
}