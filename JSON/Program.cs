using System;
using System.IO;
using System.Text.Json;

// Student Class
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
}

class Program
{
    static void Main()
    {
        string path = "student.json";

        // Object Creation
        Student student = new Student()
        {
            Id = 101,
            Name = "Adarsh",
            Department = "CSE"
        };

        // OBJECT TO JSON
        string jsonData = JsonSerializer.Serialize(student);

        // WRITE JSON FILE
        File.WriteAllText(path, jsonData);

        Console.WriteLine("JSON File Written Successfully");
        Console.WriteLine();

        // READ JSON FILE
        string readData = File.ReadAllText(path);

        // JSON TO OBJECT
        Student result =
            JsonSerializer.Deserialize<Student>(readData);

        Console.WriteLine("Student Details");
        Console.WriteLine("Id : " + result.Id);
        Console.WriteLine("Name : " + result.Name);
        Console.WriteLine("Department : " + result.Department);
    }
}