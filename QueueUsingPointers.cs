using System;

class QueueUsingPointers
{
    class Node
    {
        public int data;
        public Node next;
        public Node(int d)
        {
            data = d;
            next = null;
        }
    }

    class Queue
    {
        private Node front;
        private Node rear;

        public Queue()
        {
            front = rear = null;
        }

        public void Enqueue(int value)
        {
            Node newNode = new Node(value);
            if (IsEmpty())
            {
                front = rear = newNode;
            }
            else
            {
                rear.next = newNode;
                rear = newNode;
            }
            Console.WriteLine($"{value}가 큐에 삽입되었습니다.");
        }

        public void Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("큐가 비어있습니다.");
                return;
            }
            int value = front.data;
            front = front.next;
            if (front == null)
            {
                rear = null;
            }
            Console.WriteLine($"{value}가 큐에서 제거되었습니다.");
        }

        public void Display()
        {
            if (IsEmpty())
            {
                Console.WriteLine("큐가 비어있습니다.");
                return;
            }
            Console.Write("큐 내용: ");
            Node temp = front;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }

        public bool IsEmpty()
        {
            return front == null;
        }
    }

    static void Main(string[] args)
    {
        Queue queue = new Queue();

        while (true)
        {
            Console.WriteLine("\n1. Enqueue");
            Console.WriteLine("2. Dequeue");
            Console.WriteLine("3. Display");
            Console.WriteLine("4. Exit");
            Console.Write("선택: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("삽입할 값: ");
                    int value = int.Parse(Console.ReadLine());
                    queue.Enqueue(value);
                    break;
                case 2:
                    queue.Dequeue();
                    break;
                case 3:
                    queue.Display();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    break;
            }
        }
    }
}