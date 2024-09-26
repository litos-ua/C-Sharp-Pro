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
            ProductName = productName;
            ProductPrice = productPrice;
            ProductQuantity = productQuantity;
            ProductDiscount = productDiscount;
            ProductCategory = productCategory;
            ProductDescription = productDescription;
        }

        public int QuantityDiff(int quantity)
        {
            ProductQuantity -= quantity;
            return ProductQuantity;
        }
    }

}
