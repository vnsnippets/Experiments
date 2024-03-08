namespace Services.Interfaces
{
    public interface IRoverController
    {
        void TurnRoverLeft();
        void TurnRoverRight();
        void MoveRover(int steps = 1);
    }
}
