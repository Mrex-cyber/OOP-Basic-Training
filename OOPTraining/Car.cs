namespace OOPTraining
{
    abstract class Car <T> where T : struct
    {
        public T Id { get; }
        public Car(T id)
        {
            Id = id;
        }
    }
    class AutoWithStringID <I>: Car <I>, IMovable
        where I : struct
    {                
        public int Wheels { get; set; }
        public AutoWithStringID(I id, int wheels) : base(id) 
        {
            Wheels = wheels;
        }

    }
    class LorryWithMixedTypes<T, W> : Car<T>, IMovable, IMovie
        where T : struct
        where W : struct
    {
        void IMovie.Move(int distance, int time) => Console.WriteLine($"IMovie {distance / time}.");
        void IMovable.Move(int distance, int time) => Console.WriteLine($"IMovable {distance / time}");
        public W Wheels { get; set; }
        public LorryWithMixedTypes(T id, W wheels) : base(id)
        {
            Wheels = wheels;
        }

    }
    class UniversalLorry <S, N> : LorryWithMixedTypes<S, N>, IMovable
        where S : struct
        where N : struct
    {
        void Move(int distance, int time)
        {
            Console.WriteLine($"Your speed of Lorry is: {distance / time}");
        }
        public string MarkOfLorry { get; set; }
        public UniversalLorry(S id, N wheels, string markOfLorry) : base(id, wheels) 
        { 
            MarkOfLorry = markOfLorry; 
        }

    }
}