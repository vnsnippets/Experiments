using Domain.Core;

namespace Domain.Interfaces
{
    public interface IPlatform
    {
        int LimitX { get; set; }
        int LimitY { get; set; }

        bool IsValidPlatform { get; }

        bool IsWithinBounds(Coordinates Position);
    }
}
