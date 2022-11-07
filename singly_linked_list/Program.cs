using System;

namespace single_linked_list
{
    //each node consist of the information part adn link to the next node
    class Node
    {
        public int rollNumber;
        public string name;
        public Node next;
    }

    class List
    {
        Node START;
        public List()
        {
            START = null;

        }
        public void addNote() // add a node in the list
        {
            int rollNo;
            string nm;
            Console.Write("\n Enter the roll number of the student: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Enter the roll name of the student: ");
            Node newnode = new Node();
            newnode.rollNumber = rollNo;
            newnode.name = nm;
            if(START != null || (rollNo <= START.rollNumber))
            {
                if ((START != null)&&(rollNo == START.rollNumber))
                {
                    Console.WriteLine();
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }


        }
    }

}