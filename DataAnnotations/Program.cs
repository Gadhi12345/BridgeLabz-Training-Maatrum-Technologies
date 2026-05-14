using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class Student
{
    [Required]
    public string Name { get; set; }

    [Range(18, 30)]
    public int Age { get; set; }

    [EmailAddress]
    public string Email { get; set; }
}

class Program
{
    static void Main()
    {
        Student s = new Student()
        {
            Name = "",
            Age = 15,
            Email = "abcgmail.com"
        };

        // Validation Context
        ValidationContext context =
            new ValidationContext(s);

        // Store Errors
        List<ValidationResult> results =
            new List<ValidationResult>();

        // Validate Object
        bool valid =
            Validator.TryValidateObject(
                s,
                context,
                results,
                true
            );

        if (!valid)
        {
            foreach (ValidationResult r in results)
            {
                Console.WriteLine(r.ErrorMessage);
            }
        }
        else
        {
            Console.WriteLine("Valid Data");
        }
    }
}