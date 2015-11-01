using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;

namespace Battleship
{
    public class PatrolBoat : Ship
    {
        public PatrolBoat(uint x, uint y) : base(x, y)
        {
        }

        public PatrolBoat(uint x, uint y, Direction direction) : base(x, y, direction)
        {
            // default direction for single square ship
            this.Direction = Direction.Horizontal;
        }

        public PatrolBoat(Ship ship) : base(ship)
        {
            this.Direction = Direction.Horizontal;
        }
    }
}