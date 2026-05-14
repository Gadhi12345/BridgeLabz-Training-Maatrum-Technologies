using System;
using System.Security.Cryptography.X509Certificates;

namespace LinkedListLearning
{
    class Node
    {
        public int data;
        public Node next;

        public Node(int value)
        {
            data = value;
            next = null;
        }
    }

    class LinkedList
    {
        public Node head;

        // 🔹 Insert at Beginning
        public void InsertAtBeginning(int value)
        {
            Node newNode = new Node(value);
            newNode.next = head;
            head = newNode;
        }

        // 🔹 Insert at End
        public void InsertAtEnd(int value)
        {
            Node newNode = new Node(value);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = newNode;
        }

        // 🔹 Insert at Position
        public void InsertAtPosition(int value, int position)
        {
            Node newNode = new Node(value);

            if (position == 1)
            {
                newNode.next = head;
                head = newNode;
                return;
            }

            Node temp = head;

            for (int i = 1; i < position - 1; i++)
            {
                if (temp == null)
                {
                    Console.WriteLine("Invalid position");
                    return;
                }
                temp = temp.next;
            }

            newNode.next = temp.next;
            temp.next = newNode;
        }

        //  Delete First
        public void DeleteFirst()
        {
            if (head == null)
            {
                Console.WriteLine("List empty");
                return;
            }

            head = head.next;
        }

        // 🔹 Delete Last
        public void DeleteLast()
        {
            if (head == null)
            {
                Console.WriteLine("List empty");
                return;
            }

            if (head.next == null)
            {
                head = null;
                return;
            }

            Node temp = head;

            while (temp.next.next != null)
            {
                temp = temp.next;
            }

            temp.next = null;
        }

        // 🔹 Delete at Position
        public void DeleteAtPosition(int position)
        {
            if (head == null)
            {
                Console.WriteLine("List empty");
                return;
            }

            if (position == 1)
            {
                head = head.next;
                return;
            }

            Node temp = head;

            for (int i = 1; i < position - 1; i++)
            {
                if (temp.next == null)
                {
                    Console.WriteLine("Invalid position");
                    return;
                }
                temp = temp.next;
            }

            if (temp.next == null)
            {
                Console.WriteLine("Invalid position");
                return;
            }

            temp.next = temp.next.next;
        }

        // 🔹 Reverse Linked List
        public void Reverse()
        {
            Node prev = null;
            Node current = head;
            Node next = null;

            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            head = prev;
        }

        // 🔹 Display
        public void Display()
        {
            Node temp = head;

            while (temp != null)
            {
                Console.Write(temp.data + " -> ");
                temp = temp.next;
            }

            Console.WriteLine("null");
        }
    }

    class Program
    {
        static void Main()
        {
            LinkedList list = new LinkedList();

            list.InsertAtEnd(10);
            list.InsertAtEnd(20);
            list.InsertAtEnd(30);

            list.InsertAtBeginning(5);
            list.InsertAtPosition(15, 3);

            Console.WriteLine("After Insertions:");
            list.Display();

            list.DeleteFirst();
            list.DeleteLast();
            list.DeleteAtPosition(2);

            Console.WriteLine("After Deletions:");
            list.Display();

            list.Reverse();

            Console.WriteLine("After Reverse:");
            list.Display();
        }



    }
}

/*
//1.Flip Coin 
            int n = int.Parse(Console.ReadLine());
            Random n1 = new Random();
            int head = 0;
            int tail = 0;
            for(int i = 0; i < n; i++)
            {
                int Res = n1.Next(0, 2);
                if (Res == 0)
                {
                    head++;
                }
                else
                {
                    tail++;
                }
            }
            Console.WriteLine((head * 100) / n);
            Console.WriteLine((tail * 100) / n); 
 //

//2.LeapYear
 int n = int.Parse(Console.ReadLine());
            if((n%4==0 && n%100!=0) || n % 400 == 0)
            {
                Console.WriteLine("Leap Year");
            }
            else
            {
                Console.WriteLine("Not A Leap Year");
            }
//
//3.Power of 2
   int n = int.Parse(Console.ReadLine());

            int res = 1;
            for(int i = 0; i < n; i++)
            {
                Console.Write(res);
                res = res * 2;
            }
//
//3.Harmonic Mean
 Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            float sum = 0;

            for (int i = 1; i <= n; i++)
            {
                sum = sum + (1.0f / i);
            }

            Console.WriteLine("Harmonic Value: " + sum);
//
//4.Prime factors of n
  int n = int.Parse(Console.ReadLine());
            int i = 2;

            while (n > 1)
            {
                if (n % i == 0)
                {
                    Console.Write(i + " ");
                    n = n / i;
                }
                else
                {
                    i++;
                }
            }
5.Find Quotient and Remainder
6.Check if a Character is vowel or consonant
7.Largest of 3 numbers
8.Swap if 2 numbers
9.Fabonacii Series
//
            int n = int.Parse(Console.ReadLine());
            int a = 0;
            int b = 1;
            if (n >= 1)
            {
                Console.WriteLine(a);
            }
            if (n >= 2)
            {
                Console.WriteLine(b);
            }
            for(int i = 3; i < n; i++)
            {
                int c = a + b;
                Console.WriteLine(c);
                
                a = b;
                b = c;
            }
//
10.Perfect Number
//
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for(int i = 1; i <= n/2; i++)
            {
                if (n % i == 0)
                {
                    sum = sum + i;
                }
            }
            if (sum == n)
            {
                Console.WriteLine("Perfect Number");
            }
            else
            {
                Console.WriteLine("Not a Perfect Number");
            }
//
11.Prime Numbers
//
  int n = int.Parse(Console.ReadLine());

            if (n <= 1)
            {
                Console.WriteLine("Not Prime");
                return;
            }

            for (int i = 2; i<= n/2; i++)
            {
                if (n % i == 0)
                {
                    Console.WriteLine("Not Prime");
                    return;
                }
            }

            Console.WriteLine("Prime");
//

12.Reverse a Number
//    
      int n = int.Parse(Console.ReadLine());
            int rev = 0;
            while(n > 0){
                int digit = n % 10;
                rev = rev * 10 + digit;
                n = n / 10;
            }
            Console.WriteLine(rev);
//
13.Coupon Numbers
//
            int n = int.Parse(Console.ReadLine());
            int[] visited=new int[n+1];
            int count = 0;
            int distinct = 0;
            Random rand = new Random();
            while (distinct < n)
            {
                int num = rand.Next(1, n + 1);
                count++;
                if (visited[num] == 0)
                {
                    visited[num] = 1;
                    distinct++;
                }
            }
            Console.WriteLine(count);
//
14.Time Stop Program
//
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;
            TimeSpan x = end - start;
            Console.WriteLine(x);
//

15.Temperature Conversion
//
            double n = double.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            if (x == 0)
            {
                double c = (n * 9 / 5) + 32;
                Console.WriteLine(c);
            }
            else if (x == 1) 
            {

                double c = (n - 32) * 5 / 9;
                Console.WriteLine(c);
            }
            else
            {
                Console.WriteLine("Invalid");
            }
//
16.Reverse a triangle
//
 int n = int.Parse(Console.ReadLine());
            for(int i = n; i >= 1; i--)
            {
                for(int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
//

17.Palindrome
//
            int n = int.Parse(Console.ReadLine());
            int x = n;
            int rev = 0;
            while (n > 0)
            {
                int digit = n % 10;
                rev = rev * 10 + digit;
                n = n / 10;

            }
            if (rev == x)
            {
                Console.WriteLine("Palindrome");
            }
            else
            {
                Console.WriteLine("Not a Palindrome");
            }
//
18.Reverse a string
//
    
            string s = Console.ReadLine();
            string res = "";
            for(int i = s.Length-1; i >= 0; i--)
            {
                res = res + s[i];
            }
            Console.WriteLine(res);
//
19.Longest substring without repeating characters
//
            string s1 = Console.ReadLine();
            int maxlen = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                int[] freq = new int[256];
                int len = 0;
                for(int j = i; j < s1.Length; j++)
                {
                    if (freq[s1[j]] == 1)
                    {
                        break;
                    }
                    freq[s1[j]] = 1;
                    len++;
                }
                if (len > maxlen)
                {
                    maxlen = len;
                }
            }
            Console.WriteLine(maxlen);
//
20.Product except self
//
        int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            int[] res = new int[n];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());


            }
            for(int i = 0; i < n; i++)
            {
                int product = 1;
                for(int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        product = arr[j] * product;
                    }
                }
                res[i] = product;
            }

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine(res[i]);
            }
//
21.Finding Duplicates
//
                          int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

          
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());


            }
            for(int i = 0; i <n-1;i++)
            {
              
                for(int j=i+1;j < n; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        Console.WriteLine(arr[i]);
                        break;
                    }
                }
            }
//

22.Reverse Linked List
//
               class Node {
        public int data;
        public Node next;

        public Node(int value)
        {
            data = value;
            next = null;
        }
    }

    class LL {
        public Node head;

        public void INsertATEnd(int value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
                return;
            }
            Node temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = newNode;
        }

        public void ReverseNode()
        {
            Node prev = null;
            Node curr = head;
            Node next = null;
            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            head = prev;
        }

        public void Display()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.data + "->");
                temp = temp.next;
            }
            Console.Write("null");
        }
    }

    class Program {
        public static void Main(string[] args)
        {
            LL n1 = new LL();
            n1.INsertATEnd(10);
            n1.INsertATEnd(20);
            n1.INsertATEnd(30);
            n1.Display();

            n1.ReverseNode();
            n1.Display();
        }
    }
//

*/