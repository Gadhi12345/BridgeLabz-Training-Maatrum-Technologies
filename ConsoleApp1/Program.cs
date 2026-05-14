using System;

class Program
{
    [Obsolete]
    public static void OldMethod()
    {
        Console.WriteLine("Old method running");
    }

    public static void NewMethod()
    {
        Console.WriteLine("New method running");
    }

    static void Main()
    {
        OldMethod();  // ⚠ will show warning
    }
}



