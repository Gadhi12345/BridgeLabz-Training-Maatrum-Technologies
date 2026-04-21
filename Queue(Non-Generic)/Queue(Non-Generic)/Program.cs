using System;
using System.Collections;

class Program
{
    static void Main()
    {
        Queue q = new Queue();

        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Marks: ");
        double marks = double.Parse(Console.ReadLine());

        // Enqueue (Add)
        q.Enqueue(id);
        q.Enqueue(name);
        q.Enqueue(marks);

        Console.WriteLine("\nQueue Elements:");
        foreach (var item in q)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nFront Element: " + q.Peek());

        Console.WriteLine("\nDequeued: " + q.Dequeue());

        Console.WriteLine("\nAfter Dequeue:");
        foreach (var item in q)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nContains Name:");
        Console.WriteLine(q.Contains(name));

        Console.WriteLine("\nAdding New Element:");
        q.Enqueue("NewValue");

        foreach (var item in q)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nClear Queue:");
        q.Clear();
        Console.WriteLine("Count: " + q.Count);
    }
}