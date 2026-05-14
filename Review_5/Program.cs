using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

class User
{
    public int ID { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<User> Users = new List<User>
        {
            new User{ID=1, Name="Adarsh", Email="adarsh@gmail.com"},
            new User{ID=2, Name="Rahul", Email="rahul@gmail.com"},
            new User{ID=3, Name="Tarun", Email="tarun@gmail.com"}
        };

        string path = "users.json";

        string json = JsonSerializer.Serialize(Users);

        File.WriteAllText(path, json);

        string json2 = File.ReadAllText(path);

        List<User> u =JsonSerializer.Deserialize<List<User>>(json2);

        Console.WriteLine("Enter Search ID:");

        int searchid = int.Parse(Console.ReadLine());

        bool found = false;

        foreach (var u1 in u)
        {
            if (u1.ID == searchid)
            {

                Console.WriteLine($"ID:{u1.ID}");
                Console.WriteLine($"Name:{u1.Name}");
                Console.WriteLine($"Email:{u1.Email}");
               
                Console.WriteLine("\nUpdate User Details");
                string update = Console.ReadLine();
                string pattern = @"^[a-zA-z]";
                if (Regex.IsMatch(update,pattern) && update!="No")
                {
                    Console.Write("Enter New Name : ");
                    u1.Name = Console.ReadLine();

                    Console.Write("Enter New Email : ");
                    u1.Email = Console.ReadLine();


                    string updatedjson = JsonSerializer.Serialize(u1);
                    File.WriteAllText(path, updatedjson);
                }
                found = true;
                break;
            }
        }

        if (found == false)
        {

            Console.WriteLine("User not found");

            Console.WriteLine("\nAdd New User");

            Console.Write("Enter ID :");
            int newid = int.Parse(Console.ReadLine());

            Console.Write("Enter Name :");
            string newname = Console.ReadLine();

            Console.Write("Enter Email:");
            string newemail = Console.ReadLine();

       
            u.Add(new User
            {
                ID = newid,
                Name = newname,
                Email = newemail
            });      
            string addedjson = JsonSerializer.Serialize(u);
            File.WriteAllText(path, addedjson);

        }
    }
}