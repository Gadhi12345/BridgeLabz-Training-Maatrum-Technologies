using System;
using System.Collections.Generic;
class Program { 
    static void Main(string[] args)
    {
        List<int> num = new List<int>() { 10, 20, 30 };
        int sum = num.total();
        Console.WriteLine(sum);
    }
}
public static class ExtensionHelper { 
    public static int total(this List<int> n)
    {
        int x = 0;
       foreach(int num in n)
        {
             x = x + num;
        }
        return x;
    }
}
/*
class Program
{
    static void Main(string[] args)
    {
        string text = "Hello World";
        int num = text.GetWordcount();
        Console.WriteLine(num);
    }
}
public static class ExtensionHelper
{
    public static int GetWordcount(this string str)
    {
        return str.Split(" ").Length;
    }
}

*/


/*
 class Program { 
    static void Main(string[] args)
    {
        int num = 5;
        Console.WriteLine(num.Square());
    }
}
public static class ExtensionHelper { 
    public static int Square(this int n)
    {
        return n*n;
    }
}
*/