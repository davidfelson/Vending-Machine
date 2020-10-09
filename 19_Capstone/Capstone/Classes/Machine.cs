using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Capstone.Classes
{
    public class Machine
    {

        //Properties 

        private Dictionary<string, Product> vendingDictionary = new Dictionary<string, Product>();
       
        public decimal Balance { get; private set; }
        public List<Product> ProductList { get; set; }
        public int Quantity { get; set; }

        //TODO Call on Product.cs properties

       
        //TODO: Add unit tests for FeedMoney() and MakeChange()

        //Methods
        
        //public string[] CollectData()
        //{
        ////datetime
        ////product type or feedmoney or give change        
        ////starting balance                                //HOW TO GET STARTING BALANCE???
        ////updated balance
        
        //}
            

        public decimal FeedMoney() //QUESTION: do we need balance in this method?
        {
            Console.Write("Insert bill ($1, $2, $5, $10)");
            string billInserted = Console.ReadLine();
            string billI = billInserted.Substring(1);  //QUESTION: how does the user enter bills?
            decimal bill = decimal.Parse(billI);
            Balance += bill;
            return Balance;
            //Console.WriteLine($"Your balance is: {Balance:C}"); 
        }

        public decimal[] MakeChange()
        {
            decimal quarter = 0.25M;
            decimal dime = 0.1M;
            decimal nickel = .05M;
            decimal[] changeGiven = new decimal[] { quarter, dime, nickel };
            Balance %= quarter;
            changeGiven[0] = Balance;

            Balance %= dime;
            changeGiven[1] = Balance;

            Balance %= nickel;
            changeGiven[2] = Balance;

            return changeGiven;
        }

        public List<Product> DisplayItems()
        {

            return ProductList;
        }

        public string DispenseProduct( string slotLocation, Product product)
        {
            //make sure item is in machine, checks slot location(if not display message to user)
            string message = "";
            foreach (KeyValuePair<string, Product> kvp in vendingDictionary)
            {
                if (!vendingDictionary.ContainsKey(kvp.Key))
                {
                    message = "This item does not exist.";
                }
                else
                {
                    if (Quantity == 0)
                    {
                        message = "Item is out of stock.";
                    }
                    else
                    {
                        if (Balance >= product.Price)
                        {
                            Balance -= product.Price;

                            Quantity--;
                         
                            if (product.ProductType == "Gum")
                            {
                                message = "Chew Chew, Yum!";
                            }
                            if (product.ProductType == "Drink")
                            {
                                message = "Glug Glug, Yum!";
                            }
                            if (product.ProductType == "Chip")
                            {
                                message = "Crunch Crunch, Yum!";
                            }
                            else if (product.ProductType == "Candy")
                            {
                                message = "Munch Munch, Yum!";
                            }

                        }
                        else if (Balance < product.Price)
                        {
                            message = "Not enough money in balance for item.";
                        }
                      
                    } 
                }
             
            }
            return message;
   
        }





        string filePath = @"..\..\..\..\Log.txt";

        public void AuditLog(string[] components)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                if  
                {



                }
                    {
                    writer.WriteLine($"{DateTime.UtcNow}");
                }
            }
        }

    }
}

