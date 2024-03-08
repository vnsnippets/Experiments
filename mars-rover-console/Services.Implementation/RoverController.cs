using Domain.Core;
using Domain.Interfaces;
using Services.Interfaces;
using System;

namespace Services.Implementation
{
    public class RoverController : IRoverController
    {
        private static IPlatform Plateau;

        private IRover _marsRover;
        public IRover MarsRover {
            get
            {
                return _marsRover;
            }
            private set
            {
                _marsRover = value;
            }
        }

        public RoverController(IPlatform plateau)
        {
            if (plateau.IsValidPlatform)
                Plateau = plateau;
            else
                throw new Exception("Plateau limits are invalid.");
        }

        public void InitializeRover(IRover rover)
        {
            if (Plateau.IsWithinBounds(rover.Position))
                MarsRover = rover;
            else
                throw new Exception("Rover cannot land outside the platform.");
        }

        public void MoveRover(int steps = 1)
        {
            int X = MarsRover.Position.X;
            int Y = MarsRover.Position.Y;

            switch (MarsRover.Heading)
            {
                case 'N':
                    Y++;
                    break;

                case 'S':
                    Y--;
                    break;

                case 'E':
                    X++;
                    break;

                case 'W':
                    X--;
                    break;
            }

            var NewPosition = new Coordinates { X = X, Y = Y };
            if (Plateau.IsWithinBounds(NewPosition))
                MarsRover.Move(NewPosition);
            else
                throw new Exception(string.Format("Command denied. Rover is at boundary ({0},{1}).", MarsRover.Position.X, MarsRover.Position.Y));
        }

        public void TurnRoverLeft() => MarsRover.TurnLeft();

        public void TurnRoverRight() => MarsRover.TurnRight();
    }
}
