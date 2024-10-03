using System;

namespace ConsoleApp4
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string CardOwner { get; set; }
        public DateTime ValidDate { get; set; }
        public string PaymentSystem { get; set; }
        private int cvcCode;
        private int amountOfMoney;

        public int CvcCode
        {
            get { return cvcCode; }
            set
            {
                if (value.ToString().Length != 3)
                {
                    throw new ArgumentException("CVC code must be a 3-digit number.");
                }
                cvcCode = value;
            }
        }

        public int AmountOfMoney
        {
            get { return amountOfMoney; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount of money cannot be negative.");
                }
                amountOfMoney = value;
            }
        }

        public CreditCard(string cardNumber, string cardOwner ,DateTime validDate, int cvcCode, string paymentSystem, int amountOfMoney)
        {
            CardNumber = cardNumber;
            CardOwner = cardOwner;
            ValidDate = validDate;
            CvcCode = cvcCode;
            PaymentSystem = paymentSystem;
            AmountOfMoney = amountOfMoney;
        }

        public static CreditCard operator +(CreditCard card, int amount)
        {
            card.AmountOfMoney += amount;
            return card;
        }

        public static CreditCard operator -(CreditCard card, int amount)
        {
            card.AmountOfMoney -= amount;
            if (card.AmountOfMoney < 0)
            {
                card.AmountOfMoney = 0; 
            }
            return card;
        }

        public static bool operator ==(CreditCard card, int cvc)
        {
            return card.CvcCode == cvc;
        }

        public static bool operator !=(CreditCard card, int cvc)
        {
            return !(card.CvcCode == cvc);
        }

        public static bool operator <(CreditCard card1, CreditCard card2)
        {
            return card1.AmountOfMoney < card2.AmountOfMoney;
        }

        public static bool operator >(CreditCard card1, CreditCard card2)
        {
            return card1.AmountOfMoney > card2.AmountOfMoney;
        }

        public override bool Equals(object obj)
        {
            if (obj is CreditCard card)
            {
                return CvcCode == card.CvcCode;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return CvcCode.GetHashCode();
        }

        public override string ToString()
        {
            return $"Credit Card: {CardNumber}, Payment System: {PaymentSystem}, Valid Until: {ValidDate.ToShortDateString()}," +
                   $" Balance: {AmountOfMoney} GRN";
        }
    }
}

