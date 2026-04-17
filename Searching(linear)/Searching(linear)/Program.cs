namespace Searching_linear_
{
    using System;
    class Program
    {
        static void Main()
        {
          
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(Console.ReadLine());

            
            int key = int.Parse(Console.ReadLine());

            int pos = -1; 

            
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == key)
                {
                    pos = i; 
                    break;
                }
            }

            if (pos != -1)
                Console.WriteLine("Found at index: " + pos);
            else
                Console.WriteLine("Not Found");
        }
    }
}

