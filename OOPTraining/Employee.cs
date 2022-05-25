namespace OOPTraining
{
    class Employee<I, P> : Person<I, P>, ICloenable
    {
        public new readonly static int minAge = 18;
        public new const string typeName = "Employee";
        public object Clone() => new Employee<I, P>(Id, Password, Name, new Company(Work?.Name));
        public new string Name { get => $"Ms/Mrs {base.Name}"; set => base.Name = value; }
        public Company? Work { get; set; }
        public override sealed int Age { get => base.Age; set { if (value > 17 && value < 120) base.Age = value; } }

        public Employee(I id, P password, string name, Company? work)
            : base(id, password, name)
        {
            if (work == null) work = new Company("None");
            else work = new Company($"{work.Name}");
            Id = id;
            Password = password;
            Name = name;
            Work = work;
            base.Age = 18;
        }
        public void PrintMinAge()
        {
            Console.WriteLine(minAge);
        }
        public override void PrintPerson()
        {
            Console.WriteLine($"{Name} is {Age} years old and works in {Work.Name} company.");
        }
        public new void PrintWork()
        {
            Console.WriteLine($"Company: {Work.Name}");
            base.PrintContacts();
        }
    }
      
    public interface IEnumerator
    {
        bool MoveNext(); 
        object Current { get; }  
        void Reset();
    }
    class CompanyEnumerator : IEnumerator
    {
        Employee<int, string>[] employees;
        int position = -1;
        public CompanyEnumerator(Employee<int, string>[] employees) => this.employees = employees;
        public object Current
        {
            get
            {
                if (position == -1 || position >= employees.Length)
                    throw new ArgumentException();
                return employees[position];
            }
        }
        public bool MoveNext()
        {
            if (position < employees.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public void Reset() => position = -1;
    }
    class Company
    {
        public Employee<int, string>[] employees;
        public string Name { get; set; }
        public Company(string name) => Name = name;

        public IEnumerator GetEnumerator() => new CompanyEnumerator(employees);
    }
    class EmployeeComparer : IComparer<Employee<string, string>>
    {
        public int Compare(Employee<string, string>? p1, Employee<string, string>? p2)
        {
            if (p1 is null || p2 is null)
                throw new ArgumentException("Некорректное значение параметра");
            return p1.Name.Length - p2.Name.Length;
        }
    }
}