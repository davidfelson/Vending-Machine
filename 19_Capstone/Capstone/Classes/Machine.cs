﻿using System;
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




        //Methods

        public decimal FeedMoney(decimal bill)
        {
            Balance += bill;
            return Balance;

        }

        public int[] MakeChange()
        {
            decimal quarter = 0.25M;
            decimal dime = 0.1M;
            decimal nickel = .05M;
            int[] changeGiven = new int[3];
            decimal mathStep = Balance / quarter;
            changeGiven[0] = (int)(mathStep);
            Balance -= quarter * changeGiven[0];

            decimal mathStep1 = Balance / dime;
            changeGiven[1] = (int)(mathStep1);
            Balance -= dime * changeGiven[1];

            decimal mathStep2 = Balance / nickel;
            changeGiven[2] = (int)(mathStep2);
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
                throw new Exception("This item does not exist.");
            }

            Product selectedProduct = vendingDictionary[slotLocation];

            if (selectedProduct.Quantity == 0)
            {
                throw new Exception("Item is out of stock.");
            }
            else
            {
                if (Balance < selectedProduct.Price)
                {
                    throw new Exception("Not enough money in balance for item.");
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

        public void AuditLog(string components)
        {
            string filePathLog = @"..\..\..\..\Log.txt";
            using (StreamWriter writer = new StreamWriter(filePathLog, true))
            {
                writer.WriteLine(components);

            }

        }

        public void SalesReport(string salesLog)
        {
            string filePathLog = @"..\..\..\..\SalesReport.txt";
            using (StreamWriter writer = new StreamWriter(filePathLog, false))
            {
                writer.WriteLine(salesLog);

            }

        }


    }
}

