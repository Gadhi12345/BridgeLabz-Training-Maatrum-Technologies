namespace Searching_binary_
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

            int left = 0;
            int right = n - 1;
            int pos = -1;

            
            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] == key)
                {
                    pos = mid;
                    break;
                }
                else if (arr[mid] < key)
                    left = mid + 1;   
                else
                    right = mid - 1; 
            }

          
            if (pos != -1)
                Console.WriteLine("Found at index: " + pos);
            else
                Console.WriteLine("Not Found");
        }
    }
}
