using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = "students.csv";

        // WRITE CSV FILE
        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.WriteLine("Id,Name,Department");

            writer.WriteLine("101,Adarsh,CSE");
            writer.WriteLine("102,Rahul,IT");
            writer.WriteLine("103,Kiran,ECE");
        }

        Console.WriteLine("CSV File Written Successfully");

        Console.WriteLine();

        // READ CSV FILE
        using (StreamReader reader = new StreamReader(path))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(',');

                foreach (string item in data)
                {
                    Console.Write(item + " ");
                }

                Console.WriteLine();
            }
        }
    }
}