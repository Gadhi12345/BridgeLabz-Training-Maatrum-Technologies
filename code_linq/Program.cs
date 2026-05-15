using System;
using System.Linq;

class Program { 
    public static void Main(string[] args)
    {
        //Query Syntax
        List<int> x = new List<int>()
        {
            1,2,3,4,4,5,6,6,7,7,8,8,9
        };

        var QuerySyntax = from obj in x
                          where obj > 5
                          select obj;

        //Method Syntax
        // var MethodSyntax=x.where(s=>s>5).Tolist();
        foreach (var t in QuerySyntax)
        {
            Console.WriteLine(t);
        }
    }
}
