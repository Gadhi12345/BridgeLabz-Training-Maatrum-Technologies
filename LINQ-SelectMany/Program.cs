using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;


class Student
{
    public int id { get; set; }
    public string name { get; set; }
    public List<string> Program { get; set; }

    public static List<Student> GetStudents()
    {
        List<Student> newS = new List<Student>() {
            new Student(){id=1,name="Adarsh",Program=new List<string>() {"C","C++"} },
            new Student(){id=2,name="Anwar",Program=new List<string>() {".Net","C++"} },
            new Student(){id=3,name="kavya",Program=new List<string>() {"python","SQL"} },
        };
        return newS;

    }
}



class Program
{
    static void Main(string[] args)
    {
        //Using Method Syntax
        var MethodSyntax = Student.GetStudents()
                                    .SelectMany(std => std.Program,
                                         (student, program) => new
                                         {
                                             StudentName = student.name,
                                             ProgramName = program
                                         }
                                         )
                                    .ToList();
        
        var QuerySyntax = (from std in Student.GetStudents()
                           from program in std.Program
                           select new
                           {
                               StudentName = std.name,
                               ProgramName = program
                           }).ToList();
       
        foreach (var item in QuerySyntax)
        {
            Console.WriteLine(item.StudentName + " => " + item.ProgramName);
        }
        Console.ReadKey();
    }
}

/*
class Program
{
    public static void Main(string[] args)
    {



        IEnumerable<string> MenthodSyn = Student.GetStudents().SelectMany(x => x.Program).Distinct().ToList();
        foreach (string s in MenthodSyn)
        {
            Console.WriteLine(s);
        }


        //there is no SelectMany in QuerySyntax so we use many clauses here 

        IEnumerable<string> QuerySyn = (from std in Student.GetStudents()
                                       from c in std.Program
                                       select c).Distinct().ToList();

        foreach(string s in QuerySyn)
        {
            Console.WriteLine(s);
        }
    }
}

*/
