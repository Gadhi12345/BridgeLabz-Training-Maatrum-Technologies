namespace StackandQueue_Queue_
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

    class QueueLL
    {
        Node front, rear;

        //  Enqueue (Insert at rear)
        //  Enqueue (Insert at rear)
        public void Enqueue(int value)
        {
            Node newNode = new Node(value);

            if (rear == null)
            {
                front = rear = newNode; // first node
                return;
            }

            rear.next = newNode; // link last node to new node
            rear = newNode;      // update rear
        }

        //  Dequeue (Delete from front)
        public void Dequeue()
        {
            if (front == null)
            {
                Console.WriteLine("Queue Underflow");
                return;
            }

            Console.WriteLine("Deleted: " + front.data);
            front = front.next; // move front forward

            // If queue becomes empty
            if (front == null)
                rear = null;
        }

        //  Peek (Front element)
        public void Peek()
        {
            if (front == null)
            {
                Console.WriteLine("Queue Empty");
                return;
            }

            Console.WriteLine("Front: " + front.data);
        }

        //  Display queue
        public void Display()
        {
            Node temp = front;

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
            QueueLL q = new QueueLL();

            //  Enqueue operations
            q.Enqueue(10);
            q.Enqueue(20);
            q.Enqueue(30);

            Console.WriteLine("Queue:");
            q.Display();

            //  Dequeue
            q.Dequeue();

            //  Peek
            q.Peek();

            q.Display();
        }
    }
}
