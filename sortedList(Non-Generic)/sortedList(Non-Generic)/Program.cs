using System;
using System.Collections;

class Program
{
    static void Main()
    {
        SortedList sl = new SortedList();

        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Marks: ");
        double marks = double.Parse(Console.ReadLine());

        sl["ID"] = id;
        sl["Name"] = name;
        sl["Marks"] = marks;

        Console.WriteLine("\nAccess:");
        Console.WriteLine("ID: " + sl["ID"]);
        Console.WriteLine("Name: " + sl["Name"]);
        Console.WriteLine("Marks: " + sl["Marks"]);

        Console.WriteLine("\nContains:");
        Console.WriteLine(sl.ContainsKey("ID"));

        Console.WriteLine("\nSorted Output:");
        foreach (DictionaryEntry entry in sl)
        {
            Console.WriteLine(entry.Key + " : " + entry.Value);
        }

        Console.WriteLine("\nRemove:");
        sl.Remove("Marks");

        foreach (DictionaryEntry entry in sl)
        {
            Console.WriteLine(entry.Key + " : " + entry.Value);
        }

        Console.WriteLine("\nUpdate:");
        sl["Marks"] = 888;

        foreach (DictionaryEntry entry in sl)
        {
            Console.WriteLine(entry.Key + " : " + entry.Value);
        }

        Console.WriteLine("\nAccess using index:");
        Console.WriteLine("Key at index 0: " + sl.GetKey(0));
        Console.WriteLine("Value at index 0: " + sl.GetByIndex(0));

        Console.WriteLine("\nRemoveAt:");
        sl.RemoveAt(0);

        foreach (DictionaryEntry entry in sl)
        {
            Console.WriteLine(entry.Key + " : " + entry.Value);
        }

        Console.WriteLine("\nClear:");
        sl.Clear();
        Console.WriteLine("Count: " + sl.Count);
    }
}