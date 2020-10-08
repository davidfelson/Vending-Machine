using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Capstone.Classes
{
    public class Machine
    {
        private Dictionary<Product, Product> vendingDictionary = new Dictionary<Product, Product>();
        public decimal Balance { get; private set; }
        public List<Product> ProductList { get; set; } 
        public int Quantity {get; }

        //TODO Call on Product.cs properties

        /*todo Properties of Machine
				 -calls on Properties from Product class
			Property: Balance
			-has property/Method PriceTotal that is derived from below dictionay to get product and price
				-make a dictonary with kvp slot location, Product[product name and price]
		*/
        //TODO: Add unit tests for FeedMoney() and MakeChange()
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



    }

        public List<Product> DisplayItems()
        {

        return ProductList; 
        }

          




}


/*todo Machine Methods


    Method: MakeChange()

        decimal input/output
        takes remaining dollar amount and gives back change
            ... called in Menu when user selects Exit
    Method: DisplayItems()

        uses dictonary to list out all items
        returns list to user


    Method: DispenseProduct()

        make sure item is available, checks inventory (if not send user back to menu)
        make sure item is in machine, checks slot location (if not display message to user)
            returns error messages or PriceTotal
        -checks Balance to make sure enough money vs PriceTotal
        -dispenses item with outgoing message from ProductType
        -updates Inventory and Balance
            ... called in Sub Menu when user selects Finish Transaction

*/








//	}
//}
