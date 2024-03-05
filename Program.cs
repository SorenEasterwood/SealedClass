namespace SealedClass
{
    interface IEmployee
    {
        //Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Methods
        public string Fullname();
        public double Pay();
    }
    class Employee : IEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Fullname()
        {
            return FirstName + " " + LastName;
        }
        public virtual double Pay()
        {
            double salary;
            Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
            salary = double.Parse(Console.ReadLine());
            return salary;
        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Fullname()}";
        }

    }
    sealed class Executive : Employee
    {
        public string Title { get; set;}
        public double Salary { get; set;}

        public Executive()
        {
            Title = string.Empty;
            Salary = 0;
        }
        public Executive(int id, string firstName, string lastName, string title, double salary)
            : base(id, firstName, lastName)
        {
            Title = title;
            Salary = salary;
        }
        public sealed override double Pay()
        {
            return Salary;
        }
        public override string ToString()
        {
            return $"ID: {Id}, Title: {Title}, Name: {Fullname()}, Salary: {Salary}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee jane = new Employee(1, "Jane", "Doe");
            Executive boss = new Executive(1, "John", "Doe", "CEO", 100000.11);
            double janeSalary = jane.Pay();
            Console.WriteLine(boss);
            Console.WriteLine($"{jane}, Salary: {janeSalary}");
            Console.ReadLine();
        }
    }
}
