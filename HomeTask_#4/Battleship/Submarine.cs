namespace Battleship
{
    public class Submarine : Ship
    {
        public Submarine(Ship ship) : base(ship)
        {
        }

        public Submarine(byte x, byte y, Direction direction) : base(x, y, direction)
        {
            Length = 3;
        }
    }
}