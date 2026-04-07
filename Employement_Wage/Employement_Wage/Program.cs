using System;
namespace EmployementWage
{
    // Abstract base class → cannot be instantiated
    // Defines common properties and behavior for all employees
    public abstract class Employee
    {
        // Public fields
        public int Id;
        public string Name;
        // Private field for encapsulation
        private double salary;
        // Property to access private salary field
        public double Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }
        // Constructor
        public Employee(int i,string n,double s)
        {
            Id = i;
            Name = n;
            salary = s;
        }
        // Abstract method 
        // Demonstrates runtime polymorphism
        public abstract void  CalSalary();
    }
    // Full-time employee class inheriting from Employee
    public class FullTimeEmployee : Employee
    {
        // Constructor calling base constructor
        public FullTimeEmployee(int i,string name,double sa): base(i,name,sa)
        {
            Id = i;
            Name = name;
            Salary = sa;
        }
        // Method specific to FullTimeEmployee
        public void DisplayDetails()
        {
            Console.WriteLine($"Name:{Name},ID:{Id}");
        }
        public override void CalSalary()
        {
            Console.WriteLine($"Full Time Employee Salary:{Salary}");
        }
    }
    // Part-time employee class
    public class PartTimeEmployee : Employee
    {
        private int hrs;

        
        public PartTimeEmployee(int i,string s,double sa,int h):base(i,s,sa)
        {
            Id = i;
            Name = s;
            Salary = sa;
            hrs = h;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Name:{Name},ID:{Id},Hrs Worked:{hrs}");
        }

        // Salary calculated based on hours worked
        public override void CalSalary()
        {
            Console.WriteLine($"Salary of Part Time Employee:{Salary*hrs}");
            
        }

    }
    // Contract employee class
    public class ContractEmployee : Employee
    {
        private int projects;  // Number of projects completed


        public ContractEmployee(int i, string s, double sa,int p):base(i,s,sa)
        {
            Id = i;
            Name = s;
            Salary = sa;
            projects = p;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Name:{Name},ID:{Id},Projects Worked:{projects}");
        }
        // Salary based on number of projects
        public override void CalSalary()
        {
            Console.WriteLine($"COntract Employee Salary:{Salary * projects}");
        }
    }

    class Program { 
        static void Main(string[] args)
        {
            FullTimeEmployee emp1 = new FullTimeEmployee(1, "Adarsh", 32000);
            emp1.DisplayDetails();
            Employee emp2 = new FullTimeEmployee(1, "Adarsh", 32000);
            emp2.CalSalary();
            PartTimeEmployee p1 = new PartTimeEmployee(2, "Adarsh11", 23000, 23);
            p1.DisplayDetails();
            Employee n1 = new PartTimeEmployee(2, "Adarsh11", 23000, 23);
            n1.CalSalary();
            ContractEmployee c1 = new ContractEmployee(3,"Adarsh22",40000,31);
            c1.DisplayDetails();
            Employee c2 = new ContractEmployee(3, "Adarsh22", 40000, 31);
            c2.CalSalary();

            

        }
    }


}