using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;

namespace Battleship
{
    class PatrolBoat
    {
        public int x;
        public int y;

        public Direction direction;

        public PatrolBoat(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public PatrolBoat(int x, int y, Direction direction)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
        }


        public static bool operator ==(PatrolBoat shipA, PatrolBoat shipB)
        {
            if (shipA.GetType() != shipB.GetType()) return false;
            if ((shipA.x == shipB.x)&&(shipA.y == shipB.y) ) 
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(PatrolBoat shipA, PatrolBoat shipB)
        {
            return !(shipA == shipB);
        }
        public override bool Equals(object obj)
        {
            return this == (PatrolBoat)obj;
        }

}

    class Cruiser : PatrolBoat
    {
        public Cruiser(int x, int y) : base(x, y)
        {
        }

        public Cruiser(int x, int y, Direction direction) : base(x, y, direction)
        {
        }

        public static bool operator ==(PatrolBoat shipA, Cruiser shipB)
        {
            if (shipA.GetType() != shipB.GetType()) return false;
            if ((shipA.x == shipB.x) && (shipA.y == shipB.y) && (shipA.direction == shipB.direction))
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(PatrolBoat shipA, Cruiser shipB)
        {
            return !(shipA == shipB) ;
        }
        public override bool Equals(object obj)
        {
            return this == (Cruiser)obj;
        }
    }
}