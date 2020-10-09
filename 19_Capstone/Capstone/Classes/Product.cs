using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Product
    {
        //Properties
        public string SlotLocation { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductType { get; }
        public int Quantity { get; set; }
        

        //Constructor

        public Product (string slotLocation, string productName, decimal price, string productType)
        {
            SlotLocation = slotLocation;
            ProductName = productName;
            Price = price;
            ProductType = productType;
            Quantity = 5;

        }

        //Method
        public void UpDateQuantity(int Quantity)
        {
            Quantity--;
        }


    }
}
