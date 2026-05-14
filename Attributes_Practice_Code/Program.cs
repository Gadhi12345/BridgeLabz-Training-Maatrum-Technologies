using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

class user
{
    [Required]
    public string Name { get; set; }

    [Range(18, 55)]
    public int age { get; set; }


    [EmailAddress]
    public string EmailAddress { get; set; }

}

class program
{
    static void Main()
    {
        user usr = new user();
        usr.age = 19;
        usr.EmailAddress = "qwerty@srmist.edu.in";
        usr.Name = "Adarsh";

        var context = new ValidationContext(usr);
        var result = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(usr, context, result, true);

        Console.WriteLine("Valid: " + isValid);

        foreach (var r in result)
        {
            Console.WriteLine(r.ErrorMessage);
        }


    }
}









































/*


using System;
using System.Reflection;

class MyCustomAttribute  : Attribute // custom attribute and the attribute is the base class of all attributes .
{
    public string Message;

    public MyCustomAttribute(string message) //here we created the custom message for the attribute
    {
        Message = message;
    }
}

[MyCustomAttribute("this is my custom attribute")]
class Testclass
{

}

class program
{
    static void Main()
    {
        Type t = typeof(Testclass);
        object[] attrs = t.GetCustomAttributes(false);

        foreach(object attr in attrs)
        {
            MyCustomAttribute a =  (MyCustomAttribute)attr;

            Console.WriteLine(a.Message);

        }
    }
}


 
class progrma
{
    static void Main()
    {
        student s = new student();
        s.name = "Adarsh";
        Console.WriteLine(" "+ s.name);

        OldMethod();
        NewMethod();

    }

    [Obsolete ("This is the old method code ")]
    static void OldMethod()
    {
        Console.WriteLine("old method");

    }
    static void NewMethod()
    {
        Console.WriteLine("New method");
    }
}
