using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Capstone.Classes
{
    public class Machine
    {

        //Properties 

        private Dictionary<string, Product> vendingDictionary = new Dictionary<string, Product>();

        public decimal Balance { get; private set; }

        public int Quantity { get; set; }

        public Machine(List<Product> productList)
        {
            foreach (Product product in productList)
            {
                vendingDictionary[product.SlotLocation] = product;
            }
        }


        //TODO: Add unit tests for FeedMoney() and MakeChange()

        //Methods

        //public string[] CollectData()
        //{
        //datetime
        //product type or feedmoney or give change        
        //starting balance                                //HOW TO GET STARTING BALANCE???
        //updated balance

        //}


        public decimal FeedMoney(decimal bill) //QUESTION: do we need balance in this method?
        {
            //Console.Write("Insert bill ($1, $2, $5, $10)");
            //string billInserted = Console.ReadLine();
            //string billI = billInserted.Substring(1);  //QUESTION: how does the user enter bills?
            //decimal bill = decimal.Parse(billI);
            if ((bill == 1M) || (bill == 2M) || (bill == 5M) || (bill == 10M))
            {
                Balance += bill;
                return Balance;
            }
            else
                return Balance;

            //Console.WriteLine($"Your balance is: {Balance:C}"); 
        }

        public int[] MakeChange()
        {
            decimal quarter = 0.25M;
            decimal dime = 0.1M;
            decimal nickel = .05M;
            int[] changeGiven = new int[3];

            changeGiven[0] = (int)(Balance % quarter);
            Balance -= quarter * changeGiven[0];

            changeGiven[1] = (int)(Balance % dime);
            Balance -= dime * changeGiven[1];

            changeGiven[2] = (int)(Balance % nickel);
            Balance -= nickel * changeGiven[2];

            return changeGiven;
        }


        public IEnumerable<Product> DisplayItems()
        {
            return vendingDictionary.Values;
        }


        public Product DispenseProduct(string slotLocation)
        {
             if (!vendingDictionary.ContainsKey(slotLocation))
            {
                throw new Exception ("This item does not exist.");
            }

            Product selectedProduct = vendingDictionary[slotLocation];

            if (selectedProduct.Quantity == 0)
            {
                throw new Exception ("Item is out of stock.");
            }
            else
            {
                if (Balance < selectedProduct.Price)
                {
                    throw new Exception ("Not enough money in balance for item.");
                }

                else
                {
                    Balance -= selectedProduct.Price;

                    selectedProduct.Quantity--;

                   
                }

            }
            //Dispensing an item prints the item name, cost, and the money
            return selectedProduct;
        }

    }
}

