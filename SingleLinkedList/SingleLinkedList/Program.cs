namespace SingleLinkedList
{
    using System;

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

    class SLL
    {
        public Node head;

        // Insert at beginning
        public void InsertBeg(int val)
        {
            Node n = new Node(val);
            n.next = head;
            head = n;
        }

        // Insert at end
        public void InsertEnd(int val)
        {
            Node n = new Node(val);
            if (head == null) { head = n; return; }

            Node temp = head;
            while (temp.next != null)
                temp = temp.next;

            temp.next = n;
        }

        // Delete at beginning
        public void DeleteBeg()
        {
            if (head == null) return;
            head = head.next;
        }

        // Delete at end
        public void DeleteEnd()
        {
            if (head == null) return;
            if (head.next == null) { head = null; return; }

            Node temp = head;
            while (temp.next.next != null)
                temp = temp.next;

            temp.next = null;
        }

        // Insert at position
        public void InsertPos(int val, int pos)
        {
            Node n = new Node(val);

            if (pos == 1)
            {
                n.next = head;
                head = n;
                return;
            }

            Node temp = head;
            for (int i = 1; i < pos - 1 && temp != null; i++)
                temp = temp.next;

            if (temp == null) return;

            n.next = temp.next;
            temp.next = n;
        }

        // Delete at position
        public void DeletePos(int pos)
        {
            if (head == null) return;

            if (pos == 1)
            {
                head = head.next;
                return;
            }

            Node temp = head;
            for (int i = 1; i < pos - 1 && temp.next != null; i++)
                temp = temp.next;

            if (temp.next == null) return;

            temp.next = temp.next.next;
        }

        // Find middle
        public void Middle()
        {
            Node slow = head, fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            Console.WriteLine("Middle: " + slow.data);
        }

        // Reverse
        public void Reverse()
        {
            Node prev = null, curr = head, next = null;

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
            SLL list = new SLL();

            // Insert operations
            list.InsertBeg(10);
            list.InsertEnd(20);
            list.InsertEnd(30);
            list.InsertPos(15, 2);

            list.Display();

            // Delete operations
            list.DeleteBeg();
            list.DeleteEnd();
            list.DeletePos(1);

            list.Display();

            // Other operations
            list.InsertEnd(40);
            list.InsertEnd(50);

            list.Middle();   // find middle
            list.Reverse();  // reverse

            list.Display();
        }
    }
}
