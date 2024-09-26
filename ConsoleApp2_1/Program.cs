using System;

namespace ConsoleApp2_1
{
    class Program
    {
        static void Main()
        {
            Money account = new Money();
            Product apple = new Product("Apple", 2, 50, 0); // Цена 2 евро за штуку, в наличие 50 шт., без скидки
            Product mango = new Product("Mango", 5, 7, 1); // Цена 5 евро за штуку, в наличие 7 шт., 1 евро скидки


            account.AddMoney(20, 50); // Добавляем на счет 20 евро 50 центов
            account.BuyProduct(apple, 5); // Покупаем 5 яблок
            account.BuyProduct(mango, 5); // Покупаем 5 манго - недостаточно средств
            account.HowMuchMoney(); //Проверяем счет
            account.AddMoney(15, 20); // Добавляем на счет 15 евро 20 центов
            account.BuyProduct(mango, 5); //Повторяем покупку манго - удачно
        }
    }
}


