using System;
using System.Threading;

class MutexExample
{
    private static Mutex mutex = new Mutex();
    private const int numThreads = 3;
    private const int numIterations = 5;

    static void Main()
    {
        for (int i = 0; i < numThreads; i++)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(WorkerThread));
            thread.Start(i);
        }

        Console.ReadLine(); // 메인 쓰레드가 종료되지 않도록 대기
    }

    static void WorkerThread(object threadId)
    {
        for (int i = 0; i < numIterations; i++)
        {
            UseResource((int)threadId);
        }
    }

    static void UseResource(int threadId)
    {
        Console.WriteLine($"Thread {threadId} waiting for the mutex.");
        mutex.WaitOne();  // Mutex 획득 시도

        try
        {
            Console.WriteLine($"Thread {threadId} has entered the critical section.");
            Thread.Sleep(1000);  // 리소스 사용 시뮬레이션
            Console.WriteLine($"Thread {threadId} is releasing the mutex.");
        }
        finally
        {
            mutex.ReleaseMutex();  // Mutex 해제
        }
    }
}