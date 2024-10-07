using System;
using System.Collections.Generic;


namespace ConsoleApp3_3
{
    internal interface ISort
    {
        void SortAsc(); // сортування за зростанням
        void SortDesc(); // сортування за зменшенням
        void SortByParam(bool isAsc); // сортування залежно від переданого параметра
    }
}
