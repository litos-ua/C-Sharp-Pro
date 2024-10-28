
class BarberShop
{
    private static Semaphore customerSemaphore = new(0, int.MaxValue); 
    private static Semaphore barberSemaphore = new(0, 1); 
    private static Semaphore waitingRoomSemaphore = new(3, 3); 
    private static Queue<int> customerQueue = new(); // Черга клієнтів у залі очікування
    private static readonly object locker = new(); 
    private static bool lastCustomer = false; 
    private static bool isSleeping = true; 

    public static void Main()
    {
        Console.WriteLine("The barber shop is open!");

        new Thread(Barber).Start();

        // Приходять перші п'ять клієнтів
        for (int i = 1; i <= 5; i++)
        {
            int customerId = i;
            Thread.Sleep(new Random().Next(500, 1000));
            new Thread(() => Customer(customerId)).Start();
        }

        Thread.Sleep(7000); // Пауза після перших 5 клієнтів

        // Приходять клієнти 6-10
        for (int i = 6; i <= 10; i++)
        {
            int customerId = i;
            Thread.Sleep(new Random().Next(500, 1000));
            new Thread(() => Customer(customerId)).Start();
        }
        lastCustomer = true;
    }

    static void Barber()
    {
        while (true)
        {
            lock (locker)
            {
                // Якщо перукар вже не спить, то за відсутності клієнтів він засинає
                if (customerQueue.Count == 0 && isSleeping == false)
                {
                    Console.WriteLine("The barber falls asleep.");
                    isSleeping = true;
                }
            }

            customerSemaphore.WaitOne(); 

            int customerToServe;
            lock (locker)
            {
                if (customerQueue.Count == 0) continue;

                // Якщо перукар спить, його будять
                if (isSleeping)
                {
                    Console.WriteLine("The barber wakes up.");
                    isSleeping = false;
                }

                customerToServe = customerQueue.Dequeue();
                Console.WriteLine($"The barber starts serving client {customerToServe}.");
            }

            barberSemaphore.Release(); // Перукар сідає у крісло для стрижки клієнта

            lock (locker)
            {
                Console.WriteLine($"The barber cuts the hair of client {customerToServe}.");
            }

            Thread.Sleep(2000); // Імітація процесу стрижки

            // Перевіряємо після стрижки, чи є клієнти; якщо ні і вже створить останній - зачиняємо перукарню
            lock (locker)
            {
                if (customerQueue.Count == 0 && lastCustomer)
                {
                    Console.WriteLine("The barber shop closes.");
                    break;
                }
            }
        }
    }

    static void Customer(int customerId)
    {
        if (waitingRoomSemaphore.WaitOne(0)) // Перевіряємо наявність місць у залі очікування
        {
            lock (locker)
            {
                customerQueue.Enqueue(customerId);
                Console.WriteLine($"Client {customerId} is waiting in the waiting room. Waiting clients: {customerQueue.Count}");
            }

            customerSemaphore.Release(); // Повідомляємо перукаря про прихід нового клієнта
            barberSemaphore.WaitOne(); // Клієнт чекає дозволу на стрижку

            lock (locker)
            {
                Console.WriteLine($"Client {customerId} sits in the barber's chair.");
            }

            waitingRoomSemaphore.Release(); // Місце у залі очікування звільняється
        }
        else
        {
            lock (locker)
            {
                Console.WriteLine($"Client {customerId} leaves because there are no vacancies.");
            }
        }
    }
}






