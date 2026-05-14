using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. VARIABLES

        int age = 22;
        string name = "Adarsh";
        bool isAdult = true;
        char initial = 'A';
        double salary = 50000.50;

        Console.WriteLine($"Name: {name}, Age: {age}, Salary: ₹{salary}");

        // 2. CONSTANT

        const int weight = 80;
        Console.WriteLine($"Weight (constant): {weight}");

        // 3. STRING CONCATENATION

        string greetingName = "Adarsh";
        Console.WriteLine($"Hello {greetingName}");

        // 4. MATHEMATICAL OPERATIONS

        int x = 5;
        int y = 10;
        Console.WriteLine($"Sum of x and y: {x + y}");

        // 5. MULTIPLE VARIABLES

        int a = 4, b = 6, c = 10;
        Console.WriteLine($"Sum of a, b, c: {a + b + c}");

        int d, e, f;
        d = e = f = 10;
        Console.WriteLine($"Sum of d, e, f: {d + e + f}");

        // 6. DATA TYPES

        int myNum = 100000;
        Console.WriteLine($"Integer value: {myNum}");

        long myLong = 15000000000L;
        Console.WriteLine($"Long value: {myLong}");

        float myFloat = 5.75F;
        Console.WriteLine($"Float value: {myFloat}");

        bool isCSharpFun = true;
        Console.WriteLine($"Is C# fun? {isCSharpFun}");

        char myChar = 'A';
        Console.WriteLine($"Character: {myChar}");

        string myString = "Adarsh";
        Console.WriteLine($"String: {myString}");
    }
}