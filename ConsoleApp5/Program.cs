using System;

namespace ConsoleApp5
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter of the homework number ('1', '2', '3').");
            Int32.TryParse(Console.ReadLine(), out int taskNumber);

            switch (taskNumber)
            {
                case 1:
                    Console.WriteLine("Task 5.1");
                    
                    Play myPlay1 = new Play("Caesar and Cleopatra", "Bernard Shaw", "Drama", 1898);
                    myPlay1.DisplayInfo();
                    if (myPlay1.IsClassic())
                    {
                        Console.WriteLine($"The play {myPlay1.Title} is classic.");
                    }

                    Play myPlay2 = new Play("One hundred thousand", "Ivan Karpenko-Karyi", "Comedy", 1879);
                    myPlay2.DisplayInfo();

                    if (myPlay2.IsClassic())
                    {
                        Console.WriteLine($"The play {myPlay2.Title} is classic.");
                    }

                    Play myPlay3 = new Play("Northern Lights", "Volodymyr Sniegurchenko", "Phantasmagoria", 2008);
                    myPlay3.DisplayInfo();

                    if (myPlay3.IsClassic())
                    {
                        Console.WriteLine($"The play {myPlay3.Title} is classic.");
                    }

             
                    GC.Collect();
                    

                    Console.WriteLine("Garbage collection complete.");
                    break;
                case 2:
                    Console.WriteLine("Task 5.2");

                    using (Store groceryStore = new Store("Organic vegetables", "Nauki avenue, 31", "vegetable"))
                    {
                        groceryStore.OpenStore();
                        groceryStore.ServeCustomer("Sergey Drozdov");
                        groceryStore.CloseStore();
                    }

                    Console.WriteLine();

                    using (Store groceryStore = new Store("Winter clothes", "Kosmichna Street, 72", "clothing"))
                    {
                        groceryStore.OpenStore();
                        groceryStore.CloseStore();
                        groceryStore.ServeCustomer("Irena Lipinska");
                    }

                    Console.WriteLine("Store operations completed.");
                    break ;
            default:
                    Console.WriteLine("Invalid task number.");
                    return;
            }


        }
    }
}
