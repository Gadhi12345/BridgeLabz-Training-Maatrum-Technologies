using System;


class BalanceException : Exception
{
    public BalanceException(String message) : base(message) { }
}
class program
{
    static void Main()
    {
        int balance = 1000;

        try
        {
            Console.Write("Enter the Amount :");
            int amount = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("Entered Amount :" + amount);

            if (amount > balance)
            {
                throw new BalanceException("Insufficient balance");
            }
            Console.WriteLine("Withdrawal successful");

            /*
             this is used to print normal without custom execption
            if(amount > balance)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                Console.WriteLine("Withdrawal successful");
            }
            
             */

        }
        catch (BalanceException ex)
        {
            Console.WriteLine("Custom Message : " + ex.Message);


        }
        catch (Exception ex)
        {
            Exception newEx = new Exception("Transaction failed", ex);

            Console.WriteLine(newEx.Message);
            Console.WriteLine("Inner: " + newEx.InnerException.Message);

            // Console.WriteLine("System error : "+ ex.Message);

        }
        finally
        {
            Console.WriteLine("Transaction finished");
        }
    }
}