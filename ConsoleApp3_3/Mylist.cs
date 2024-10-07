using System;
using System.Collections.Generic;

namespace ConsoleApp3_3
{
    internal class MyList : IOutput, IMath, ISort
    {
        private List<int> myList;

        internal MyList(List<int> list)
        {
            if (list == null || list.Count == 0)
            {
                throw new ArgumentException("The list must not be empty or null.\n");
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

        public void SortAsc()
        { 
            List<int> listTmp = myList;
            listTmp.Sort();
            Console.WriteLine("\n The list sorted in ascending order \n" + string.Join(", ", listTmp));
        }

        public void SortDesc()
        {
            List<int> listTmp = myList;
            listTmp.Reverse();
            Console.WriteLine("\n The list sorted in descending order \n" + string.Join(", ", listTmp));
        }

        public void SortByParam(bool isAsc)
        {
            if (isAsc)
            {
                SortAsc();
            }
            else
            {
                SortDesc();
            }
        }
    }
}
