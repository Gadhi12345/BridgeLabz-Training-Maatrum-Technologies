using System;
using System.Collections;

class Program
{
    static void Main()
    {
        ArrayList list = new ArrayList();

        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Marks: ");
        double marks = double.Parse(Console.ReadLine());

        list.Add(id);
        list.Add(name);
        list.Add(marks);

        Console.WriteLine("\nAccess:");
        Console.WriteLine("ID: " + list[0]);
        Console.WriteLine("Name: " + list[1]);
        Console.WriteLine("Marks: " + list[2]);

        Console.WriteLine("\nUpdate:");
        list[2] = 999;
        Console.WriteLine("Updated Marks: " + list[2]);

        Console.WriteLine("\nInsert:");
        list.Insert(1, "InsertedValue");

        Console.WriteLine("\nAfter Insert:");
        foreach (var item in list)
            Console.WriteLine(item);

        Console.WriteLine("\nContains Name:");
        Console.WriteLine(list.Contains(name));

        Console.WriteLine("\nRemove:");
        list.Remove(name);

        Console.WriteLine("\nAfter Remove:");
        foreach (var item in list)
            Console.WriteLine(item);

        Console.WriteLine("\nRemoveAt:");
        list.RemoveAt(0);

        foreach (var item in list)
            Console.WriteLine(item);

        Console.WriteLine("\nClear:");
        list.Clear();
        Console.WriteLine("Count: " + list.Count);
    }
}