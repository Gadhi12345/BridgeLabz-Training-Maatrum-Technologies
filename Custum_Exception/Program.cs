using System;

// Custom Exception Class
public class InvalidAgeException : Exception
{
    // Constructor
    public InvalidAgeException(string message) : base(message)
    {
    }
}

class Program
{
    static void CheckAge(int age)
    {
        if (age < 18)
        {
            // Throw custom exception
            throw new InvalidAgeException("Age must be 18 or above");
        }

        Console.WriteLine("Eligible to vote");
    }

    static void Main()
    {
        try
        {
            CheckAge(15);
        }
        catch (InvalidAgeException ex)
        {
            Console.WriteLine("Custom Exception Caught");
            Console.WriteLine(ex.Message);
        }
    }
}