using System;

namespace ConsoleApp2_1
{
    class Money
    {
        private int EuroRubles { get; set; } = 0;
        private int EuroCoins { get; set; } = 0;

        public void AddMoney(int roubles, int coins)
        {
            EuroRubles += roubles;
            EuroCoins += coins;
            Console.WriteLine($"You have topped up your account with: {roubles} euro and {coins} coins");
            Console.WriteLine($"On the account: {EuroRubles} euro and {EuroCoins} coins");
        }

        public void DiffMoney(int roubles, int coins)
        {
            if ((EuroRubles + 100 * EuroCoins) > (roubles + 100 * coins))
            {
                EuroRubles -= roubles;
                EuroCoins -= coins;
                Console.WriteLine($"You have withdrawn: {roubles} euro and {coins} coins");
                Console.WriteLine($"On the account: {EuroRubles} euro and {EuroCoins} coins");
            }
            else {
                Console.WriteLine("Insufficient funds. Please top up your account.");
            }
        }

        public void HowMuchMoney()
        {
            Console.WriteLine($"On the account: {EuroRubles} euro and {EuroCoins} coins");
        }

        public void BuyProduct(Product product, int quantity)
        {
            int totalPrice = (product.ProductPrice - product.ProductDiscount) * quantity;
            int totalMoney = EuroRubles * 100 + EuroCoins;

            if (totalMoney >= totalPrice * 100) 
            {
                if (product.ProductQuantity >= quantity)
                {
                    totalMoney -= totalPrice * 100;
                    EuroRubles = totalMoney / 100;
                    EuroCoins = totalMoney % 100;

                    product.QuantityDiff(quantity);

                    Console.WriteLine($"You have successfully bought {quantity} {product.ProductName}(s).");
                    Console.WriteLine($"Remaining balance: {EuroRubles} euro and {EuroCoins} coins");
                }
                else
                {
                    Console.WriteLine($"Not enough {product.ProductName}(s) in stock.");
                }
            }
            else
            {
                Console.WriteLine("Insufficient funds. Please top up your account.");
            }
        }
    }

}
