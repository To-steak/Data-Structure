using System;

class QueueUsingGlobalVariables
{
    private static int[] queue;
    private static int front = -1;
    private static int rear = -1;
    private static int size;

    static void Main(string[] args)
    {
        Console.Write("큐의 크기를 입력하세요: ");
        size = int.Parse(Console.ReadLine());
        queue = new int[size];

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
                    Enqueue(value);
                    break;
                case 2:
                    Dequeue();
                    break;
                case 3:
                    Display();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    break;
            }
        }
    }

    static void Enqueue(int value)
    {
        if (IsFull())
        {
            Console.WriteLine("큐가 가득 찼습니다.");
            return;
        }
        if (IsEmpty())
            front = 0;
        rear++;
        queue[rear] = value;
        Console.WriteLine($"{value}가 큐에 삽입되었습니다.");
    }

    static void Dequeue()
    {
        if (IsEmpty())
        {
            Console.WriteLine("큐가 비어있습니다.");
            return;
        }
        int value = queue[front];
        if (front == rear)
        {
            front = rear = -1;
        }
        else
        {
            front++;
        }
        Console.WriteLine($"{value}가 큐에서 제거되었습니다.");
    }

    static void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("큐가 비어있습니다.");
            return;
        }
        Console.Write("큐 내용: ");
        for (int i = front; i <= rear; i++)
        {
            Console.Write(queue[i] + " ");
        }
        Console.WriteLine();
    }

    static bool IsEmpty()
    {
        return front == -1 && rear == -1;
    }

    static bool IsFull()
    {
        return rear == size - 1;
    }
}