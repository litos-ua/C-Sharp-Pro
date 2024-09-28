using System;

namespace ConsoleApp3_3
{
    public interface IOutput
    {
        void Show(); //відображає на екран елементи масиву
        void Show(string info); //відображає на екрані елементи масиву та інформаційне повідомлення
    }
}
