using ConsoleApp3_2;
using System;
using System.Collections.Generic;

namespace ConsoleApp3_2
{
    internal class MyList : IOutput, IMath
    {
        private List<int> myList;

        internal MyList(List<int> list)
        {
            if (list == null || list.Count == 0)
            {
                throw new ArgumentException("The list must not be empty or null.");
            }

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

        public int Max()
        {
            int maxList = myList.Max();
            return maxList;
        }

        public int Min()
        {
            int minList = myList.Min();
            return minList;
        }

        public float Avg()
        {
            float avgList = (float)Math.Round(((float)myList.Sum() / myList.Count()),2);
            return avgList;
        }


        public bool Search(int valueToSearch)
        {
            return myList.Exists(x => x == valueToSearch);
        }
        
    }
}
