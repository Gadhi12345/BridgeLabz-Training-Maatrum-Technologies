namespace Review_Question_DSA_
{
    class Node
    {
        public int id;
        public string name;
        public double salary;
        public Node next;

        public Node(int ID, string n, double S)
        {
            id = ID;
            name = n;
            salary = S;
            next = null;

        }

    }

    class LinkedListForEmplyee
    {
        public Node head;

        public void InsertDataAtEnd(int ID, string n, double S)
        {
            Node newnode = new Node(ID, n, S);

            if (head == null)
            {
                head = newnode;
                return;
            }

            Node temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = newnode;
        }

        public void DeleteAtPos(int pos)
        {
            if (head == null)
            {
                Console.WriteLine("list is Empty");
            }
            Node temp = head;
            for(int i = 0; i < pos - 1; i++)
            {
                if (temp == null)
                {
                    Console.WriteLine("Invaliid");
                }
                temp = temp.next;
            }

            if(temp== null)
            {
                Console.WriteLine("Invalid");
            }
            temp.next = null;
        } 

        public void DeleteAtBegining()
        {
            if (head == null)
            {
                Console.WriteLine("list is empty");
            }
            head = head.next;

        }
        public void searchtheEmployee(int ID)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.id == ID)
                {
                    Console.WriteLine($"Found: {temp.name}");
                    return;
                }
                temp = temp.next;
            }
            Console.WriteLine("Not Found");


        }
        public void Display()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine($"ID : {temp.id}  Name: {temp.name}   Salary:{temp.salary}");
                temp = temp.next;
            }
            

        }
    }



    class program
    {
        static void Main()
        {
            LinkedListForEmplyee l = new LinkedListForEmplyee();
            
            
            l.InsertDataAtEnd(1, "Kural", 50000);
            l.InsertDataAtEnd(2, "Arasan", 70000);
            l.InsertDataAtEnd(3, "King", 55000);
            l.Display();
            Console.WriteLine("After Deleting");
            l.DeleteAtPos(2);
           
            l.Display();
            l.searchtheEmployee(2);


        }
    }

    
}
