using Domain.Core;

namespace Domain.Interfaces
{
    public interface IRover
    {
        Coordinates Position { get; set; }
        char Heading { get; set; }

        void Move(Coordinates position);
        void TurnLeft();
        void TurnRight();
    }
}
