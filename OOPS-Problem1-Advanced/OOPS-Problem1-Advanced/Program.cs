using System;

namespace OOPSBOSSPROB
{
    // 1. Interface → defines role behavior
    interface IPerson
    {
        void Role();
    }

    // 2. Abstract class → salary logic
    abstract class Salary
    {
        public abstract double CalculateSalary();
    }

    // 3. Salary types
    class TeachingSalary : Salary
    {
        public int hours;
        public int rate;

        public override double CalculateSalary()
        {
            return hours * rate;
        }
    }

    class NonTeachingSalary : Salary
    {
        public int salary;

        public override double CalculateSalary()
        {
            return salary;
        }
    }

    // 4. Person class (HAS-A Salary)
    class Person : IPerson
    {
        private string name;
        private int age;
        protected Salary salary;   // HAS-A
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    age = 0;
                    Console.WriteLine("Invalid age, setting to 0");
                }
                else
                {
                    age = value;
                }
            }
        }

        public Person(string n, int a, Salary s, int d)
        {
            name = n;
            Age = a;
            salary = s;
            ID = d;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Name: {name}, Age: {Age}, ID: {ID}");
        }

        public void ShowSalary()
        {
            Console.WriteLine($"Salary: ₹{salary.CalculateSalary()}");
        }

        public virtual void Role()
        {
            Console.WriteLine("Person Role");
        }
    }

    // 5. Teacher
    class Teacher : Person
    {
        private string subject;

        public Teacher(string n, int a, Salary s, int d, string sub)
            : base(n, a, s, d)
        {
            subject = sub;
        }

        public override void Role()
        {
            Console.WriteLine($"Teacher - Subject: {subject}");
        }
    }

    // 6. Staff
    class Staff : Person
    {
        private string department;

        public Staff(string n, int a, Salary s, int d, string dep)
            : base(n, a, s, d)
        {
            department = dep;
        }

        public override void Role()
        {
            Console.WriteLine($"Staff - Department: {department}");
        }
    }

    // 7. Student (only interface)
    class Student : IPerson
    {
        private string name;
        private string course;

        public Student(string n, string c)
        {
            name = n;
            course = c;
        }

        public void Role()
        {
            Console.WriteLine($"Student: {name}, Course: {course}");
        }
    }

    // 8. Main
    class Program
    {
        static void Main(string[] args)
        {
            Salary s1 = new TeachingSalary() { hours = 10, rate = 500 };
            Salary s2 = new NonTeachingSalary() { salary = 20000 };

            Person t = new Teacher("Adarsh", 35, s1, 101, "Math");
            Person st = new Staff("Rahul", 40, s2, 102, "Admin");

            IPerson student = new Student("Ravi", "CSE");

            t.Role();
            t.ShowDetails();
            t.ShowSalary();

            Console.WriteLine();

            st.Role();
            st.ShowDetails();
            st.ShowSalary();

            Console.WriteLine();

            student.Role();
        }
    }
}