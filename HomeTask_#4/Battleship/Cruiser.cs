using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Battleship
{
    public class Cruiser : Ship
    {
        public Cruiser(uint x, uint y) : base(x, y)
        {
        }

        public Cruiser(uint x, uint y, Direction direction) : base(x, y, direction)
        {
        }

        public Cruiser(Ship ship) : base(ship)
        {
        }
    }
}