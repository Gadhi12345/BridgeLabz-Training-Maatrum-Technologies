using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.XPath;

namespace DLL
{
    using System;

    class Node
    {
        public int data;
        public Node next;
        public Node prev;

        public Node(int value)
        {
            data = value;
            next = null;
            prev = null;
        }
    }

    class DLL
    {
        public Node head;

        //  Insert at Beginning
        public void InsertBeg(int value)
        {
            Node newNode = new Node(value);

            if (head != null)
            {
                newNode.next = head;   // new node points to old head
                head.prev = newNode;   // old head points back to new node
            }

            head = newNode; // update head
        }

        //  Insert at End
        public void InsertEnd(int value)
        {
            Node newNode = new Node(value);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node temp = head;

            while (temp.next != null)
                temp = temp.next;

            temp.next = newNode;     // last node points to new node
            newNode.prev = temp;     // new node points back
        }

        //  Delete at Beginning
        public void DeleteBeg()
        {
            if (head == null)
            {
                Console.WriteLine("Empty");
                return;
            }

            if (head.next == null)
            {
                head = null;
                return;
            }

            head = head.next;   // move head forward
            head.prev = null;   // remove backward link
        }

        //  Delete at End
        public void DeleteEnd()
        {
            if (head == null)
            {
                Console.WriteLine("Empty");
                return;
            }

            if (head.next == null)
            {
                head = null;
                return;
            }

            Node temp = head;

            while (temp.next != null)
                temp = temp.next;

            temp.prev.next = null; // remove last node
        }

        //  Insert at Position (1-based)
        public void InsertAtPos(int value, int pos)
        {
            Node newNode = new Node(value);

            if (pos == 1)
            {
                InsertBeg(value);
                return;
            }

            Node temp = head;

            for (int i = 1; i < pos - 1 && temp != null; i++)
                temp = temp.next;

            if (temp == null)
            {
                Console.WriteLine("Invalid Position");
                return;
            }

            newNode.next = temp.next;

            if (temp.next != null)
                temp.next.prev = newNode;

            temp.next = newNode;
            newNode.prev = temp;
        }

        //  Delete at Position
        public void DeleteAtPos(int pos)
        {
            if (head == null)
            {
                Console.WriteLine("Empty");
                return;
            }

            if (pos == 1)
            {
                DeleteBeg();
                return;
            }

            Node temp = head;

            for (int i = 1; i < pos && temp != null; i++)
                temp = temp.next;

            if (temp == null)
            {
                Console.WriteLine("Invalid Position");
                return;
            }

            if (temp.next != null)
                temp.next.prev = temp.prev;

            if (temp.prev != null)
                temp.prev.next = temp.next;
        }

        //  Display Forward
        public void Display()
        {
            Node temp = head;

            while (temp != null)
            {
                Console.Write(temp.data + " <-> ");
                temp = temp.next;
            }

            Console.WriteLine("null");
        }

        //  Display Reverse
        public void DisplayReverse()
        {
            if (head == null)
                return;

            Node temp = head;

            // Go to last node
            while (temp.next != null)
                temp = temp.next;

            // Traverse backward
            while (temp != null)
            {
                Console.Write(temp.data + " <-> ");
                temp = temp.prev;
            }

            Console.WriteLine("null");
        }
    }

    class Program
    {
        static void Main()
        {
            DLL list = new DLL();

            //  Insert operations
            list.InsertBeg(10);
            list.InsertEnd(20);
            list.InsertEnd(30);
            list.InsertAtPos(15, 2); // insert 15 at position 2

            Console.WriteLine("After Insertions:");
            list.Display();

            //  Delete operations
            list.DeleteBeg();       // delete first node
            list.DeleteEnd();       // delete last node
            list.DeleteAtPos(2);    // delete at position

            Console.WriteLine("After Deletions:");
            list.Display();

            
            list.InsertEnd(40);
            list.InsertEnd(50);

            Console.WriteLine("Forward Display:");
            list.Display();

            Console.WriteLine("Reverse Display:");
            list.DisplayReverse();
        }
    }

}
