using System;
using System.Collections;

class program
{
    static void Main()
    {
        Hashtable ht = new Hashtable();



        Console.Write("enter ur ID:");
        int id = int.Parse(Console.ReadLine());

        Console.Write("enter ur Name:");
        string name = Console.ReadLine();

        Console.Write("enter ur Marks :");
        double marks = double.Parse(Console.ReadLine());

        ht["ID"] = id;
        ht["Name"] = name;
        ht["Marks"] = marks;

        Console.WriteLine("ID: " + ht["ID"]);
        Console.WriteLine("Name: " + ht["Name"]);
        Console.WriteLine("Marks: " + ht["Marks"]);

        Console.WriteLine();

        if (ht.ContainsKey("ID"))
        {
            Console.WriteLine("ID is present");

        }

        Console.WriteLine();


        foreach (DictionaryEntry entry in ht)
        {
            Console.WriteLine(entry.Key + " : " + entry.Value);
        }


        Console.WriteLine();

        ht.Remove("Marks");

        Console.WriteLine("\nAfter Removing Marks:");

        foreach (DictionaryEntry entry in ht)
        {
            Console.WriteLine(entry.Key + " : " + entry.Value);
        }


        Console.WriteLine();

        ht["Marks"] = 787;

        Console.WriteLine("valus updates: ");

        foreach (DictionaryEntry entry in ht)
        {
            Console.WriteLine(entry.Key + " : " + entry.Value);
        }


        foreach (var key in ht.Keys)
        {


            Console.WriteLine(key);
        }

    }
}