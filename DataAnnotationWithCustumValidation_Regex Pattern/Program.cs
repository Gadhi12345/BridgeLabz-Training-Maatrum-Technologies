using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

// Custom Password Validation using Regex
public class StrongPasswordAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        string password = value as string;

     

        string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$";

        if (password != null && Regex.IsMatch(password, pattern))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(
            "Password must contain uppercase, lowercase, digit, special character and minimum 8 characters"
        );
    }
}

// User Model
public class User
{
    [StrongPassword]
    public string Password { get; set; }
}

// Main Program
class Program
{
    static void Main()
    {
        User u = new User
        {
            Password = "abc123" 
        };

        var results = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(
            u,
            new ValidationContext(u),
            results,
            true
        );

        Console.WriteLine("Is Valid: " + isValid);

        foreach (var error in results)
        {
            Console.WriteLine(error.ErrorMessage);
        }
    }
}