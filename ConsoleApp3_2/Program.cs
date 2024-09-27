using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ConsoleApp3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intNumbers = new List<int> { 197, 12, -3, 451, 5, 77, -89, 0, 11, 122, 9789, 0, 7, 123, 255 };
            MyList myList = new MyList(intNumbers);
            
            
            
            // Перевірка блокировки створення пустого листа
            try
            {
                List<int> intNumbersEmpty = new List<int> { };
                MyList myListEmpty = new MyList(intNumbersEmpty);  
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);  
            }

            
            
            
            /* З А В Д А Н Н Я 1*/
            Console.WriteLine("Task 3.1");
            myList.Show();
            myList.Show($"The list of integers ({intNumbers.Count}):");
            /*--------------------------------------------------------------*/

            
            
            /*З А В Д А Н Н Я 2*/
            Console.WriteLine("\n Task 3.2");
            Console.WriteLine($"Maximum value of the list: {myList.Max()}");
            Console.WriteLine($"Minimum value of the list: {myList.Min()}");
            Console.WriteLine($"Average value of the list: {myList.Avg()}");

            Console.WriteLine("Enter the number.");
            string searchParamStr = Console.ReadLine();

            // Перевірка чи належить введене число до списку.
            if (Int32.TryParse(searchParamStr, out int searchParam)) {
                Console.WriteLine(myList.Search(searchParam)
                     ? $"The element '{searchParam}' has been found."
    :                  $"The element '{searchParam}' hasn't been found.");
            } else {
                Console.WriteLine("Invalid number.");
            }
            /*-------------------------------------------------------------*/
        }
    }
}