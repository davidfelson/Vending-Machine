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

        public string Message 
        { get
            {
                if (ProductType == "Gum")
                {
                    return "Chew Chew, Yum!";
                }
                if (ProductType == "Drink")
                {
                    return "Glug Glug, Yum!";
                }
                if (ProductType == "Chip")
                {
                    return "Crunch Crunch, Yum!";
                }
                else if (ProductType == "Candy")
                {
                    return "Munch Munch, Yum!";
                }
                return "";
            }
                
        }
        

        //Constructor

        public Product (string slotLocation, string productName, decimal price, string productType)
        {
            SlotLocation = slotLocation;
            ProductName = productName;
            Price = price;
            ProductType = productType;
            Quantity = 5;

        }
        
    }
}
