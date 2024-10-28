﻿
///* Работает нормально*/
//class BarberShop
//{
//    private static readonly object locker = new();
//    private static int waiting = 0; // Количество ожидающих клиентов
//    private static int chairs = 3; // Количество кресел в приемной
//    private static bool barberSleeping = true; // Булево значение, спит ли парикмахер
//    private static int haircutedClientCount = 0; // Счетчик обслуженных клиентов

//    public static void Main()
//    {
//        Console.WriteLine("The barber shop is open for the day!");

//        Thread.Sleep(5000); // Ожидание первого клиента
//        Console.WriteLine("The barber falls asleep.");

//        new Thread(Barber).Start();

//        // Приход первых 5 клиентов
//        for (int i = 1; i <= 5; i++)
//        {
//            Thread.Sleep(new Random().Next(500, 1000));
//            new Thread(Customer).Start(i);
//        }

//        Thread.Sleep(5000); // Временной разрыв после первых 5-ти клиентов
//        Console.WriteLine("The barber falls asleep again.");

//        // Приход остальных 5 клиентов
//        for (int i = 6; i <= 10; i++)
//        {
//            Thread.Sleep(new Random().Next(1000, 3000));
//            new Thread(Customer).Start(i);
//        }
//    }

//    static void Barber()
//    {
//        while (true)
//        {
//            lock (locker)
//            {
//                // Проверка: если клиентов нет и обслужено кратно 5, парикмахер засыпает
//                if (waiting == 0 && barberSleeping == false && haircutedClientCount % 5 == 0)
//                {
//                    barberSleeping = true;
//                    Console.WriteLine("The barber falls asleep.");
//                }
//            }

//            lock (locker)
//            {
//                if (waiting > 0)
//                {
//                    // Если парикмахер спит, клиент его будит
//                    if (barberSleeping)
//                    {
//                        barberSleeping = false;
//                        Console.WriteLine("The barber wakes up to serve a customer.");
//                    }

//                    waiting--; // Уменьшение числа ожидающих клиентов
//                    Console.WriteLine("The barber prepares the chair. Waiting clients: " + waiting);
//                    Console.WriteLine("The barber cuts the client's hair.");
//                    Thread.Sleep(2000); // Имитация процесса стрижки 

//                    haircutedClientCount++;
//                }
//            }

//            // Завершение рабочего дня после 10 клиентов
//            if (haircutedClientCount == 10)
//            {
//                Console.WriteLine("The barber shop closes for the day.");
//                break;
//            }
//        }
//    }

//    static void Customer(object num)
//    {
//        int customerId = (int)num;

//        lock (locker)
//        {
//            // Проверка на свободные места
//            if (waiting < chairs)
//            {
//                waiting++;
//                Console.WriteLine("Client " + customerId + " is waiting in line. There are " + waiting + " clients waiting.");
//            }
//            else
//            {
//                Console.WriteLine("Client " + customerId + " leaves because there are no vacancies.");
//            }
//        }
//    }
//}




///* Работает с добавленной очередью */
//class BarberShop
//{
//    private static readonly object locker = new();
//    private static int waiting = 0; // Количество ожидающих клиентов
//    private static int chairs = 3; // Количество кресел в приемной
//    private static bool barberSleeping = true; // Булево значение, спит ли парикмахер
//    private static int haircutedClientCount = 0; // Счетчик обслуженных клиентов

//    private static Queue<int> customerQueue = new(); // Очередь для клиентов

//    public static void Main()
//    {
//        Console.WriteLine("The barber shop is open for the day!");

//        Thread.Sleep(5000); // Ожидание первого клиента
//        Console.WriteLine("The barber falls asleep.");

//        new Thread(Barber).Start();

//        // Приход первых 5 клиентов
//        for (int i = 1; i <= 5; i++)
//        {
//            Thread.Sleep(new Random().Next(500, 1000));
//            new Thread(Customer).Start(i);
//        }

//        Thread.Sleep(5000); // Временной разрыв после первых 5-ти клиентов
//        Console.WriteLine("The barber falls asleep again.");

//        // Приход остальных 5 клиентов
//        for (int i = 6; i <= 10; i++)
//        {
//            Thread.Sleep(new Random().Next(1000, 3000));
//            new Thread(Customer).Start(i);
//        }
//    }

//    static void Barber()
//    {
//        while (true)
//        {
//            int currentCustomer = -1;

//            lock (locker)
//            {
//                // Если нет клиентов и обслужено 5 или 10, парикмахер засыпает
//                if (waiting == 0 && !barberSleeping && haircutedClientCount == 5 || haircutedClientCount == 10)
//                {
//                    barberSleeping = true;
//                    Console.WriteLine("The barber falls asleep.");
//                }

//                if (waiting > 0)
//                {
//                    // Если парикмахер спит, клиент его будит
//                    if (barberSleeping)
//                    {
//                        barberSleeping = false;
//                        Console.WriteLine("The barber wakes up to serve a customer.");
//                    }

//                    currentCustomer = customerQueue.Dequeue();
//                    waiting--;

//                    Console.WriteLine($"The barber prepares the chair for client {currentCustomer}. Waiting clients: {waiting}");
//                    Console.WriteLine($"The barber cuts the hair of client {currentCustomer}.");
//                    Thread.Sleep(2000); // Стрижка 

//                    haircutedClientCount++;
//                }
//            }

//            // 10 клиентов в день, потом парикмахерская закрывается
//            if (haircutedClientCount == 10)
//            {
//                Console.WriteLine("The barber shop closes for the day.");
//                break;
//            }
//        }
//    }

//    static void Customer(object num)
//    {
//        int customerId = (int)num;

//        lock (locker)
//        {
//            // Если есть места для ожидания, заходит иначе уходит 
//            if (waiting < chairs)
//            {
//                waiting++;
//                customerQueue.Enqueue(customerId); 
//                Console.WriteLine($"Client {customerId} is waiting in line. There are {waiting} clients waiting.");
//            }
//            else
//            {
//                Console.WriteLine($"Client {customerId} leaves because there are no vacancies.");
//            }
//        }
//    }
//}

class BarberShop
{
    private static readonly object locker = new();
    private static int waiting = 0; // Количество ожидающих клиентов
    private static int chairs = 3; // Количество кресел в приемной
    private static bool barberSleeping = true; // Булево значение, спит ли парикмахер
    private static int haircutedClientCount = 0; // Счетчик обслуженных клиентов

    private static Queue<int> customerQueue = new(); // Очередь для клиентов

    public static void Main()
    {
        Console.WriteLine("The barber shop is open for the day!");

        Thread.Sleep(5000); // Ожидание первого клиента
        Console.WriteLine("The barber falls asleep.");

        new Thread(Barber).Start();

        // Приход первых 5 клиентов
        for (int i = 1; i <= 5; i++)
        {
            Thread.Sleep(new Random().Next(500, 1000));
            new Thread(Customer).Start(i);
        }

        Thread.Sleep(5000); // Временной разрыв после первых 5 клиентов
        Console.WriteLine("The barber falls asleep again.");

        // Приход клиентов последних 5 клиентов
        for (int i = 6; i <= 10; i++)
        {
            Thread.Sleep(new Random().Next(1000, 3000));
            new Thread(Customer).Start(i);
        }
    }

    static void Barber()
    {
        while (true)
        {
            int currentCustomer = -1;

            lock (locker)
            {
                // При отсутствии клиентов, когда обслужено уже 5, парикмахер засыпает
                if (waiting == 0 && !barberSleeping && haircutedClientCount == 5)
                {
                    barberSleeping = true;
                    Console.WriteLine("The barber falls asleep.");
                }

                if (waiting > 0)
                {
                    // Если парикмахер спит, клиент его будит
                    if (barberSleeping)
                    {
                        barberSleeping = false;
                        Console.WriteLine("The barber wakes up to serve a customer.");
                    }

                    currentCustomer = customerQueue.Dequeue();
                    waiting--;

                    Console.WriteLine($"The barber prepares the chair for client {currentCustomer}. Waiting clients: {waiting}");
                    Console.WriteLine($"The barber cuts the hair of client {currentCustomer}.");
                    Thread.Sleep(2000); // Стрижка 

                    haircutedClientCount++;
                }
            }

            // 10 клиентов в день, потом парикмахерская закрывается
            if (haircutedClientCount == 10)
            {
                Console.WriteLine("The barber shop closes for the day.");
                break;
            }
        }
    }

    static void Customer(object num)
    {
        int customerId = (int)num;

        lock (locker)
        {
            // Если есть места для ожидания, заходит иначе уходит 
            if (waiting < chairs)
            {
                waiting++;
                customerQueue.Enqueue(customerId);
                Console.WriteLine($"Client {customerId} is waiting in line. There are {waiting} clients waiting.");
            }
            else
            {
                Console.WriteLine($"Client {customerId} leaves because there are no vacancies.");
            }
        }
    }
}

