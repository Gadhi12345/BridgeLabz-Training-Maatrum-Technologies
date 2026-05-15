using System;
using System.Linq;

class Program { 
    public static void Main(string[] args)
    {
       List<Student> studentlist = new List<Student>()
       {
           new Student(){ID=1,Name="Adarsh",Gender="Male"},
           new Student(){ID=2,Name="Anwar",Gender="Male"},
           new Student(){ID=3,Name="Kavya",Gender="Female"},
       };
        IQueryable<Student> methodSyntax = studentlist.AsQueryable().Where(std => std.Gender == "Male");
        foreach(var s in methodSyntax)
        {
            Console.WriteLine(s.Name);
        }
    }
}

class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
}
