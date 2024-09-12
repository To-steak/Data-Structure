using System;

// 배열을 사용한 고정 크기 스택
public class ArrayStack
{
    private int[] arr;
    private int top;
    private int capacity;

    public ArrayStack(int size)
    {
        arr = new int[size];
        capacity = size;
        top = -1;
    }

    public void Push(int x)
    {
        if (IsFull())
        {
            Console.WriteLine("스택이 가득 찼습니다. 더 이상 원소를 추가할 수 없습니다.");
            return;
        }
        Console.WriteLine($"원소 {x} 삽입");
        arr[++top] = x;
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("스택이 비어있습니다.");
            return -1;
        }
        return arr[top--];
    }

    public int Peek()
    {
        if (!IsEmpty())
        {
            return arr[top];
        }
        else
        {
            Console.WriteLine("스택이 비어있습니다.");
            return -1;
        }
    }

    public bool IsEmpty()
    {
        return top == -1;
    }

    public bool IsFull()
    {
        return top == capacity - 1;
    }

    public void PrintStack()
    {
        for (int i = top; i >= 0; i--)
        {
            Console.WriteLine($"| {arr[i]} |");
        }
        Console.WriteLine("-----");
    }
}

// 연결 리스트를 사용한 동적 크기 스택
public class LinkedListStack
{
    private class Node
    {
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
            next = null;
        }
    }

    private Node top;

    public LinkedListStack()
    {
        this.top = null;
    }

    public void Push(int x)
    {
        Node newNode = new Node(x);
        newNode.next = top;
        top = newNode;
        Console.WriteLine($"원소 {x} 삽입");
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("스택이 비어있습니다.");
            return -1;
        }
        int popped = top.data;
        top = top.next;
        return popped;
    }

    public int Peek()
    {
        if (!IsEmpty())
        {
            return top.data;
        }
        else
        {
            Console.WriteLine("스택이 비어있습니다.");
            return -1;
        }
    }

    public bool IsEmpty()
    {
        return top == null;
    }

    public void PrintStack()
    {
        Node current = top;
        while (current != null)
        {
            Console.WriteLine($"| {current.data} |");
            current = current.next;
        }
        Console.WriteLine("-----");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("배열 기반 스택:");
        ArrayStack arrayStack = new ArrayStack(5);

        arrayStack.Push(1);
        arrayStack.Push(2);
        arrayStack.Push(3);
        arrayStack.PrintStack();

        Console.WriteLine($"Pop: {arrayStack.Pop()}");
        Console.WriteLine($"Peek: {arrayStack.Peek()}");
        arrayStack.PrintStack();

        Console.WriteLine("\n연결 리스트 기반 스택:");
        LinkedListStack linkedListStack = new LinkedListStack();

        linkedListStack.Push(1);
        linkedListStack.Push(2);
        linkedListStack.Push(3);
        linkedListStack.PrintStack();

        Console.WriteLine($"Pop: {linkedListStack.Pop()}");
        Console.WriteLine($"Peek: {linkedListStack.Peek()}");
        linkedListStack.PrintStack();
    }
}