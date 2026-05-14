using System;
using System.Collections;

public class Arraylist
{
    static void Main()
    {
        ArrayList arr = new ArrayList();

        arr.Add(101);
        arr.Add("Adarsh");
        arr.Add("Adarsh"); // added dupicate values.
        arr.Add("");// added empty string.

        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }

        var arr2 = new ArrayList()
        {
            102 , "Anwar",
        };

        foreach (var item in arr2)
        {
            Console.WriteLine(item);
        }

        Console.ReadKey();



    }
}