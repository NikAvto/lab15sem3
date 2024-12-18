using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Parallel.For(0, 10, i =>
        {
            int randomNumber = SingleRandomizer.Instance.Next(1, 100);
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}: Случайное число: {randomNumber}");
        });

        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine();
    }
}
