class Program
{
    static async Task Main()
    {
        Console.WriteLine($"The main thread is Starting, thread ID: {Thread.CurrentThread.ManagedThreadId}");

        int number1 = 25;
        int number2 = 35;

        // Запускаем асинхронную задачу для вычисления факториала
        Task<long> taskFactorialAsync = MathOperations.FactorialAsync(number1);

        // Запускаем синхронную задачу для вычисления числа Фибоначчи
        Task<long> taskFibonacci = new Task<long>(() => MathOperations.Fibonacci(number2));

        // Запуск и ожидание завершения выполнения синхронной задачи
        taskFibonacci.Start();
        long fibonacciResult = await taskFibonacci;

        // Ожидаем завершения асинхронной задачи
        long factorialResultAsync = await taskFactorialAsync;

        Console.WriteLine($"***ASYNC*** Factorial of {number1}: {factorialResultAsync}");
        Console.WriteLine($"Fibonacci of {number2}: {fibonacciResult}");

        Console.WriteLine($"The main thread is Finished, thread ID: {Thread.CurrentThread.ManagedThreadId}");
    }
}

public class MathOperations
{
    // Синхронный метод для вычисления числа Фибоначчи
    public static long Fibonacci(int n)
    {
        Console.WriteLine($"Fibonacci calculation is Starting, thread ID: {Thread.CurrentThread.ManagedThreadId}");
        if (n < 0) throw new ArgumentException("Fibonacci sequence is not defined for negative numbers.");
        if (n == 0) return 0;
        if (n == 1) return 1;

        long a = 0;
        long b = 1;
        long result = 0;

        for (int i = 2; i <= n; i++)
        {
            result = a + b;
            a = b;
            b = result;
            Thread.Sleep(50); //Замедлитель
        }
        Console.WriteLine($"Fibonacci calculation is Finished, thread ID: {Thread.CurrentThread.ManagedThreadId}");
        return result;
    }

    // Асинхронный метод для вычисления факториала
    public static async Task<long> FactorialAsync(int n)
    {
        Console.WriteLine($"***ASYNC*** Factorial calculation is Starting, thread ID: {Thread.CurrentThread.ManagedThreadId}");
        if (n < 0) throw new ArgumentException("Factorial is not defined for negative numbers.");
        if (n == 0 || n == 1) return 1;

        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
            Console.WriteLine($"***ASYNC*** Factorial is calculation, thread ID: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(100); // Замедлитель
        }
        Console.WriteLine($"***ASYNC*** Factorial calculation is Finished, thread ID: {Thread.CurrentThread.ManagedThreadId}");
        return result;
    }
}