namespace OOPTraining
{
    public interface IMovable
    {
        void Move(int distance, int time) 
        { 
            Console.WriteLine($"Your speed of Movable is: {distance/time}"); 
        }
    }
    public interface IMovie : IMovable
    {
        new void Move(int distance, int time)
        {
            Console.WriteLine($"Your speed of Movie is: {distance / time}");
        }
    }
}
