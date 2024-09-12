using System;
using System.Threading;

class SemaphoreExample
{
    // 최대 3개의 쓰레드가 동시에 리소스에 접근할 수 있도록 세마포어 설정
    private static SemaphoreSlim semaphore = new SemaphoreSlim(3);
    private const int numThreads = 5;

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
        Console.WriteLine($"Thread {threadId} is waiting to enter the semaphore.");
        semaphore.Wait();

        try
        {
            Console.WriteLine($"Thread {threadId} has entered the semaphore.");
            // 리소스 사용 시뮬레이션
            Thread.Sleep(new Random().Next(1000, 3000));
        }
        finally
        {
            Console.WriteLine($"Thread {threadId} is releasing the semaphore.");
            semaphore.Release();
        }
    }
}