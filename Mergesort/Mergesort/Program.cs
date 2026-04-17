namespace Mergesort
{
    using System;

    class Program
    {
        
        static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int i = 0; i < n1; i++)
                L[i] = arr[left + i];

            for (int j = 0; j < n2; j++)
                R[j] = arr[mid + 1 + j];

            int i1 = 0, j1 = 0, k = left;

            
            while (i1 < n1 && j1 < n2)
            {
                if (L[i1] <= R[j1])
                    arr[k++] = L[i1++];
                else
                    arr[k++] = R[j1++];
            }

            while (i1 < n1)
                arr[k++] = L[i1++];

            while (j1 < n2)
                arr[k++] = R[j1++];
        }

      
        static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(Console.ReadLine());
            MergeSort(arr, 0, n - 1);

            Console.WriteLine("Sorted Array:");
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
        }
    }
}
