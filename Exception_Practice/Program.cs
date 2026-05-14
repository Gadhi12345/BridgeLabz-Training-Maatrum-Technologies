using System;


class MyException : Exception
{
    public MyException(string message) : base(message)
    {

    }
}

class program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("enter ur age :");
            int n = int.Parse(Console.ReadLine());

            if (n < 18)
            {
                throw new Exception("Age must be above 18+ ");
            }
            Console.WriteLine("Eligible");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Custom Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("code executed ");
        }
    }
}







/*
class program
{
    static void Main()
    {
        
        
        // inner exeception 

        try
        {
            try
            {
                int a = 10;
                int b = 0;
                int c = a / b;
            }
            catch (Exception ex)
            {
                throw new Exception("divison is failed", ex);


            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Inner : " + ex.InnerException.Message);

        }
        
    }
}

 */