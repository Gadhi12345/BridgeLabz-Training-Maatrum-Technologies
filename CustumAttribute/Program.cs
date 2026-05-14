using System;

// Custom Attribute
class DeveloperAttribute : Attribute
{
    public string Name;

    public DeveloperAttribute(string name)
    {
        Name = name;
    }
}

// Using Attribute
[Developer("Adarsh")]
class Student
{
}

class Program
{
    static void Main()
    {
        Type t = typeof(Student);

        // Get Attribute
        object[] attrs =
            t.GetCustomAttributes(false);

        foreach (object attr in attrs)
        {
            DeveloperAttribute d =
                (DeveloperAttribute)attr;

            Console.WriteLine("Developer: " + d.Name);
        }
    }
}