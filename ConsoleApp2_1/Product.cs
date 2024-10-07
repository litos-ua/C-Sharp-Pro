
using System;

namespace ConsoleApp2_1
{
    class Product
    {
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductDiscount { get; set; }

        public Product(string productName, int productPrice, int productQuantity, int productDiscount = 0, string productCategory = "", string productDescription = "")
        {
            if (productPrice < 0)
            {
                throw new ArgumentException("Constructor error.Product price cannot be negative.");
            }
            if (productQuantity < 0)
            {
                throw new ArgumentException("Constructor error.Product quantity cannot be negative.");
            }
            if (productDiscount > productPrice)
            {
                throw new ArgumentException("Constructor Error.Product discount cannot exceed the product price.");
            }

            ProductName = productName;
            ProductPrice = productPrice;
            ProductQuantity = productQuantity;
            ProductDiscount = productDiscount;
            ProductCategory = productCategory;
            ProductDescription = productDescription;
        }

        public bool IsValidProduct()
        {
            if (ProductPrice < 0)
            {
                Console.WriteLine("Error: The product price cannot be negative.");
                return false;
            }
            if (ProductQuantity <= 0)
            {
                Console.WriteLine("Error: The product is out of stock.");
                return false;
            }
            if (ProductDiscount > ProductPrice)
            {
                Console.WriteLine("Error: The product discount cannot exceed the product price.");
                return false;
            }
            return true;
        }

        public int QuantityDiff(int quantity)
        {
            if (quantity < 0)
            {
                Console.WriteLine("Error: The quantity to subtract cannot be negative.");
                return ProductQuantity;
            }

            if (ProductQuantity >= quantity)
            {
                ProductQuantity -= quantity;
                return ProductQuantity;
            }
            else
            {
                Console.WriteLine("Warning: Insufficient stock. Cannot remove more than available.");
                return ProductQuantity; 
            }
        }
    }


}