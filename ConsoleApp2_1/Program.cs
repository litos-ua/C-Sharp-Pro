using System;

namespace ConsoleApp2_1
{
    class Program
    {
        static void Main()
        {
            Money account = new Money();
            try
            {
                Product apple_err = new Product("Apple", -1, 50, 0); //Пробуємо створити об'єкт із валідними даними
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            

            Product apple = new Product("Apple", 2, 50, 0); // Ціна 2 євро за штуку, наявність 50 шт., без знижки
            Product mango = new Product("Mango", 5, 7, 1); // Ціна 5 євро за штуку, наявність 7 шт., 1 євро знижки


            account.AddMoney(20, 50); // Додаємо на рахунок 20 євро 50 центів
            account.BuyProduct(apple, 5); // Купуємо 5 яблук
            account.BuyProduct(mango, 5); // Купуємо 5 манго - недостатньо коштів
            account.HowMuchMoney(); //Перевіряємо рахунок
            account.AddMoney(15, 20); // Додаємо на рахунок 15 євро 20 центів
            account.BuyProduct(mango, 5); //Повторюємо покупку манго – вдало
        }
    }
}


