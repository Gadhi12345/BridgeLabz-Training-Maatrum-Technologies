using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Name Validation
        string namePattern = @"^[A-Za-z ]+$";

        // Age Validation
        string agePattern = @"^[0-9]{1,3}$";

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        string age = Console.ReadLine();

        // Name Check
        if (Regex.IsMatch(name, namePattern))
        {
            Console.WriteLine("Valid Name");
        }
        else
        {
            Console.WriteLine("Invalid Name");
        }

        // Age Check
        if (Regex.IsMatch(age, agePattern))
        {
            Console.WriteLine("Valid Age");
        }
        else
        {
            Console.WriteLine("Invalid Age");
        }
    }
}