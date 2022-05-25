using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;

namespace OOPTraining
{
    class PrinciplesOOP
    {
        public static void Main(string[] args)
        {
            Person<int, int> ivan = new Person<int, int>(1, -163, "Ivan") { Phone = "0993253523", Email = "ivanhub235@gmail.com", Country = "Ukraine" };
            ivan.Age = 5;
            Person<string, uint> misha = new ("bcs", 257, "Misha") { Phone = "0663253523", Country = "Ukraine" };

            Console.WriteLine(ivan.Age);
            ivan.PrintPerson();
            ivan.PrintContacts();
            Console.WriteLine(misha.Age);
            misha.PrintPerson();
            misha.PrintContacts();
            Console.WriteLine(Person<object, object>.minAge);
            Console.WriteLine(Person<object, object>.typeName);

            Console.WriteLine();

            Employee<string, string> valentyn = new Employee<string, string>("vantn", "Hello People", "Valentyn", new Company("PanteraSoft")) { Work = new Company("Murka") };
            valentyn.Age = 17;
            Employee<long, byte> vika = new(253, 98, "Vika", null) { Email = "vika003@gmail.com", Country = "USA" };
            vika.Age = 25;
            Person<uint, long> natali = new Employee<uint, long>(9, 2892534374347, "Natali", new Company("ThinkMobile")) { Phone = "0992278534", Email = "natali@gmail.com", Country = "Poland", Work = new Company("Berry") };
            natali.Age = 149;

            Console.WriteLine(valentyn.Age);
            valentyn.PrintPerson();
            valentyn.PrintContacts();
            Console.WriteLine(vika.Age);
            vika.PrintPerson();
            vika.PrintContacts();
            Console.WriteLine(natali.Age);
            natali.PrintPerson();
            natali.PrintContacts();

            Console.WriteLine(Employee<object, object>.minAge);
            Console.WriteLine(Employee<object, object>.typeName);

            Console.WriteLine();

            object lina = new Person<int, int>(5, 2880, "Linka") { Name = "Lina" };
            var kiril = new Person<string, string>("naer", "kir022", "") { Name = "Kiril" };
            Person<int, string> nemo = new Person<int, string>(2, "Nwonknu", "Lina") { Name = "Linka"};

            bool object1EqualsObject2 = lina.Equals(kiril);
            bool object1EqualsObject3 = lina.Equals(nemo);
            bool object2EqualsObject3 = kiril.Equals(nemo);
            Console.WriteLine(object1EqualsObject2);
            Console.WriteLine(object1EqualsObject3);
            Console.WriteLine(object2EqualsObject3);

            Console.WriteLine();

            bool linaIsPerson = lina is Person<object, object>;
            bool nemoIsNotPerson = typeof(Person<object, object>) != nemo.GetType();
            Console.WriteLine(linaIsPerson);
            Console.WriteLine(nemoIsNotPerson);

            Console.WriteLine();

            Console.WriteLine($"Id: {kiril.Id};");
            Console.WriteLine($"Password: {kiril.Password};");
            Console.WriteLine($"Name: {kiril.Name}");

            Console.WriteLine();

            string messageInString = "Hello World!";
            int messageInInt = 123;
            valentyn.Message<string>(ref messageInString);
            valentyn.Message<int>(ref messageInInt);

            Console.WriteLine("DELEGATES"); // How I was learning delegates

            SendMessageOfTypeMessage(new EmailMessage("It is Email Message"));
            SendMessageOfTypeMessage<SmsMessage>(new SmsMessage("It is SMS Message"));
            Direct<Message, Person<int, string>> message = new Direct<Message, Person<int, string>>();
            message.SendMessage(new Person<int, string>(274, "SAS050" , "050 Person"), new Person<int, string>(275, "SWAT005", "005 Person"), new Message("It is message from SAS to SWAT"));
            SendMessageOfTypeMessage(new Message("It is new Message from method SendMessage"));

            // Main of classes:
            AutoWithStringID<char> nissan = new AutoWithStringID<char>('N', 4);
            Console.WriteLine($"{nissan.Id} : {nissan.Wheels}");
            LorryWithMixedTypes<int, char> lorryName = new LorryWithMixedTypes<int, char>(2, '8');
            Console.WriteLine($"{lorryName.Id} : {lorryName.Wheels}");
            UniversalLorry<int, int> universalLorry = new UniversalLorry<int, int>(3, 6, "Volvo");
            Console.WriteLine($"{universalLorry.Id} : {universalLorry.Wheels}");

            Console.WriteLine();

            // Delegates
            DelegatesOfGame delegateClass = new DelegatesOfGame();
            double currentHealth = 65.2d;
            
            EventOfHealth<double> heal = Healing;
            heal(ref currentHealth, 25.3d);

            EventOfHealth<int> hit = delegateClass.HittingFromEnemy;
            hit(ref currentHealth, 12);

            EventOfHealth<int>? healFromFriend = delegateClass.HealingFromFriend;
            healFromFriend += Healing;
            healFromFriend -= delegateClass.HealingFromFriend;
            healFromFriend?.Invoke(ref currentHealth, 25);

            EventOfHealth<double> hitFromBoss = delegateClass.HittingFromBoss;
            hitFromBoss(ref currentHealth, 36.7d);

            Console.WriteLine();            

            Person<int, string> investor = new Person<int, string>(432, "inv234est", "Vlad") { Country = "Ukraine" };
            investor.Notify += TransactionMessage;            
            investor.PutMoney(550);
            investor.Notify -= TransactionMessage;
            investor.TakeMoney(100);            
            investor.Notify += PrintRedMessage;           
            investor.TakeMoney(250);            
            investor.Notify -= PrintRedMessage;
            investor.Notify += TransactionMessage;
            investor.TakeMoney(150);           
            investor.TakeMoney(200);
            investor.TakeMoney(50);
            int commission = 5;
            Operation addingTakeSums = delegate (int x, int y) { Console.WriteLine($"Sum is: {x + y + commission}"); };            
            addingTakeSums(100, 250);

            Console.WriteLine();

            Operation add = (x, y) => Console.WriteLine(x + y);
            int[] myMoney = new int[] { 15, 232, 36, 75, 858, 8, 3, 26, 68, 4, 35, 7, 47, 5, 7, 67};
            Console.WriteLine(Sum(myMoney, x => x % 5 == 0));

            Console.WriteLine();

            MessageConverter<SmsMessage, Message> emailMessageconverter = ConvertToEmailMessage;
            Message emailMessage = emailMessageconverter(new SmsMessage("Hello Email!"));
            Console.WriteLine(emailMessage.Text);

            MessageConverter<Message, SmsMessage> smsMessageConverter = ConvertToSmsMessage;
            Message smsMessage = smsMessageConverter(new Message("It is only Message"));
            Console.WriteLine(smsMessage.Text);

            void DoOperation(int x, int y, Action<int, int> op) => op(x, y);
            void Multiply(int x, int y) => Console.WriteLine($"{x} * {y} = {x * y}");
            void Add(int x, int y) => Console.WriteLine($"{x} + {y} = {x + y}");

            DoOperation(20, 2, Add);
            Predicate<int> isEven = (x) => x % 2 == 0;
            Console.WriteLine(isEven(45));

            int BankOperations(double firstselection, double secondselection, double procentForMonth, Func<double, double, double, int> deposit) => deposit(firstselection, secondselection, procentForMonth);
            int FindTimeForProcent(double haveMoney, double wantMoney, double procentForMonth)
            {
                int howMonthIneed = 0;
                while (haveMoney < wantMoney)
                {
                    haveMoney += haveMoney * procentForMonth;
                    howMonthIneed++;
                }
                return howMonthIneed;
            }
            int FindMoneyForMonths(double needMoney, double months, double procentForMonth)
            {
                while (months > 0)
                {
                    needMoney -= needMoney * procentForMonth;
                    months--;
                }
                return (int)needMoney;
            }
            int months = BankOperations(6500, 15000, 0.06d, FindTimeForProcent);
            Console.WriteLine(months);
            int money = BankOperations(15000, 15, 0.06d, FindMoneyForMonths);
            Console.WriteLine(money);

            var multiplyOuter = (int n) => (int m) => n * m;
            var fn = multiplyOuter(5);
            Console.WriteLine(fn(6));

            Console.WriteLine();


            Console.WriteLine("INTERFACES: "); // How I was learning interfaces

            IMovable firstPerson = new Person<string, int>("tsrif", 5235, "First");
            Person<string, int> secondPerson = new("dnoces", 3552, "Second");
            firstPerson.Move(30, 5); 
            Console.WriteLine(secondPerson.Name);
            secondPerson.Move(30, 5);

            AutoWithStringID<int> mersedes = new(15, 6);
            Console.WriteLine("Mersedes: ");
            if (mersedes is IMovable action) action.Move(500, 5);
            IMovable bmw = new UniversalLorry<int, int>(15, 5, "Bus");
            Console.WriteLine("BMW: ");
            bmw.Move(350, 4);
            Console.WriteLine("Mixed Lorry: ");
            LorryWithMixedTypes<int, int> mixedLorry = new(92, 6);
            ((IMovable)mixedLorry).Move(200, 3);
            ((IMovie)mixedLorry).Move(150, 2);

            Console.WriteLine();

            Person<string, string> bob = (Person<string, string>)valentyn.Clone();
            bob.Name = "Bob";
            bob.Company = new Lazy<string>("Biobober");
            Console.WriteLine($"Name: {bob.Name} || Company: {bob.Company}");

            Employee<string, string> tom = new Employee<string, string>("tomas3", "tms632", "Tom", new Company("AssaultCompany"));
            Employee<string, string> nick = (Employee<string, string>)tom.Clone();
            nick.Name = "Nick";
            nick.Work = new Company("CoolBox");
            Console.WriteLine($"Name: {nick.Name} || Company: {nick.Work?.Name}");

            Employee<string, string>[] employees = { tom, nick };
            Array.Sort(employees, new EmployeeComparer());
            foreach (Employee<string, string> employee in employees)
            {
                Console.WriteLine($"{employee.Name} - {employee.Age}");
            }

            Console.WriteLine();
            Console.WriteLine("\t\tOperators");
            Console.WriteLine("States");

            State uzhgorod = new State { Area = 23, Population = 2 };
            State lviv = new State { Area = 41, Population = 5 };
            State kyiv = uzhgorod + lviv;
            Console.WriteLine(kyiv.Population);  
            if (uzhgorod > lviv)
            {
                Console.WriteLine("Uzhgorod is greater than Lviv");
            }
            else
            {
                Console.WriteLine("Uzhgorod is lesser than Lviv");
            }

            Console.WriteLine("Sandwich");
            Bread bread = new Bread { Weight = 80 };
            Butter butter = new Butter { Weight = 20 };
            Sandwich sandwich = bread + butter;
            Console.WriteLine(sandwich.Weight);

            Console.WriteLine("Clocks");
            Clock clock = new Clock { Hours = 15 };
            int x = (int)clock;
            Console.WriteLine(x); 
            Clock clock2 = new Clock() { Hours = 13};
            Console.WriteLine(clock2.Hours);
            clock2.Hours = 34;
            Console.WriteLine(clock2.Hours);

            Console.WriteLine("Celcius and Fahrenheit");
            Celcius celcius = new Celcius { Gradus = 25 };
            Fahrenheit fahrenheit = celcius;
            Console.WriteLine(fahrenheit.Gradus);
            celcius = fahrenheit;
            Console.WriteLine(celcius.Gradus);

            Console.WriteLine();
            Console.WriteLine("\t\tIndexators:");
            Console.WriteLine("Footballers");
            FootballTeam ukraine = new FootballTeam();
            ukraine[0] = new Footballer { Name = "Shevchenko", Number = 9 };
            ukraine[1] = new Footballer { Name = "Lomachenko", Number = 10 };
            ukraine[2] = new Footballer { Name = "Yaremchuk", Number = 8 };
            ukraine[20] = new Footballer { Name = "Ronaldo", Number = 9 };
            Console.WriteLine(ukraine[1]?.Name);

            Console.WriteLine("Dictionary");
            Dictionary dict = new Dictionary();
            Console.WriteLine(dict["blue"]);
            dict["blue"] = "Блакитний";
            Console.WriteLine(dict["blue"]);

            var user = new { Name = "Tom", Age = 34 };            
            Console.WriteLine(user.Name);
            int[] nums = { 54, 7, -41, 2, 4, 2, 89, 33, -5, 12 };
            // Sorting
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        (nums[i], nums[j]) = (nums[j], nums[i]);
                    }                        
                }
            }
            // Print
            Console.WriteLine("Print sorted massive");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
            // Records
            var soldier = new Soldier("Bill", 37);            
            Console.WriteLine(soldier); // Person {Name = Tom, Age = 37}

            // Patterns
            Console.WriteLine(Calculate(20000M));
            int[] iqOfMyClassmates = new int[15] { 102, 104, 120, 144, 125, 70, 95, 69, 52, 96, 92, 105, 120, 137, 91 };            
            for(int i = 0; i < iqOfMyClassmates.Length-1; i++)
            {
                if (iqOfMyClassmates[i] > iqOfMyClassmates[i + 1])
                {
                    int template = iqOfMyClassmates[i];
                    iqOfMyClassmates[i] = iqOfMyClassmates[i + 1];
                    iqOfMyClassmates[i + 1] = template;
                }
            }
            // LINQ
            Console.WriteLine("LINQ and Dictionaries");
            var bookshelf = new List<string>();
            var jobFinders = new List<string>() { "Nelson", "Jadua", "Pitter"};
            bookshelf.Add("Mike");
            bookshelf.AddRange(jobFinders);
            foreach (var item in bookshelf)
            {
                Console.WriteLine(item);
            }

            Dictionary<int, string> bonuses = new Dictionary<int, string>() 
            {
                {1, "3$" },
                {3, "5$" },
                {5, "10$" },
                {10, "50$" }
            };            
            bonuses.Remove(5);
            bonuses.TryAdd(10, "100$");
            if (!bonuses.ContainsKey(1)) bonuses.Add(1, "1$");
            bonuses.TryAdd(12, "100$");
            foreach (var item in bonuses)
            {
                Console.WriteLine(item.Value);
            }

            Dictionary<int, string> keysNumbers = new Dictionary<int, string>(bonuses)
            {
                {15, "150$"},
                {20, "500$"},
            };
            foreach (var item in keysNumbers)
            {
                Console.WriteLine($"Key: {item.Key} || Value: {item.Value}");
            }
            LinkedList<int> linkedListMain = new LinkedList<int>(new[] { 15, 25, 50, 75, 125 });
            LinkedListNode<int> linkedListNodeMain = new LinkedListNode<int>(6);
            LinkedListNode<int> linkedListNode1 = new LinkedListNode<int>(1);
            LinkedListNode<int> linkedListNode2 = new LinkedListNode<int>(2);
            LinkedListNode<int> linkedListNode3 = new LinkedListNode<int>(3);            
            linkedListMain.AddFirst(linkedListNode1);
            linkedListMain.AddLast(linkedListNode3);
            linkedListMain.AddAfter(linkedListNode1, linkedListNode2);
            linkedListMain.Remove(25);
            Console.WriteLine("LinkedList: ");
            foreach(var item in linkedListMain)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Queue: ");
            Queue<string> consumers = new Queue<string>();            
            consumers.Enqueue("Nick");            
            consumers.Enqueue("Jessy");            
            consumers.Dequeue();            
            consumers.Enqueue("Bob");            
            consumers.Enqueue("Timberly");            
            consumers.Dequeue();            
            consumers.Enqueue("John");           
            consumers.Dequeue();            
            consumers.Dequeue();
            PrintCunsumers(consumers);

            Console.WriteLine("Stack: ");
            var bookshelfs = new Stack<string>();
            bookshelfs.Push("Stone");           
            bookshelfs.Push("Water");           
            bookshelfs.Push("Fire");  

            string firstBook = bookshelfs.Peek();
            Console.WriteLine(firstBook);
            firstBook = bookshelfs.Pop();
            Console.WriteLine(firstBook);
            string secondBook = bookshelfs.Pop();
            Console.WriteLine(secondBook);
            string thirdBook = bookshelfs.Pop();            
            Console.WriteLine(thirdBook);

            Console.WriteLine("Observable Collection: ");
            var pets = new ObservableCollection<string>() { "Rex", "Monica"};
            pets.CollectionChanged += Pets_CollectionChanged;
            pets.Add("Marta");
            pets.Remove("Rex");
            pets[0] = "Monaco";
            Console.WriteLine("Pets: ");
            foreach (var item in pets)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("IEnumerators and etc.");
            Company microsoft = new Company("Microsoft");
            microsoft.employees = new Employee<int, string>[5] 
            { 
                new Employee<int, string>(11, "Hsgare", "Nelson", microsoft), 
                new Employee<int, string>(22, "herhs", "Mike", microsoft),
                new Employee<int, string>(33, "srthjsht", "Sir", microsoft),
                new Employee<int, string>(44, "aghrgh", "Timur", microsoft),
                new Employee<int, string>(55, "sehtr", "Trevor", microsoft),
            };
            Console.WriteLine("Microsoft personal:");
            foreach (Employee<int, string> employee in microsoft)// який тип був при var замість Employee<int, string>
            {
                Console.WriteLine(employee.Name);
            }
            // Strings
            Console.WriteLine("Strings: ");
            string s1 = new String(new char[] { 'W', 'o', 'r', 'l', 'd' });
            int moneyInt = 25;
            string moneyString = string.Format("{0:f1}", moneyInt);
            Console.WriteLine(s1);
            Console.WriteLine(moneyString);
            StringBuilder stringBuilder = new StringBuilder("Hello");
            string welcomeShort = "Hi";
            string welcomeLong = "Hi there!";
            string[] welcomes = new string[] { stringBuilder.ToString(), welcomeShort, welcomeLong };
            string welcomesAll = String.Join(" | ", welcomes);
            Console.WriteLine(welcomesAll);

            string myPhoneNumber = "099-288-0228";
            Regex regex = new Regex(@"\d{3}-\d{3}-\d{4}");
            if (regex.IsMatch(myPhoneNumber)) Console.WriteLine("Your phone number: {0} is right.", myPhoneNumber);
            else Console.WriteLine("Phone number is not found...");

            // Addition classes and structures
            Console.WriteLine("Addition classes and structures:");
            Console.WriteLine();
            int[][] valentynMarks = new int[3][]
            {
                new int[10]{10, 12, 9, 11, 12, 11, 7, 12, 9, 11},
                new int[10]{10, 12, 9, 11, 12, 11, 7, 12, 11, 10},
                new int[10]{10, 12, 9, 11, 12, 11, 7, 12, 12, 12},

            };
            Span<int> firstMonth = valentynMarks[0];
            Span<int> secondMonth = valentynMarks[0];
            Span<int> thirdMonth = valentynMarks[0];
            ReadOnlySpan<int> endOfFirstMonth = new ReadOnlySpan<int>(firstMonth.ToArray());
            ReadOnlySpan<int> endOfsecondMonth = new ReadOnlySpan<int>(secondMonth.ToArray());
            ReadOnlySpan<int> endOfthirdMonth = new ReadOnlySpan<int>(thirdMonth.ToArray());
            Console.Write("First month: ");
            foreach (var mark in endOfFirstMonth)
            {
                Console.WriteLine(mark + " ");
            }
            Console.Write("Second month: ");
            foreach (var mark in endOfsecondMonth)
            {
                Console.WriteLine(mark + " ");
            }
            Console.Write("Third month: ");
            foreach (var mark in endOfthirdMonth)
            {
                Console.WriteLine(mark + " ");
            }

            Console.WriteLine("It is end of this project");
            Console.WriteLine("Thank you for your attention ^_^");

        }       

        public static void Pets_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs events)
        {
            switch (events.Action)
            {
                case NotifyCollectionChangedAction.Add: 
                    if (events.NewItems?[0] is string newPet)
                        Console.WriteLine($"Pet {newPet} was added");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (events.OldItems?[0] is string oldPet)
                        Console.WriteLine($"Pet {oldPet} was removed");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    if (events.NewItems?[0] is string replacingPet && events.OldItems?[0] is string replacedPet)
                        Console.WriteLine($"Pet {replacedPet} was replaced to {replacingPet}");
                    break;
                            
            }
        }
        public static void PrintCunsumers(Queue<string> consumers)
        {
            foreach (var item in consumers)
            {
                Console.Write(item + " ");
            }
        }
        static decimal Calculate(decimal sum)
        {
            return sum switch
            {
                <= 15000 => 0,              
                < 60000 => sum * 0.11M, 
                < 200000 => sum * 0.15M, 
                _ => sum * 0.2M        
            };
        }        
        public record Soldier(string Name, int Age);
        public record Capitan(string Name, int Age, string Position) : Soldier(Name, Age);
        public static EmailMessage ConvertToEmailMessage(Message message) => new EmailMessage(message.Text);
        public static SmsMessage ConvertToSmsMessage(Message message) => new SmsMessage(message.Text);
        delegate E MessageConverter<in M, out E>(M message);
        public static void SendMessageOfTypeMessage<T>(T message) where T : Message
        {
            Console.WriteLine(message.Text);
        }
        public static void TransactionMessage(string message) => Console.WriteLine(message);        
        public static void PrintRedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void PrintYellowMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static int Sum (int[] numbers, MathChecking checking)
        {
            int result = 0;
            foreach (int num in numbers)
            {
                if (checking(num)) result += num;                
            }
            return result;
        }
        static void Healing<H>(ref double currentHealth, H healing)
        {
            try
            {
                currentHealth += Convert.ToDouble(healing);
            }
            catch (Exception)
            {
                Console.WriteLine("You can not healing!");
            }            
            Console.WriteLine($"HEALTH after own healing: {currentHealth}.");
        }
        delegate void EventOfHealth<E>(ref double health, E eventOf);        
        
        delegate void Operation(int x, int y);  
        public delegate bool MathChecking(int x);
    }
}