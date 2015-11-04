using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    public class Board
    {
        private readonly List<Ship> shipsOnBoard;

        public Board()
        {
            shipsOnBoard = new List<Ship>();
        }

        public void Add(Ship patrolBoat)
        {
            if (shipsOnBoard.Any(shipOnBoard => shipOnBoard.OverlapsWith(patrolBoat)))
            {
                throw new ShipOverlapException();
            }

            if (patrolBoat.X > 10 || patrolBoat.Y > 10)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (patrolBoat.Direction == Direction.Vertiacal && (patrolBoat.Y + (patrolBoat.Length - 1)) > 10)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (patrolBoat.Direction == Direction.Horizontal && (patrolBoat.X + (patrolBoat.Length - 1)) > 10)
            {
                throw new ArgumentOutOfRangeException();
            }

            shipsOnBoard.Add(patrolBoat);
        }

        public void Add(string notation)
        {
            Ship resShip = Ship.Parse(notation);
            Add(resShip);
        }

        public List<Ship> GetAll()
        {
            return shipsOnBoard;
        }

        public void Validate()
        {
            //PatrolBoat (4), Cruiser (3), Submarine (2), AircraftCarrier (1)
            int countPatrolBoat = 4;
            int countCruiser = 3;
            int countSubmarine = 2;
            int countAircraftCarrier = 1;

            foreach (Ship shipOnBoard in shipsOnBoard)
            {
                switch (shipOnBoard.Length)
                {
                    case 1:
                        countPatrolBoat = countPatrolBoat - 1;
                        break;
                    case 2:
                        countCruiser -= 1;
                        break;
                    case 3:
                        countSubmarine -= 1;
                        break;
                    case 4:
                        countAircraftCarrier -= 1;
                        break;
                }
            }
            if (countAircraftCarrier + countCruiser + countPatrolBoat + countSubmarine != 0)
            {
                throw new BoardIsNotReadyException();
            }
        }
    }
}