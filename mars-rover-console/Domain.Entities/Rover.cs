using Domain.Core;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Rover : IRover
    {
        public Coordinates Position { get; set; } = new Coordinates();
        public char Heading { get; set; }

        public void Move(Coordinates position)
        {
            Position = position;
        }

        public void TurnLeft()
        {
            switch(Heading)
            {
                case 'N':
                    Heading = 'W';
                    break;

                case 'S':
                    Heading = 'E';
                    break;

                case 'E':
                    Heading = 'N';
                    break;

                case 'W':
                    Heading = 'S';
                    break;

            }
        }

        public void TurnRight()
        {
            switch (Heading)
            {
                case 'N':
                    Heading = 'E';
                    break;

                case 'S':
                    Heading = 'W';
                    break;

                case 'E':
                    Heading = 'S';
                    break;

                case 'W':
                    Heading = 'N';
                    break;

            }
        }
    }
}
