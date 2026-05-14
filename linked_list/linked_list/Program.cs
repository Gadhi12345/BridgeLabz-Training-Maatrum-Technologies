using System.Security.Cryptography.X509Certificates;

namespace linked_list
{
    class program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            for(int i = 0; i < n; i++)
            {
                int min = i;
                for(int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min=j;

                    }
                }
                int temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;

            }
            foreach(int num in arr)
            {
                Console.WriteLine(num);
            }
        }
    }
}

/*
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
class LL
{
    public Node head;

    public void INSERTATEND(int value)
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

    public void MIDDLE()
    {
        if (head == null)
        {
            Console.WriteLine("List is Empty");
        }
        Node slow = head;
        Node fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        Console.WriteLine(slow.data);
    }

    public void Display()
    {
        Node temp = head;
        while (temp != null)
        {
            Console.Write(temp.data + "->");
            temp = temp.next;
        }
        Console.WriteLine("null");
    }
}

class Program
{
    static void Main(string[] args)
    {
        LL n1 = new LL();
        n1.INSERTATEND(10);
        n1.INSERTATEND(20);
        n1.INSERTATEND(30);
        n1.INSERTATEND(40);
        n1.INSERTATEND(50);
        n1.Display();
        n1.MIDDLE();

    }


}


class DNode
    {
        public int data;
        public DNode prev;
        public DNode next;

        public DNode(int value)
        {
            data = value;
            prev = null;
            next = null;
        }
    }

    class LL
    {
        public DNode head;

        public void InsertAtBegging(int value)
        {
            DNode newNode = new DNode(value);

            if (head == null)
            {
                head = newNode;
            }
            newNode.next = head;
            head.prev = newNode;
        }
        public void InsertAtEnd(int value)
        {
            DNode newNode = new DNode(value);
            if (head == null)
            {
                head = newNode;
            }
            DNode temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = newNode;
            newNode.prev = temp;
        }
        public void DeleteAtFirst()
        {

        }
    }

//
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

    class CircularLinkedList
    {
        public Node head;

        //  Insert at End
        public void InsertAtEnd(int value)
        {
            Node newNode = new Node(value);

            // empty list
            if (head == null)
            {
                head = newNode;
                newNode.next = head;
                return;
            }

            Node temp = head;

            // go to last node
            while (temp.next != head)
            {
                temp = temp.next;
            }

            temp.next = newNode;
            newNode.next = head;
        }

        
        public void Display()
        {
            if (head == null) return;

            Node temp = head;

            do
            {
                Console.Write(temp.data + " -> ");
                temp = temp.next;
            }
            while (temp != head);

            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            CircularLinkedList list = new CircularLinkedList();

            list.InsertAtEnd(10);
            list.InsertAtEnd(20);
            list.InsertAtEnd(30);

            list.Display();
        }
    }

//

//
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

    class CircularLinkedList
    {
        public Node head;

        //  Insert at End
        public void InsertAtEnd(int value)
        {
            Node newNode = new Node(value);

            // empty list
            if (head == null)
            {
                head = newNode;
                newNode.next = head;
                return;
            }

            Node temp = head;

            // go to last node
            while (temp.next != head)
            {
                temp = temp.next;
            }

            temp.next = newNode;
            newNode.next = head;
        }

        
        public void Display()
        {
            if (head == null) return;

            Node temp = head;

            do
            {
                Console.Write(temp.data + " -> ");
                temp = temp.next;
            }
            while (temp != head);

            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            CircularLinkedList list = new CircularLinkedList();

            list.InsertAtEnd(10);
            list.InsertAtEnd(20);
            list.InsertAtEnd(30);

            list.Display();
        }
    }
//
stack Operations
//
                  class stack
    {
        int[] arr;
        int size;
        int top;

        public stack(int size)
        {
            this.size = size;
            arr = new int[size];
            top = -1;
        }

        public void push(int value)
        {
            if (top == size - 1)
            {
                Console.WriteLine("stack overflow");
            }
            top++;
            arr[top] = value;
        }

        public void pop(int value)
        {
            if (top == -1)
            {
                Console.WriteLine("Underflow");
            }

            Console.WriteLine(arr[top]);
            top--;

        }

        public void peek()
        {
            if (top == -1)
            {
                Console.WriteLine("stack is empty");
            }
            Console.WriteLine(arr[top]);
        }
       


    }

    class Program
    {
        static void Main(string[] args)
        {

            int choice = int.Parse(Console.ReadLine());
            stack s = new stack(size);
            switch (choice)
            {
                case 1:
                    int val = int.Parse(Console.ReadLine());
                    s.push(val);
            }
        }
    }
//
*/