

using System;
using System.Collections.Generic;

namespace ConsoleApp3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intNumbers = new List<int> { 197, 12, -3, 451, 5, 77, -89, 0, 11, 122, 9789, 0, 7, 123, 255 };
            MyList myList = new MyList(intNumbers);

            myList.Show();
            myList.Show($"The list of integers ({intNumbers.Count}):");
        }
    }
}