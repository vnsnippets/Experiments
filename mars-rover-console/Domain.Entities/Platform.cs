using Domain.Core;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Platform : IPlatform
    {
        public int LimitX { get; set; }
        public int LimitY { get; set; }

        public bool IsValidPlatform
        {
            get { return (LimitX > 0 && LimitY > 0); }
        }

        public bool IsWithinBounds(Coordinates Position)
        {
            return
                (Position.X >= 0 && Position.X <= LimitX) &&
                (Position.Y >= 0 && Position.Y <= LimitY);
        }
    }
}
