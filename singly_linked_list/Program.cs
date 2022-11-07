using System;
using System.Diagnostics;
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
            if (START != null || (rollNo <= START.rollNumber))
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
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (rollNo != current.rollNumber))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }
        public void Traverse()
        {
            if (listEmpty())
            {
                Console.WriteLine("\n The records in the list are: ");
            }
            else
            {
                Console.WriteLine("\n The records in the list are:");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.rollNumber + "" + currentNode.name + "\n");
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n MENU");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all the records in the list");
                    Console.WriteLine("4. Search for a second in the list");
                    Console.WriteLine("5. Exit");
                    Console.Write("\n Enter your choice (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\n List is empty");
                                    break;
                                }
                                Console.WriteLine("Enter the roll number of" + "the student whose record is to be deleted: ");
                                int rollNo =  Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("\n Record not found.");
                                else
                                    Console.WriteLine("Record with roll number" + rollNo + "Deleted");
                                
                            }
                            break;
                        case '3':
                            {
                                obj.Traverse();
                            }
                            break;
                        case '4':
                            {
                                if(obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\n List is empty");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\n Enter the roll number of the " + "Student whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) ==  false)
                                    Console.WriteLine("\n Record not found.");
                                else
                                {
                                    Console.WriteLine("\nRecord not found");
                                    Console.WriteLine("\nRoll number: " + current.rollNumber);
                                    Console.WriteLine("\nName: " + current.name);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\n Invalid option");
                                break;

                            }
                            break;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("\n Check for the value enterd");
                }
            }
        }
    }
}