using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Machine
    {
		/*todo Properties of Machine
				 -calls on Properties from Product and Money Classes
			Property: Balance
			-has property/Method PriceTotal that is derived from below dictionay to get product and price
				-make a dictonary with kvp slot location, Product[product name and price]
		*/

		/*todo Machine Methods
		Method: FeedMoney()

				decimal input/output
				displays amounts for input
				adds what user inputs and displays it
					... called in Sub Menu when user selects Feed Money

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








	}
}
