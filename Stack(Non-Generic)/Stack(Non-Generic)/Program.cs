using System;
using System.Collections;

class Program
{
    static void Main()
    {
        Stack st = new Stack();

        Console.WriteLine("Enter number of elements:");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
            st.Push(Console.ReadLine());

        Console.WriteLine("Top: " + st.Peek());

        Console.WriteLine("Popped: " + st.Pop());

        Console.WriteLine("Contains check: " + st.Contains("test"));

        foreach (var item in st)
            Console.WriteLine(item);

        st.Clear();
    }
}
