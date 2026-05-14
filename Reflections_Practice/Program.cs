using System;
using System.Reflection;

class Student
{
    public int Id;
    public string Name;

    public void Display()
    {
        Console.WriteLine("Student Method");
    }
}

class Program
{
    static void Main()
    {
        // Get Type Information
        Type t = typeof(Student);

        Console.WriteLine("Class Name: " + t.Name);

        // Get Fields
        FieldInfo[] fields = t.GetFields();

        foreach (FieldInfo f in fields)
        {
            Console.WriteLine("Field: " + f.Name);
        }

        // Get Methods
        MethodInfo[] methods = t.GetMethods();

        foreach (MethodInfo m in methods)
        {
            Console.WriteLine("Method: " + m.Name);
        }
    }
}