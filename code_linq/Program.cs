using System;
using System.Linq;

class Program { 
    public static void Main(string[] args)
    {
        //Query Syntax
        List<int> intList = new List<int>()
        {
            1,2,3,4,4,5,6,6,7,7,8,8,9
        };

        var QuerySyntax = from obj in intList
                          where obj > 5
                          select obj;

        //Method Syntax
        // var MethodSystax=intList.where(x=>x>5).toList();
        foreach (var t in QuerySyntax)
        {
            Console.WriteLine(t);
        }
    }
}
