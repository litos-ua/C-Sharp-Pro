﻿using System;


namespace ConsoleApp3_3
{
    public interface IMath
    {
        int Max(); // повертає максимум
        int Min(); // повертає мінімум
        float Avg(); // повертає середньоарифметичне
        bool Search(int valueToSearch); // шукає valueSearch всередині контейнера даних.
    }
}
