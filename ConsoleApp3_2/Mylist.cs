using ConsoleApp3_2;
using System;
using System.Collections.Generic;

namespace ConsoleApp3_2
{
    internal class MyList : IOutput
    {
        private List<int> myList;

        public MyList(List<int> list)
        {
            myList = list;
        }

        public void Show()
        {
            Console.WriteLine("Elements of the list:");
            foreach (var element in myList)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }

        public void Show(string info)
        {
            Console.WriteLine(info);
            Show();
        }
    }
}
