using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace StackandQueue
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

    class StackLL
    {
        Node top;

        //  Push (Insert at beginning)
        public void Push(int value)
        {
            Node newNode = new Node(value);

            newNode.next = top; // link new node to previous top
            top = newNode;      // update top
        }

        //  Pop (Delete from beginning)
        public void Pop()
        {
            if (top == null)
            {
                Console.WriteLine("Stack Underflow");
                return;
            }

            Console.WriteLine("Deleted: " + top.data);
            top = top.next; // move top forward
        }

        //  Peek (Top element)
        public void Peek()
        {
            if (top == null)
            {
                Console.WriteLine("Stack Empty");
                return;
            }

            Console.WriteLine("Top: " + top.data);
        }

        //  Display stack
        public void Display()
        {
            Node temp = top;

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
            StackLL st = new StackLL();

            //  Push operations
            st.Push(10);
            st.Push(20);
            st.Push(30);

            Console.WriteLine("Stack:");
            st.Display();

            //  Pop operation
            st.Pop();

            //  Peek
            st.Peek();

            st.Display();
        }
    }
}
