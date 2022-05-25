namespace OOPTraining
{
    public interface ICloenable
    {
        object Clone();
    }
    public interface IComparere<T>
    {
        int Compare(T? x, T? y);
    }
    internal class Person<I, P> : IMovable, IMovie, ICloenable
    {
        public object Clone() => MemberwiseClone();
        public void Move(int distance, int time)
        {
            Console.WriteLine($"Your speed of walking/running is: {distance / time}");
        }
        public Person(I id, P password, string name, string? companyName = "None")
        {
            Password = password;
            Id = id;
            Name = name;
            if (companyName != "None") Company = new Lazy<string>(companyName);
        }
        public readonly static int minAge = 1;
        public const string typeName = "Person";
        public string Name { get; set; } = "";
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
        public I Id { get; set; }
        public P Password { get; set; }
        int age;
        public virtual int Age { get => age; set { if (value > 0 && value < 120) age = value; } }        
        public int Sum { get; private set; }       
        public Lazy<string> Company { get; set; }        
        public void PutMoney(int sum)
        {
            Sum += sum;
            Notify?.Invoke(new AccountEventArgs($"Balance was rised on {sum} UAH", sum ).ToString()!);
        }
        public void TakeMoney(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Notify?.Invoke(new AccountEventArgs($"Balance was rised on {sum} UAH", sum).ToString()!);
            }
            else
            {
                Notify?.Invoke(new AccountEventArgs($"Balance was rised on {sum} UAH", sum).ToString()!);
            }
        }
        public delegate void MoneyEvent(string messageOfTransaction);
        public event MoneyEvent? Notify;   
        public virtual void PrintPerson()
        {
            Console.WriteLine($"{Name} is {Age} years old.");
        }
        public void PrintContacts()
        {
            if (Country == null) Country = "None";
            if (Phone == null) Phone = "None";
            if (Email == null) Email = "None";
            Console.WriteLine($"Person: {Name} || Country: {Country} || Phone: {Phone} || Email: {Email}");
        }
        public override bool Equals(object? obj)
        {
            if (obj is Person<I, P> person) return Name == person.Name;
            return false;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public void Message<Text>(ref Text inputMessage)
        {            
            string[] inputArray = inputMessage!.ToString()!.Split(" ");
            string[] resultArray = new string[inputArray.Length];
            for (int indexOfWord = 0;  indexOfWord < inputArray.Length; indexOfWord++)
            {
                string recoverWord = "";
                for (int indexOfLastLetter = inputArray[indexOfWord].Length-1; indexOfLastLetter >= 0; indexOfLastLetter--)
                {                    
                    recoverWord += inputArray[indexOfWord][indexOfLastLetter];
                }
                resultArray[indexOfWord] = recoverWord;
            }
            string resultString = "";            

            foreach (string word in resultArray)
            {
                resultString += word + " ";
            }
            Console.WriteLine(resultString);
        }
    }    
    class AccountEventArgs
    {
        // Message
        public string Message { get; }
        // Money those changed the balance
        public int Sum { get; }
        public AccountEventArgs(string message, int sum)
        {
            Message = message;
            Sum = sum;
        }
    }
}