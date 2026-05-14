using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Custom Validation Attribute
class AgeValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        int age = Convert.ToInt32(value);

        if (age >= 18)
        {
            return true;
        }

        return false;
    }
}

class Student
{
    [Required]
    public string Name { get; set; }

    [AgeValidation(ErrorMessage =
        "Age must be 18 or above")]
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        Student s = new Student()
        {
            Name = "Adarsh",
            Age = 15
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