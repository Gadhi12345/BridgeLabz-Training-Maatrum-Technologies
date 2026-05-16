using System;
using System.Linq;
using System.Collections.Generic;

class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Dept { get; set; }

    public static List<Employee> GetEmployee()
    {
        List<Employee> employee = new List<Employee>() {
            new Employee(){ID=1,Name="Adarsh",Dept="CSE"},
            new Employee(){ID=2,Name="Adarsh123",Dept="ECE"},
            new Employee(){ID=3,Name="Adarsh345",Dept="EKE"},
        };
        return employee;
    }
}
class Program
{
    public static void Main(string[] args)
    {
        IEnumerable<Employee> QuerySyntax =(from emp in Employee.GetEmployee()
                                            select new Employee()
                                            { 
                                                Name = emp.Name,
                                                ID = emp.ID,
                                                Dept = emp.Dept
                                            }
                                           ).ToList();
    }
}





/*
class Program
{
    public static void Main(string[] args)
    {
        List<int> QuerySun = (from emp in Employee.GetEmployee()
                                   select emp.ID).ToList();
        foreach (var id in QuerySun)
        {
            Console.WriteLine($"{id}");
        }

        IEnumerable<int> MethodSyn = Employee.GetEmployee().Select(emp=>emp.ID);
        foreach (var emp in MethodSyn)
        {
            Console.WriteLine($"{emp}");
        }
    }
}



class Program { 
    public static void Main(string[] args)
    {
        List<Employee> QuerySun = (from emp in Employee.GetEmployee()
                                   select emp).ToList();
        foreach(Employee emp in QuerySun)
        {
            Console.WriteLine($"{emp.ID} {emp.Name} {emp.Dept}");
        }

        IEnumerable<Employee> MethodSyn = Employee.GetEmployee().ToList();
        foreach (Employee emp in MethodSyn)
        {
            Console.WriteLine($"{emp.ID} {emp.Name} {emp.Dept}");
        }
    }
}
*/

