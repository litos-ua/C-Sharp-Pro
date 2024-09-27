using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3_2
{
    internal interface IMath
    {
        int Max(); // повертає максимум
        int Min(); // повертає мінімум
        float Avg(); // повертає середньоарифметичне
        bool Search(int valueToSearch); // шукає valueSearch всередині контейнера даних.
    }
}
