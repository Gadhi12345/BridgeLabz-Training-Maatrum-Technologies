using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter size: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];

        Console.WriteLine("Enter elements:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int max = arr[0];

        for (int i = 1; i < n; i++)
        {
            if (arr[i] > max)
                max = arr[i];
        }

        Console.WriteLine("Maximum: " + max);
    }
}