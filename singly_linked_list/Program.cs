using System;
using System.Net;
using System.Runtime.InteropServices;

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
            // if the node to be inserted is the first node
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

            Node previous, current;
            previous = START;
            current = START;

            while ((current != null)&&(rollNo >= current.rollNumber))
            {
                if (rollNo == current.rollNumber)
                {
                    Console.WriteLine();
                    return;
                }
                previous.next = current;
                previous.next = newnode;

            }
            newnode.next = current;
            previous.next = newnode;


        }
        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current)== false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
    }

}