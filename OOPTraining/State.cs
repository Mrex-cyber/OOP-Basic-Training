namespace OOPTraining
{
    class State
    {
        public decimal Population { get; set; } // население
        public decimal Area { get; set; }       // территория

        public static State operator +(State state1, State state2)
        {
            return new State
            {
                Area = state1.Area + state2.Area,
                Population = state1.Population + state2.Population
            };
        }
        public static bool operator >(State state1, State state2)
        {
            return state1.Population > state2.Population;
        }
        public static bool operator <(State state1, State state2)
        {
            return state1.Population < state2.Population;
        }
    }
    class Clock
    {
        public int Hours { get; set; }
        public static explicit operator Clock(int x)
        {
            return new Clock() { Hours = x % 24 };
        }
        public static implicit operator int(Clock clock)
        {
            return clock.Hours;
        }
    }
    class Celcius
    {
        public double Gradus { get; set; }
        public static implicit operator Celcius(Fahrenheit fahrenheit)
        {
            return new Celcius() { Gradus = (fahrenheit.Gradus - 32) * 5 / 9 };
        }
    }
    class Fahrenheit
    {
        public double Gradus { get; set; }
        public static implicit operator Fahrenheit(Celcius celcius)
        {
            return new Fahrenheit() { Gradus = (celcius.Gradus + 32) * 9 / 5 };
        }
    }

    class Dollar
    {
        public decimal Sum { get; set; }
        public static implicit operator Dollar(Euro euros)
        {
            return new Dollar() { Sum = euros.Sum / 1.14M };
        }
        public static explicit operator Euro(Dollar dollars)
        {
            return new Euro() { Sum = dollars.Sum * 1.14M };
        }
    }
    class Euro
    {
        public decimal Sum { get; set; }
    }
}
